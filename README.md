# Schedule 1 Enhanced Mod

Enhanced gameplay modifications and new content for Schedule 1 using S1API.

## 🎯 For Learners

**New to Schedule 1 modding?** This project is designed as both a functional mod and a learning resource!

📚 **Start here:** [LEARNING_PATH.md](LEARNING_PATH.md) - A structured guide to understanding and extending this mod

The project includes:
- ✨ Complete, well-commented example implementations
- 📖 Extensive documentation for every system
- 🛠️ Ready-to-use frameworks for items, NPCs, quests, and more
- 🎓 Step-by-step learning path from beginner to advanced
- 🏗️ Professional project structure and best practices

## Features

This mod provides a complete modding framework with example implementations:

### Item System
- Base `CustomItem` class for creating custom items
- `ItemManager` for registration and lifecycle management
- Examples: Health Potion (consumable), Multi-Tool (equipment)

### NPC System
- Base `CustomNPC` class with spawn/despawn lifecycle
- Full dialogue tree system with branching conversations
- Examples: Merchant NPC with shop, Quest Giver NPC

### Quest System
- Base `CustomQuest` class with objectives and rewards
- `QuestManager` for tracking active and completed quests
- Examples: Combat quest, Gathering quest, Multi-objective quest

### Configuration System
- JSON-based configuration with auto-save/load
- Feature toggles and gameplay balance settings
- Runtime configuration changes

### Utilities
- Asset bundle loading system
- Consistent logging framework
- Helper extensions and utilities

## 📥 Installation (For Users)

