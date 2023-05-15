#nullable enable

using System;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace Hagans.Ecs.SystemInitialization
{
    [CreateAssetMenu(menuName = "Entities/System Initialization Settings")]
    public class SystemInitializationSettings : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField] SystemSettings[] _settings = new SystemSettings[0];

        public IReadOnlyList<SystemSettings> Settings => _settings;

        public static SystemInitializationSettings? Instance { get; private set; }

        public IReadOnlyList<Type> Systems { get; private set; } = new Type[0];

        public void OnAfterDeserialize()
        {
            Instance = this;

            var systems = new List<Type>();

            for (int i = 0; i < _settings.Length; i++)
                if (_settings[i].Active)
                    systems.Add(_settings[i]);

            Systems = systems;
        }

        public void OnBeforeSerialize()
        {                
            var allSystems = TypeManager.GetSystems(WorldSystemFilterFlags.Default);

            var newSettings = new SystemSettings[allSystems.Count];

            for (int i = 0; i < newSettings.Length; i++)        
                newSettings[i] = Contains(allSystems[i], out var settings) ? settings : new(allSystems[i]);        

            _settings = newSettings;
        }

        bool Contains(Type type, out SystemSettings settings)
        {
            for (int i = 0; i < _settings.Length; i++)
                if (_settings[i].AssemblyQualifiedName == type.AssemblyQualifiedName)
                {
                    settings = _settings[i];
                    return true;
                }

            settings = default;
            return false;
        }  
    }
}
