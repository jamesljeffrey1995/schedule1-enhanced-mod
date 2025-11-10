# Schedule 1 Enhanced Mod

Enhanced gameplay modifications and new content for Schedule 1 using S1API.

## Features
- Custom items and equipment
- New NPCs and quest system
- Enhanced gameplay mechanics
- Quality of life improvements

## Installation

### Prerequisites
- Schedule 1 game installed
- MelonLoader installed
- S1API installed

### Install Steps
1. Download the latest release from [Releases](https://github.com/jamesljeffrey1995/schedule1-enhanced-mod/releases)
2. Extract the ZIP file
3. Copy `Schedule1EnhancedMod.dll` to your `Schedule 1/Mods/` folder
4. Launch the game

## Development

### Setup Development Environment
1. Install .NET Framework 6.0 SDK
2. Clone this repository
3. Open `Schedule1EnhancedMod.sln` in Visual Studio 2022
4. Build the solution

### Project Structure
```
schedule1-enhanced-mod/
├── src/                    # Source code
│   ├── Core/              # Core mod functionality
│   ├─��� Items/             # Custom items
│   ├── NPCs/              # NPC and quest system
│   └── Gameplay/          # Gameplay modifications
├── assets/                # Unity asset bundles
├── docs/                  # Documentation
└── .github/workflows/     # CI/CD automation
``` 

### Building
```bash
dotnet build Schedule1EnhancedMod.sln
```

### Testing
Copy the built DLL from `bin/Debug/` to your Schedule 1 Mods folder and test in-game.

## Resources
- [Schedule 1 Modding Wiki](https://ifbars.github.io/schedule1-modding-wiki/)
- [S1API Documentation](https://github.com/KaBooMa/S1API)
- [Thunderstore Mod Database](https://thunderstore.io/c/schedule-i/)
- [Video Tutorial](https://www.youtube.com/watch?v=4V1zUOcSMlA)

## Contributing
Contributions are welcome! Please read [CONTRIBUTING.md](CONTRIBUTING.md) for details.

## License
MIT License - see [LICENSE](LICENSE) for details.
