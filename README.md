# MERunner.Hello
MERunner HelloWorld library example

To run `ISystem` by MERunner:
  - Add GUID attribute to your system
  - Inherit `TSystem_Factory<YourSystem>` and export inherited class with `[Export(typeof(ISystem_Factory))]`
  - Add build and runtime dependencies to projects
  - Build
  - Copy built files to `MERunner.exe` location
  - Create settings file with system guids and other options
  - Call `mono MERunner.exe --SettingsPath=yourSettingsPath`
