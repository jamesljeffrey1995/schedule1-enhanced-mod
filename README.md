# Schedule 1 Enhanced Mod

Enhanced gameplay modifications and new content for Schedule 1 using S1API.

## Features

- 🎮 **New Gameplay Mechanics** - Enhanced player progression and custom game features
- 🎁 **Custom Items** - New items with unique properties and effects
- 🗺️ **Quests & NPCs** - Interactive NPCs with custom dialogue and quest systems
- ⚙️ **Quality of Life Improvements** - Better UI, balance adjustments, and enhancements
- 🎨 **Custom Assets** - New models, textures, and visual content

## Installation

### Prerequisites
- Schedule 1 game installed
- MelonLoader installed ([Download here](https://github.com/LavaGang/MelonLoader))
- S1API mod installed ([Download from Thunderstore](https://thunderstore.io/c/schedule-i/))

### Install from Thunderstore (Recommended)
1. Install r2modman or Thunderstore Mod Manager
2. Search for "Schedule 1 Enhanced Mod"
3. Click Install
4. Launch the game through the mod manager

### Manual Installation
1. Download the latest release from [Releases](../../releases)
2. Extract the ZIP file
3. Copy `Schedule1EnhancedMod.dll` to `Schedule I/Mods/` folder
4. Launch the game

## Configuration

Edit `BepInEx/config/Schedule1EnhancedMod.cfg` to customize:
- Item spawn rates
- Difficulty adjustments
- Feature toggles
- And more!

## Development

### Building from Source

#### Requirements
- Visual Studio 2022 or Rider
- .NET Framework 6.0 SDK
- Schedule 1 game files

#### Setup
1. Clone this repository
2. Copy game assemblies to `lib/` folder:
   - `Assembly-CSharp.dll`
   - `UnityEngine.dll`
   - `UnityEngine.CoreModule.dll`
3. Copy mod dependencies:
   - `MelonLoader.dll`
   - `S1API.dll`
4. Open solution in Visual Studio
5. Build the project

### Project Structure
```
schedule1-enhanced-mod/
├── src/
│   ├── Core/              # Core mod functionality
│   ├── Items/             # Custom item system
│   ├── NPCs/              # NPC and dialogue system
│   ├── Quests/            # Quest management
│   └── Utils/             # Utility classes
├── assets/                # Unity asset bundles
├── config/                # Configuration files
├── docs/                  # Documentation
└── tests/                 # Unit tests
```

## Contributing

We welcome contributions! Please see [CONTRIBUTING.md](CONTRIBUTING.md) for guidelines.

### Development Roadmap
- [ ] Project setup and infrastructure
- [ ] Custom items system
- [ ] NPC and quest framework
- [ ] Gameplay modifications
- [ ] Asset creation pipeline
- [ ] Testing and optimization
- [ ] Release preparation

## Resources

- [Schedule 1 Modding Wiki](https://ifbars.github.io/schedule1-modding-wiki/)
- [S1API Documentation](https://github.com/KaBooMa/S1API)
- [Thunderstore Mod Database](https://thunderstore.io/c/schedule-i/)
- [Modding Tutorial Video](https://www.youtube.com/watch?v=4V1zUOcSMlA)

## Support

- **Issues**: Report bugs on our [GitHub Issues](../../issues)
- **Discord**: Join the Schedule 1 Modding Discord
- **Wiki**: Check our [documentation](../../wiki)

## License

This project is licensed under the MIT License - see [LICENSE](LICENSE) file for details.

## Credits

- **S1API Team** - For the excellent modding framework
- **Schedule 1 Developers** - For creating an amazing moddable game
- **Community Contributors** - Everyone who helps improve this mod

## Changelog

See [CHANGELOG.md](CHANGELOG.md) for version history.

---

**Made with ❤️ by the Schedule 1 modding community**