# Game Assembly References

This folder should contain the following DLL files from your Schedule 1 installation:

## Required Files:

### From MelonLoader
- `MelonLoader.dll` - Get from [MelonLoader Releases](https://github.com/LavaGang/MelonLoader/releases)

### From S1API
- `S1API.dll` - Get from [Thunderstore](https://thunderstore.io/c/schedule-i/p/KaBooMa/S1API/)

### From Schedule 1 Game Directory
Located in `Schedule 1/Schedule I_Data/Managed/`:
- `UnityEngine.dll`
- `UnityEngine.CoreModule.dll`
- `Il2Cppmscorlib.dll`

## Setup Instructions:

1. Install Schedule 1 game
2. Install MelonLoader using the installer
3. Download S1API from Thunderstore
4. Copy the DLL files listed above to this `lib/` directory
5. Build the project

## Important Notes:

- These DLLs are **not** included in source control due to licensing
- You must obtain them from your own game installation
- The project will not build without these references
- Keep these files updated when the game or mods are updated

## Version Compatibility:

- Target: .NET Framework 6.0
- MelonLoader: Latest version
- S1API: Latest version compatible with your game version
- Unity: Version should match your game's Unity version (check in game files)
