# MERunner.Hello
MERunner HelloWorld library example

To run `ISystem` by MERunner:
  - Add GUID attribute to your system (See [HelloWorld_System](MERunner.Hello/Sources/HelloWorld_System.cs) )
  - Add `public YourSystem(Contexts contexts): base(contexts.context)` constructor to your system (See [HelloWorld_System](MERunner.Hello/Sources/HelloWorld_System.cs) )
  - Inherit `TSystem_Factory<YourSystem>` and export inherited class with `[Export(typeof(ISystem_Factory))]` (See [HelloWorld_ystem](MERunner.Hello/Sources/HelloWorld_System.cs) )
  - Add build and runtime dependencies to projects
  - Build
  - Copy built files to `MERunner.exe` location
  - Create settings file with system guids and other options (See [HelloWorld.settings](MERunner.Hello/HelloWorld.settings) )
  - Call `mono MERunner.exe --SettingsPath=yourSettingsPath`
