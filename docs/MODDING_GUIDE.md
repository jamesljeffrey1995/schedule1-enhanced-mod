# Modding Guide - Schedule 1 Enhanced Mod

This guide will help you understand and extend the Schedule 1 Enhanced Mod project.

## Getting Started

### Prerequisites

Before you begin, make sure you have:

1. **Visual Studio 2022** or **Rider** (recommended IDEs)
2. **.NET 6.0 SDK** installed
3. **Schedule 1** game installed via Steam
4. **MelonLoader** installed in your Schedule 1 directory
5. **S1API** mod installed
6. Basic knowledge of C# programming

### Setting Up Your Development Environment

1. **Clone the repository:**
   ```bash
   git clone https://github.com/jamesljeffrey1995/schedule1-enhanced-mod.git
   cd schedule1-enhanced-mod
   ```

2. **Get required DLL files:**
   
   You need to copy several DLL files from your Schedule 1 installation to the `lib/` folder:
   
   From `Schedule 1/` folder:
   - `MelonLoader.dll`
   
   From `Schedule 1/Mods/` folder:
   - `S1API.dll`
   
   From `Schedule 1/Schedule I_Data/Managed/` folder:
   - `UnityEngine.dll`
   - `UnityEngine.CoreModule.dll`
   - `Il2Cppmscorlib.dll`
   
   See `lib/README.md` for detailed instructions.

3. **Open the solution:**
   ```bash
   # For Visual Studio
   start Schedule1EnhancedMod.sln
   
   # For Rider
   rider Schedule1EnhancedMod.sln
   ```

4. **Build the project:**
   - In Visual Studio: Build → Build Solution (Ctrl+Shift+B)
   - In Rider: Build → Build Solution

5. **Test in-game:**
   - Copy `bin/Debug/Schedule1EnhancedMod.dll` to your `Schedule 1/Mods/` folder
   - Launch Schedule 1
   - Check the MelonLoader console for any errors

## Project Structure

```
schedule1-enhanced-mod/
├── src/
│   ├── Schedule1EnhancedMod.cs    # Main mod entry point
│   ├── Core/
│   │   └── BaseManager.cs         # Base class for managers
│   ├── Items/
│   │   ├── ItemManager.cs         # Item management
│   │   ├── CustomItem.cs          # Base item class
│   │   └── ExampleItems.cs        # Example item implementations
│   ├── NPCs/
│   │   ├── NPCManager.cs          # NPC management
│   │   ├── CustomNPC.cs           # Base NPC class
│   │   ├── DialogueSystem.cs      # Dialogue system
│   │   └── ExampleNPCs.cs         # Example NPC implementations
│   ├── Quests/
│   │   ├── QuestManager.cs        # Quest management
│   │   ├── CustomQuest.cs         # Base quest class
│   │   └── ExampleQuests.cs       # Example quest implementations
│   ├── Config/
│   │   └── ModConfig.cs           # Configuration system
│   └── Utils/
│       ├── Logger.cs              # Logging utilities
│       ├── AssetLoader.cs         # Asset bundle loading
│       └── Extensions.cs          # Extension methods
├── assets/                         # Unity asset bundles go here
├── docs/                          # Documentation
├── lib/                           # Required DLL references
├── .github/workflows/             # CI/CD automation
├── Schedule1EnhancedMod.csproj   # Project file
└── Schedule1EnhancedMod.sln      # Solution file
```

## Creating Your First Custom Item

Let's create a custom weapon as an example.

1. **Create a new file** in `src/Items/` called `CustomWeapon.cs`:

```csharp
using Schedule1EnhancedMod.Items;

namespace Schedule1EnhancedMod.Items;

public class FireSword : CustomItem
{
    public override string ItemId => "enhanced_fire_sword";
    public override string ItemName => "Fire Sword";
    public override string Description => "A legendary sword wreathed in flames.";
    public override string Category => "Weapon";
    public override int BaseValue => 500;
    public override int MaxStackSize => 1;
    public override float Weight => 3.0f;
    
    // Weapon stats
    private const int BaseDamage = 25;
    private const int FireDamage = 10;
    
    public override void OnEquip()
    {
        base.OnEquip();
        // Apply weapon stats to player
        // S1API integration would go here
        MelonLoader.MelonLogger.Msg($"Equipped {ItemName} - Damage: {BaseDamage + FireDamage}");
    }
    
    public override void OnUnequip()
    {
        base.OnUnequip();
        // Remove weapon stats from player
        MelonLoader.MelonLogger.Msg($"Unequipped {ItemName}");
    }
    
    public override bool OnUse()
    {
        // Special attack or ability
        MelonLoader.MelonLogger.Msg($"Used {ItemName} - Fire burst attack!");
        return true;
    }
}
```

