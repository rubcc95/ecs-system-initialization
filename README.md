# ECS System Initialization
<div><h4>System Initialization allows you to dynamically assign which systems are going to be used when executing the play mode. The library does not disable the systems you select at runtime, but simply does not add those systems to the default world on initialization.</h4></div>

[![License: MIT](https://img.shields.io/github/license/rubcc95/ecs-system-initialization?style=flat&color=greenyellow)](https://github.com/ubcc95/ecs-system-initialization/blob/main/LICENSE)
<a href="https://github.com/chromealex/ecs"><img src="https://img.shields.io/github/last-commit/rubcc95/ecs-system-initialization" /></a>

## Installing Ecs System Initialization

To use System Initialization add this repo to your unity project. Create an instance of SystemInitializationSettings from the editor via the "Assets/Create/Entities/System Initialization Settings" menu. 
> **Warning**
> System Initialization requires the com.unity.entities 1.0 package to work.

SystemInitializationSettings detectará automáticamente todos los sistemas integrados en tu proyecto en modo runtime y se actualizará de forma automática. Simplemente deshabilita los componentes que desees desde el inspector.

## Updates
ECS System Initialization is under construction and will receive future updates. Unless otherwise noted, updates to this folder will not change the internal structure of assets generated with other versions of ECS System Initialization. Upgrading to the latest version of ECS System Initialization will not resetthe settings set in previous versions.

## Known issues
ECS System Initialization uses the `ICustomBootstrap` interface. To use this package together with your own ICustomBootstrap implementation, you will need to modify the [SystemInitializationBootstrap.cs](https://github.com/rubcc95/ecs-system-initialization/blob/main/Src/SystemInitializationBootstrap.cs) file and remove the `ICustomBootstrap` implementation. Finally, remember to call `Hagans.Ecs.SystemInitialization.SystemInitializationBootstrap.Initialize(string defaultWorldName)` from your `ICustomBootstrap` implementation.
