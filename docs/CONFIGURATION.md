# Configuration Guide

This guide explains how to configure the Schedule 1 Enhanced Mod.

## Configuration File Location

The configuration file is automatically created at:
```
<Schedule 1 Directory>/MelonLoader/UserData/Schedule1EnhancedMod_Config.json
```

## Configuration Options

### General Settings

#### EnableDebugLogging
- **Type:** Boolean
- **Default:** `false`
- **Description:** Enables detailed debug logging in the MelonLoader console
- **When to use:** Enable this when troubleshooting issues or developing extensions

```json
"EnableDebugLogging": true
```

### Feature Toggles

#### EnableCustomItems
- **Type:** Boolean
- **Default:** `true`
- **Description:** Enable/disable all custom items from the mod
- **When to use:** Disable if you want to use the mod but not the custom items

```json
"EnableCustomItems": true
```

#### EnableCustomNPCs
- **Type:** Boolean
- **Default:** `true`
- **Description:** Enable/disable all custom NPCs from the mod
- **When to use:** Disable if custom NPCs conflict with other mods

```json
"EnableCustomNPCs": true
```

#### EnableCustomQuests
- **Type:** Boolean
- **Default:** `true`
- **Description:** Enable/disable all custom quests from the mod
- **When to use:** Disable if you don't want the custom quests

```json
"EnableCustomQuests": true
```

### Gameplay Settings

#### CustomItemDropChance
- **Type:** Float (0.0 to 1.0)
- **Default:** `0.1` (10%)
- **Description:** Chance for custom items to drop from enemies/containers
- **Range:** 0.0 (never) to 1.0 (always)

```json
"CustomItemDropChance": 0.15
```

#### QuestRewardMultiplier
- **Type:** Integer
- **Default:** `1`
- **Description:** Multiplier for quest rewards (gold and experience)
- **Example:** Set to `2` to double all quest rewards

```json
"QuestRewardMultiplier": 1
```

### UI Settings

#### ShowQuestNotifications
- **Type:** Boolean
- **Default:** `true`
- **Description:** Show notifications when quest objectives are completed
- **When to use:** Disable for a more immersive experience

```json
"ShowQuestNotifications": true
```

#### ShowItemPickupMessages
- **Type:** Boolean
- **Default:** `true`
- **Description:** Show messages when picking up items
- **When to use:** Disable to reduce UI clutter

```json
"ShowItemPickupMessages": true
```

## Example Configuration File

Here's a complete example configuration file:

```json
{
  "EnableDebugLogging": false,
  "EnableCustomItems": true,
  "EnableCustomNPCs": true,
  "EnableCustomQuests": true,
  "CustomItemDropChance": 0.1,
  "QuestRewardMultiplier": 1,
  "ShowQuestNotifications": true,
  "ShowItemPickupMessages": true
}
```

## Configuration Presets

### Default (Balanced)
```json
{
  "EnableDebugLogging": false,
  "EnableCustomItems": true,
  "EnableCustomNPCs": true,
  "EnableCustomQuests": true,
  "CustomItemDropChance": 0.1,
  "QuestRewardMultiplier": 1,
  "ShowQuestNotifications": true,
  "ShowItemPickupMessages": true
}
```

### Easy Mode
```json
{
  "EnableDebugLogging": false,
  "EnableCustomItems": true,
  "EnableCustomNPCs": true,
  "EnableCustomQuests": true,
  "CustomItemDropChance": 0.25,
  "QuestRewardMultiplier": 2,
  "ShowQuestNotifications": true,
  "ShowItemPickupMessages": true
}
```

### Hard Mode
```json
{
  "EnableDebugLogging": false,
  "EnableCustomItems": true,
  "EnableCustomNPCs": true,
  "EnableCustomQuests": true,
  "CustomItemDropChance": 0.05,
  "QuestRewardMultiplier": 1,
  "ShowQuestNotifications": false,
  "ShowItemPickupMessages": false
}
```

### Minimal (Just Custom Content, No Gameplay Changes)
```json
{
  "EnableDebugLogging": false,
  "EnableCustomItems": true,
  "EnableCustomNPCs": true,
  "EnableCustomQuests": true,
  "CustomItemDropChance": 0.1,
  "QuestRewardMultiplier": 1,
  "ShowQuestNotifications": true,
  "ShowItemPickupMessages": true
}
```

## Editing Configuration

### Method 1: Edit the JSON File

1. Close Schedule 1 if it's running
2. Navigate to `<Schedule 1>/MelonLoader/UserData/`
3. Open `Schedule1EnhancedMod_Config.json` in a text editor
4. Make your changes
5. Save the file
6. Launch Schedule 1

**Important:** Make sure the JSON syntax is valid. Invalid JSON will cause the mod to use default settings.

### Method 2: Delete and Regenerate

If you want to reset to default settings:

1. Close Schedule 1
2. Delete `Schedule1EnhancedMod_Config.json`
3. Launch Schedule 1
4. The mod will create a new config file with default values

## Troubleshooting

### Configuration Not Loading

**Problem:** Changes to the config file aren't being applied

**Solutions:**
1. Make sure you saved the file after editing
2. Check that the JSON syntax is valid (use a JSON validator)
3. Make sure Schedule 1 is completely closed before editing
4. Check the MelonLoader console for configuration-related errors

### Configuration File Missing

**Problem:** The config file doesn't exist

**Solutions:**
1. Launch Schedule 1 with the mod installed - it will create the file automatically
2. Make sure MelonLoader is properly installed
3. Check that the mod DLL is in the correct Mods folder

### Invalid JSON

**Problem:** You edited the config and now the mod won't work

**Solutions:**
1. Use a JSON validator (e.g., jsonlint.com) to check your JSON
2. Common JSON errors:
   - Missing comma between properties
   - Extra comma after the last property
   - Incorrect quote usage (use double quotes `"`, not single quotes `'`)
   - Missing closing brace `}`

## Advanced: Programmatic Configuration

If you're developing an extension or mod manager, you can access configuration programmatically:

```csharp
// Access configuration
var config = Schedule1EnhancedMod.Config;

// Read values
bool debugEnabled = config.EnableDebugLogging;
float dropChance = config.CustomItemDropChance;

// Modify values
config.QuestRewardMultiplier = 2;

// Save changes
config.Save();
```

## Configuration Best Practices

1. **Backup:** Keep a backup of your configuration before making major changes
2. **Test:** Test configuration changes with a new game save first
3. **Compatibility:** Some settings may not be compatible with other mods
4. **Performance:** Enabling debug logging can impact performance
5. **Balance:** Consider game balance when modifying multipliers

## Support

If you have issues with configuration:

1. Check the MelonLoader console for errors
2. Validate your JSON syntax
3. Try resetting to default configuration
4. Report issues on the [GitHub repository](https://github.com/jamesljeffrey1995/schedule1-enhanced-mod/issues)