2. **Register your item** in `src/Schedule1EnhancedMod.cs`:

```csharp
private void RegisterCustomContent()
{
    // Add this line:
    ItemManager.RegisterItem(new FireSword());
    
    // ... other registrations
}
```

3. **Build and test** your mod!

## Creating a Custom NPC

Let's create a blacksmith NPC who can upgrade weapons.

1. **Create a new file** in `src/NPCs/` called `BlacksmithNPC.cs`:

```csharp
using Schedule1EnhancedMod.NPCs;

namespace Schedule1EnhancedMod.NPCs;

public class BlacksmithNPC : CustomNPC
{
    public override string NPCId => "enhanced_blacksmith";
    public override string NPCName => "Forge Master Gareth";
    public override string Description => "A master blacksmith who can upgrade your weapons.";
    public override string SpawnLocation => "Blacksmith_Shop";
    
    protected override void InitializeDialogue()
    {
        // Greeting
        var rootNode = new DialogueNode("root", 
            "Welcome to my forge! Need something crafted or repaired?");
        
        rootNode.Options.Add(new DialogueOption(
            "Can you upgrade my weapon?",
            "upgrade_menu",
            () => ShowUpgradeMenu()
        ));
        
        rootNode.Options.Add(new DialogueOption(
            "Tell me about your craft.",
            "about_craft"
        ));
        
        rootNode.Options.Add(new DialogueOption(
            "I'll come back later.",
            null
        ));
        
        Dialogue.AddNode(rootNode);
        
        // More dialogue nodes...
        var aboutNode = new DialogueNode("about_craft",
            "I've been working the forge for 30 years. There's nothing I can't craft!");
        
        aboutNode.Options.Add(new DialogueOption(
            "Impressive! Let's see what you can do.",
            "root"
        ));
        
        Dialogue.AddNode(aboutNode);
    }
    
    private void ShowUpgradeMenu()
    {
        MelonLoader.MelonLogger.Msg("Opening weapon upgrade menu...");
        // Integration with game's crafting system would go here
    }
}
```

2. **Register your NPC** in `src/Schedule1EnhancedMod.cs`:

```csharp
private void RegisterCustomContent()
{
    // Add this line:
    NPCManager.RegisterNPC(new BlacksmithNPC());
    
    // ... other registrations
}
```

## Creating a Custom Quest

Let's create a quest that ties together our custom item and NPC.

1. **Create a new file** in `src/Quests/` called `FireSwordQuest.cs`:

```csharp
using Schedule1EnhancedMod.Quests;

namespace Schedule1EnhancedMod.Quests;

public class FireSwordQuest : CustomQuest
{
    public override string QuestId => "enhanced_fire_sword_quest";
    public override string QuestName => "Forging the Fire Sword";
    public override string Description => "Help Gareth forge a legendary Fire Sword.";
    
    protected override void InitializeObjectives()
    {
        Objectives.Add(new QuestObjective("Collect 5 Fire Crystals"));
        Objectives.Add(new QuestObjective("Collect 3 Steel Ingots"));
        Objectives.Add(new QuestObjective("Return to Gareth"));
    }
    
    protected override void InitializeRewards()
    {
        Rewards.Gold = 0; // The sword is the reward
        Rewards.Experience = 200;
        Rewards.Items.Add("enhanced_fire_sword");
    }
    
    protected override void OnComplete()
    {
        base.OnComplete();
        MelonLoader.MelonLogger.Msg("Gareth has forged the legendary Fire Sword for you!");
    }
}
```

2. **Register your quest:**

```csharp
private void RegisterCustomContent()
{
    // Add this line:
    QuestManager.RegisterQuest(new FireSwordQuest());
    
    // ... other registrations
}
```

## Working with Unity Asset Bundles

Asset bundles allow you to include custom 3D models, textures, and other Unity assets.

### Creating Asset Bundles in Unity

