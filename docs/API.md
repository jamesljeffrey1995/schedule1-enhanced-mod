# Schedule 1 Enhanced Mod - API Documentation

This document provides detailed information about the mod's API and how to extend it.

## Table of Contents

1. [Core Systems](#core-systems)
2. [Item System](#item-system)
3. [NPC System](#npc-system)
4. [Quest System](#quest-system)
5. [Configuration](#configuration)
6. [Utilities](#utilities)

## Core Systems

### BaseManager

Base class for all manager systems in the mod.

```csharp
public abstract class BaseManager
{
    protected bool IsInitialized { get; private set; }
    public virtual void Initialize()
    public virtual void Cleanup()
}
```

**Usage:**
All manager classes (ItemManager, NPCManager, QuestManager) inherit from this class.

## Item System

### Creating Custom Items

To create a custom item, extend the `CustomItem` class:

```csharp
public class MyCustomItem : CustomItem
{
    public override string ItemId => "mymod_customitem";
    public override string ItemName => "My Custom Item";
    public override string Description => "A custom item description";
    
    // Optional overrides
    public override string Category => "Tool";
    public override int BaseValue => 100;
    public override int MaxStackSize => 10;
    public override float Weight => 1.5f;
    
    public override bool OnUse()
    {
        // Item use logic here
        return true;
    }
}
```

### Registering Items

Register your items in the main mod class:

```csharp
public override void OnInitializeMelon()
{
    // ... initialization code
    
    ItemManager.RegisterItem(new MyCustomItem());
}
```

### Item Properties

- **ItemId**: Unique identifier (use a prefix to avoid conflicts)
- **ItemName**: Display name shown to the player
- **Description**: Item description
- **Category**: Item category (Weapon, Tool, Consumable, etc.)
- **BaseValue**: Base price/value
- **MaxStackSize**: How many can stack (1 = non-stackable)
- **Weight**: Item weight
- **IconPath**: Path to icon in asset bundle

### Item Lifecycle

- `OnRegister()`: Called when item is registered
- `OnUnregister()`: Called on mod shutdown
- `OnUse()`: Called when player uses the item
- `OnEquip()`: Called when item is equipped
- `OnUnequip()`: Called when item is unequipped

## NPC System

### Creating Custom NPCs

Extend the `CustomNPC` class:

```csharp
public class MyNPC : CustomNPC
{
    public override string NPCId => "mymod_mynpc";
    public override string NPCName => "NPC Name";
    public override string Description => "NPC description";
    
    protected override void InitializeDialogue()
    {
        // Set up dialogue tree
        var rootNode = new DialogueNode("root", "Hello, traveler!");
        
        rootNode.Options.Add(new DialogueOption(
            "Tell me more.",
            "more_info"
        ));
        
        rootNode.Options.Add(new DialogueOption(
            "Goodbye.",
            null
        ));
        
        Dialogue.AddNode(rootNode);
        
        // Add more nodes...
    }
}
```

### Dialogue System

The dialogue system uses a node-based structure:

```csharp
// Create a dialogue node
var node = new DialogueNode("node_id", "NPC dialogue text");

// Add player response options
node.Options.Add(new DialogueOption(
    "Player response text",
    "next_node_id",  // null to end conversation
    () => { /* Optional action */ }
));

// Add to dialogue system
Dialogue.AddNode(node);
```

### NPC Lifecycle

- `OnRegister()`: Called when NPC is registered
- `OnUnregister()`: Called on mod shutdown
- `OnSpawn()`: Called when NPC spawns in world
- `OnDespawn()`: Called when NPC despawns
- `OnInteract()`: Called when player interacts with NPC

## Quest System

### Creating Custom Quests

Extend the `CustomQuest` class:

```csharp
public class MyQuest : CustomQuest
{
    public override string QuestId => "mymod_myquest";
    public override string QuestName => "Quest Name";
    public override string Description => "Quest description";
    
    protected override void InitializeObjectives()
    {
        Objectives.Add(new QuestObjective("Objective 1"));
        Objectives.Add(new QuestObjective("Objective 2"));
    }
    
    protected override void InitializeRewards()
    {
        Rewards.Gold = 100;
        Rewards.Experience = 50;
        Rewards.Items.Add("item_id");
    }
}
```

### Quest Objectives

```csharp
var objective = new QuestObjective("Collect 5 items");
Objectives.Add(objective);

// Later, to complete the objective:
objective.MarkComplete();
```

### Quest Lifecycle

- `OnRegister()`: Called when quest is registered
- `OnStart()`: Called when quest starts
- `Update()`: Called every frame while quest is active
- `OnComplete()`: Called when quest is completed
- `OnFail()`: Called when quest fails

### Quest Status

```csharp
public enum QuestStatus
{
    NotStarted,
    InProgress,
    Completed,
    Failed
}
```

## Configuration

### Configuration File

Configuration is stored in JSON format at:
`MelonLoader/UserData/Schedule1EnhancedMod_Config.json`

### Configuration Properties

```csharp
public class ModConfig
{
    public bool EnableDebugLogging { get; set; }
    public bool EnableCustomItems { get; set; }
    public bool EnableCustomNPCs { get; set; }
    public bool EnableCustomQuests { get; set; }
    public float CustomItemDropChance { get; set; }
    public int QuestRewardMultiplier { get; set; }
    public bool ShowQuestNotifications { get; set; }
    public bool ShowItemPickupMessages { get; set; }
}
```

### Accessing Configuration

```csharp
if (Schedule1EnhancedMod.Config.EnableDebugLogging)
{
    // Debug logging enabled
}
```

## Utilities

### Logger

Use the Logger utility for consistent logging:

```csharp
Logger.Info("Informational message");
Logger.Warning("Warning message");
Logger.Error("Error message");
Logger.Debug("Debug message"); // Only shown if debug logging enabled
Logger.Error("Error with exception", exception);
```

### AssetLoader

Load Unity asset bundles:

```csharp
// Load a bundle
var bundle = AssetLoader.LoadBundle("mybundle.bundle");

// Load an asset from a bundle
var sprite = AssetLoader.LoadAsset<Sprite>("mybundle.bundle", "icon");
var prefab = AssetLoader.LoadAsset<GameObject>("mybundle.bundle", "npc_model");

// Unload when done
AssetLoader.UnloadBundle("mybundle.bundle");
AssetLoader.UnloadAllBundles(); // Unload all
```

### Extensions

Useful extension methods:

```csharp
// Safe component access
var component = gameObject.SafeGetComponent<Rigidbody>();

// Clamp values
var clamped = value.Clamp(0, 100);

// Check if string is null or empty
if (str.IsNullOrEmpty()) { }

// Shuffle a list
myList.Shuffle();
```

## S1API Integration

This mod is designed to work with S1API. Here are common integration points:

### Player Access

```csharp
// Get local player (S1API)
// var player = S1API.Player.GetLocalPlayer();
```

### Events

```csharp
// Hook into game events (S1API)
// S1API.Events.OnEnemyKilled += OnEnemyKilled;
// S1API.Events.OnItemPickup += OnItemPickup;
```

### Save Data

```csharp
// Save custom data (S1API)
// S1API.SaveData.Set("key", value);
// var value = S1API.SaveData.Get<Type>("key");
```

## Best Practices

1. **Unique IDs**: Always use unique IDs for items, NPCs, and quests. Use a prefix (e.g., "mymod_")
2. **Error Handling**: Wrap risky operations in try-catch blocks
3. **Performance**: Minimize work in Update() methods
4. **Cleanup**: Always clean up resources in OnUnregister/Cleanup methods
5. **Logging**: Use the Logger utility for consistent logging
6. **Configuration**: Make features configurable when possible
7. **Compatibility**: Test with both Mono and Il2Cpp builds if possible

## Examples

See the example classes for complete implementations:
- `ExampleHealthPotion` and `ExampleEnhancedTool` (Items)
- `ExampleMerchantNPC` and `ExampleQuestGiverNPC` (NPCs)
- `ExampleWolfQuest`, `ExampleGatheringQuest`, and `ExampleMultiObjectiveQuest` (Quests)

## Further Resources

- [S1API Documentation](https://github.com/KaBooMa/S1API)
- [Schedule 1 Modding Wiki](https://ifbars.github.io/schedule1-modding-wiki/)
- [MelonLoader Documentation](https://melonwiki.xyz/)