### Prerequisites
- Schedule 1 game installed via Steam
- [MelonLoader](https://github.com/LavaGang/MelonLoader/releases) installed
- [S1API](https://thunderstore.io/c/schedule-i/p/KaBooMa/S1API/) installed

### Install Steps
1. Download the latest release from [Releases](https://github.com/jamesljeffrey1995/schedule1-enhanced-mod/releases)
2. Extract the ZIP file
3. Copy `Schedule1EnhancedMod.dll` to your `Schedule 1/Mods/` folder
4. Launch the game
5. Check the MelonLoader console to verify the mod loaded successfully

## 🛠️ Development Setup

### Prerequisites
- Visual Studio 2022 or Rider
- .NET 6.0 SDK
- Schedule 1 with MelonLoader and S1API installed

### Quick Start
1. **Clone the repository:**
   ```bash
   git clone https://github.com/jamesljeffrey1995/schedule1-enhanced-mod.git
   cd schedule1-enhanced-mod
   ```

2. **Copy required DLL files** to `lib/` folder from your Schedule 1 installation:
   - `MelonLoader.dll`
   - `S1API.dll`
   - `UnityEngine.dll`
   - `UnityEngine.CoreModule.dll`
   - `Il2Cppmscorlib.dll`
   
   See `lib/README.md` for detailed instructions.

3. **Open the solution:**
   ```bash
   # Visual Studio
   start Schedule1EnhancedMod.sln
   
   # Rider
   rider Schedule1EnhancedMod.sln
   ```

4. **Build the project:**
   ```bash
   dotnet build Schedule1EnhancedMod.sln
   ```

5. **Test your changes:**
   - Copy `bin/Debug/Schedule1EnhancedMod.dll` to `Schedule 1/Mods/`
   - Launch Schedule 1
   - Check MelonLoader console for any errors

### Project Structure
```
schedule1-enhanced-mod/
├── src/                          # Source code
│   ├── Schedule1EnhancedMod.cs  # Main mod entry point
│   ├── Core/                    # Core systems
│   ├── Items/                   # Custom item system
│   ├── NPCs/                    # NPC and dialogue system
│   ├── Quests/                  # Quest framework
│   ├── Config/                  # Configuration system
│   └── Utils/                   # Utility classes
├── assets/                       # Unity asset bundles
├── docs/                         # Documentation
│   ├── API.md                   # API reference
│   ├── MODDING_GUIDE.md         # Complete modding guide
│   ├── CONFIGURATION.md         # Configuration docs
│   └── ASSET_BUNDLES.md         # Unity asset guide
├── lib/                          # Required DLL references
├── .github/workflows/            # CI/CD automation
├── LEARNING_PATH.md              # Structured learning guide
├── Schedule1EnhancedMod.csproj  # C# project file
└── Schedule1EnhancedMod.sln     # Visual Studio solution
```

## 📚 Documentation

Start with the **[Learning Path](LEARNING_PATH.md)** for a structured guide from beginner to advanced.

### Core Documentation
- **[LEARNING_PATH.md](LEARNING_PATH.md)** - Start here! Structured learning guide with exercises
- **[docs/MODDING_GUIDE.md](docs/MODDING_GUIDE.md)** - Complete guide to creating custom content
- **[docs/API.md](docs/API.md)** - Detailed API reference with code examples
- **[docs/CONFIGURATION.md](docs/CONFIGURATION.md)** - Configuration system documentation
- **[docs/ASSET_BUNDLES.md](docs/ASSET_BUNDLES.md)** - Unity asset bundle creation guide

### Quick Examples

**Creating a Custom Item:**
```csharp
public class MyItem : CustomItem
{
    public override string ItemId => "mymod_myitem";
    public override string ItemName => "My Custom Item";
    public override string Description => "A custom item example";
    
    public override bool OnUse()
    {
        Logger.Info("Item used!");
        return true;
    }
}
```

**Creating a Custom NPC:**
```csharp
public class MyNPC : CustomNPC
{
    public override string NPCId => "mymod_mynpc";
    public override string NPCName => "My NPC";
    
    protected override void InitializeDialogue()
    {
        var root = new DialogueNode("root", "Hello!");
        Dialogue.AddNode(root);
    }
}
```

See the [Modding Guide](docs/MODDING_GUIDE.md) for complete examples.

## 🌟 Features in Development

This is a foundational framework. Actual game integration requires S1API implementation:
- Event hooks for game interactions
- Player data access and modification
- Save data persistence
- World interaction systems

The framework is ready - you just need to connect it to S1API based on your needs!

## 🤝 Contributing

Contributions are welcome! This project is designed to help people learn, so contributions that improve documentation, add examples, or enhance the learning experience are especially valuable.

Please read [CONTRIBUTING.md](CONTRIBUTING.md) for:
- Code style guidelines
- Development workflow
- How to submit changes
- Community guidelines

## 📦 Building Releases

Releases are automatically built via GitHub Actions when you push a version tag:

```bash
git tag v1.0.0
git push origin v1.0.0
```

The workflow will:
- Build the project
- Run tests (if any)
- Create a release package
- Publish to GitHub Releases

## 🔗 Resources

### Official Resources
- [S1API Documentation](https://github.com/KaBooMa/S1API) - Core API for Schedule 1 modding
- [Schedule 1 Modding Wiki](https://ifbars.github.io/schedule1-modding-wiki/) - Community wiki
- [MelonLoader Wiki](https://melonwiki.xyz/) - Mod loader documentation

### Community
- [Thunderstore](https://thunderstore.io/c/schedule-i/) - Mod database
- Schedule 1 Discord - Join for help and discussion
- [Video Tutorial](https://www.youtube.com/watch?v=4V1zUOcSMlA) - Getting started

### Development Tools
- [Unity](https://unity.com/) - For creating asset bundles
- [dnSpy](https://github.com/dnSpy/dnSpy) - .NET debugger and assembly browser
- [AssetStudio](https://github.com/Perfare/AssetStudio) - Unity asset explorer

## ❓ Need Help?

1. **Read the documentation first** - Most questions are answered in the docs
2. **Check the [Learning Path](LEARNING_PATH.md)** - Follow the structured guide
3. **Search existing issues** - Your question might already be answered
4. **Ask in the community** - Join the Schedule 1 Discord
5. **Open an issue** - If you found a bug or have a feature request

When asking for help:
- Be specific about what you're trying to do
- Include error messages or logs
- Mention what you've already tried
- Share relevant code snippets

## 📄 License

MIT License - see [LICENSE](LICENSE) for details.

---

**Happy Modding!** 🎮

This project is maintained by the community. Star the repo if you find it helpful, and consider contributing to help others learn!
