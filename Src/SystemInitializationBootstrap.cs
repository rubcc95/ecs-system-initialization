#nullable enable

using Unity.Entities;

readonly struct SystemInitializationBootstrap : ICustomBootstrap
{
    public bool Initialize(string defaultWorldName)
    {
        var world = new World(defaultWorldName, WorldFlags.Game);

        World.DefaultGameObjectInjectionWorld = world;

        var initSettings = SystemInitializationSettings.Instance;
        var systemList = initSettings != null ? initSettings.Systems : DefaultWorldInitialization.GetAllSystems(WorldSystemFilterFlags.Default);
        DefaultWorldInitialization.AddSystemsToRootLevelSystemGroups(world, systemList);

#if !UNITY_DOTSRUNTIME
        ScriptBehaviourUpdateOrder.AppendWorldToCurrentPlayerLoop(world);
#endif
        return true;
    }
}
