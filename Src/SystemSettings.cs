#nullable enable

using System;
using UnityEngine;

namespace Hagans.Ecs.SystemInitialization
{
    [Serializable]
    public struct SystemSettings
    {
        public SystemSettings(Type type)
        {
            _name = type.Name;
            _assemblyQualifiedName = type.AssemblyQualifiedName;
            _active = true;
        }

        [SerializeField] string _name;
        [SerializeField] string _assemblyQualifiedName;

        [SerializeField] bool _active;

        public string AssemblyQualifiedName => _assemblyQualifiedName;
        public bool Active
        {
            get => _active;
            set => _active = value;
        }


        public static implicit operator Type(SystemSettings type) => Type.GetType(type._name);
        public static implicit operator SystemSettings(Type type) => new(type);
    }
}