1. **Install Unity Editor** (version should match Schedule 1's Unity version)

2. **Create a new Unity project**

3. **Import your assets** (models, textures, etc.)

4. **Mark assets for bundling:**
   - Select an asset
   - In the Inspector, set the AssetBundle name at the bottom
   - Example: `customitems`

5. **Build the asset bundle:**
   Create a script in `Assets/Editor/BuildAssetBundles.cs`:

```csharp
using UnityEditor;
using System.IO;

public class BuildAssetBundles
{
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        string assetBundleDirectory = "Assets/AssetBundles";
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        
        BuildPipeline.BuildAssetBundles(
            assetBundleDirectory,
            BuildAssetBundleOptions.None,
            BuildTarget.StandaloneWindows64
        );
    }
}
```

6. **Build:** Assets → Build AssetBundles

7. **Copy the bundle** to your mod's `assets/` folder

### Loading Assets in Code

```csharp
// Load a sprite for an item icon
var icon = AssetLoader.LoadAsset<Sprite>("customitems.bundle", "fire_sword_icon");

// Load a prefab for an NPC model
var npcModel = AssetLoader.LoadAsset<GameObject>("customnpcs.bundle", "blacksmith_model");
```

## S1API Integration

S1API provides cross-compatibility between Mono and Il2Cpp builds. Here are common integration points:

### Getting Player Information

```csharp
// Example pseudocode - refer to S1API documentation for actual API
// var player = S1API.Player.GetLocalPlayer();
// var health = player.Health;
// var position = player.Position;
```

### Hooking Game Events

```csharp
// Example pseudocode
// S1API.Events.OnEnemyKilled += (enemyType) => {
//     // Handle enemy killed
// };
```

### Saving Custom Data

```csharp
// Example pseudocode
// S1API.SaveData.Set("my_custom_data", myData);
// var myData = S1API.SaveData.Get<MyDataType>("my_custom_data");
```

## Configuration System

The mod includes a configuration system that automatically saves settings to a JSON file.

### Adding New Config Options

1. **Edit `src/Config/ModConfig.cs`:**

```csharp
public class ModConfig
{
    // Add your new property
    public int FireSwordDamageMultiplier { get; set; } = 2;
    
    // ... existing properties
}
```

2. **Update the Copy and Reset methods** to include your new property

3. **Use in your code:**

```csharp
var damage = baseDamage * Schedule1EnhancedMod.Config.FireSwordDamageMultiplier;
```

## Debugging Tips

### Console Logging

Use the Logger utility:

```csharp
Logger.Info("Something happened");
Logger.Debug("Detailed debug info"); // Only shows if debug logging is enabled
Logger.Warning("Warning message");
Logger.Error("Error message");
```

### Enable Debug Logging

Edit the config file or set in code:

```json
{
  "EnableDebugLogging": true
}
```

### Common Issues

**Issue:** "Could not load file or assembly"
- **Solution:** Make sure all required DLLs are in the `lib/` folder

**Issue:** Mod doesn't load in-game
- **Solution:** Check MelonLoader console for errors. Ensure S1API is installed.

**Issue:** Changes not appearing in-game
- **Solution:** Make sure you copied the updated DLL to the Mods folder

## Testing Your Mod

1. **Build** the project (Release configuration for distribution)
2. **Copy** `bin/Release/Schedule1EnhancedMod.dll` to `Schedule 1/Mods/`
3. **Launch** Schedule 1
4. **Check** MelonLoader console for initialization messages
5. **Test** your custom content in-game

## Publishing Your Mod

### To GitHub Releases

1. **Create a tag:**
   ```bash
   git tag v1.0.0
   git push origin v1.0.0
   ```

2. The GitHub Actions workflow will automatically build and create a release

### To Thunderstore

1. Package your mod according to [Thunderstore guidelines](https://thunderstore.io/package/create/)
2. Include README, icon, and manifest
3. Upload to Thunderstore

## Next Steps

- Read the [API Documentation](API.md) for detailed API reference
- Check out the example classes for more complex implementations
- Join the Schedule 1 modding community Discord for help
- Read the [S1API documentation](https://github.com/KaBooMa/S1API) for game integration

## Resources

- [S1API GitHub](https://github.com/KaBooMa/S1API)
- [Schedule 1 Modding Wiki](https://ifbars.github.io/schedule1-modding-wiki/)
- [MelonLoader Wiki](https://melonwiki.xyz/)
- [Unity Documentation](https://docs.unity3d.com/)

Happy modding!
