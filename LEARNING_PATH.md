# Learning Path - Schedule 1 Enhanced Mod

This document outlines a structured learning path to help you understand and extend the Schedule 1 Enhanced Mod project. Each step builds on the previous one, gradually increasing in complexity.

## Overview

This mod provides a complete foundation for Schedule 1 modding with:
- Custom item system
- NPC and dialogue system
- Quest framework
- Configuration management
- Asset loading utilities

Work through each step at your own pace. Each step includes learning tasks, practical exercises, and challenges.

---

## Step 1: Set Up Development Environment

**Goal:** Get your development environment ready and build the project.

### Tasks:
- [ ] Install Visual Studio 2022 or Rider
- [ ] Install .NET 6.0 SDK
- [ ] Clone the repository
- [ ] Copy required DLL files from Schedule 1 installation to `lib/` folder:
  - MelonLoader.dll
  - S1API.dll
  - UnityEngine.dll
  - UnityEngine.CoreModule.dll
  - Il2Cppmscorlib.dll
- [ ] Open `Schedule1EnhancedMod.sln` in your IDE
- [ ] Successfully build the project
- [ ] Copy the built DLL to Schedule 1 Mods folder
- [ ] Launch the game and verify the mod loads (check MelonLoader console)

### Resources:
- `docs/MODDING_GUIDE.md` - Complete setup guide
- `lib/README.md` - DLL file instructions

### Success Criteria:
✅ The mod builds without errors  
✅ The mod loads in-game without errors  
✅ You see initialization messages in MelonLoader console

---

## Step 2: Understand the Item System

**Goal:** Learn how the custom item system works and create your first item.

### Learning Tasks:
- [ ] Read `docs/API.md` - Item System section
- [ ] Study `src/Items/CustomItem.cs` - Understand the base class and its properties/methods
- [ ] Study `src/Items/ItemManager.cs` - Understand registration and management
- [ ] Study `src/Items/ExampleItems.cs` - Examine both example implementations

### Key Concepts to Understand:
- Item properties (ID, name, value, weight, etc.)
- Item lifecycle (OnRegister, OnUse, OnEquip, OnUnequip)
- Item registration with ItemManager
- How to make consumable vs equipment items

### Practical Exercise:
1. Create a new file `src/Items/MyCustomItems.cs`
2. Create a new custom item class (e.g., a weapon, tool, or consumable)
3. Override the necessary properties and methods
4. Register it in `src/Schedule1EnhancedMod.cs` in the `RegisterCustomContent` method
5. Build and test in-game
6. Check the MelonLoader console for your item's registration message

### Challenge:
Create a custom item with unique behavior:
- A teleportation item that moves the player
- A buff consumable that provides temporary stat boosts
- A special tool with multiple uses
- An item that spawns other items or NPCs

### Success Criteria:
✅ Your custom item registers successfully  
✅ You understand the difference between consumables and equipment  
✅ You can modify item properties and see the changes

---

## Step 3: Understand the NPC and Dialogue System

**Goal:** Learn how to create NPCs with interactive dialogue trees.

### Learning Tasks:
- [ ] Read `docs/API.md` - NPC System section
- [ ] Study `src/NPCs/CustomNPC.cs` - Base NPC class
- [ ] Study `src/NPCs/DialogueSystem.cs` - Dialogue tree implementation
- [ ] Study `src/NPCs/ExampleNPCs.cs` - Both example NPCs

### Key Concepts to Understand:
- NPC lifecycle (OnRegister, OnSpawn, OnDespawn, OnInteract)
- Dialogue node structure
- Dialogue options and branching
- Actions triggered by dialogue choices
- How to connect NPCs with other systems (items, quests)

### Practical Exercise:
1. Create a new file `src/NPCs/MyCustomNPCs.cs`
2. Create a new NPC class with a custom dialogue tree
3. Build at least 3 dialogue nodes with branching options
4. Add an action to one dialogue option (e.g., give item, start quest)
5. Register the NPC in `src/Schedule1EnhancedMod.cs`
6. Build and test the dialogue flow in-game

### Challenge:
Create an NPC that:
- Has different dialogue based on conditions (time of day, player progress, etc.)
- Offers multiple services (shop, quests, information)
- Remembers previous conversations
- Has a dynamic personality

### Success Criteria:
✅ Your NPC registers and spawns successfully  
✅ The dialogue tree works with branching options  
✅ You understand how to trigger actions from dialogue  
✅ You can create complex conversation flows

---

## Step 4: Understand the Quest System

**Goal:** Learn how to create quests with objectives and rewards.

### Learning Tasks:
- [ ] Read `docs/API.md` - Quest System section
- [ ] Study `src/Quests/CustomQuest.cs` - Base quest class
- [ ] Study `src/Quests/QuestManager.cs` - Quest tracking and management
- [ ] Study `src/Quests/ExampleQuests.cs` - All three quest examples

### Key Concepts to Understand:
- Quest structure (objectives, rewards, status)
- Quest lifecycle (OnStart, Update, OnComplete, OnFail)
- How to track quest progress
- How to integrate quests with NPCs and items
- Reward systems

### Practical Exercise:
1. Create a new file `src/Quests/MyCustomQuests.cs`
2. Create a custom quest with 2-3 objectives
3. Set up appropriate rewards (gold, experience, items)
4. Register the quest in `src/Schedule1EnhancedMod.cs`
5. Test quest start and completion logic

### Challenge:
Create a complex quest that:
- Has multiple stages
- Involves a custom NPC you created
- Rewards a custom item you created
- Has optional objectives
- Can be failed under certain conditions

### Success Criteria:
✅ Your quest registers successfully  
✅ Objectives track progress correctly  
✅ Rewards are given upon completion  
✅ You understand how to integrate quests with NPCs and items

---

## Step 5: Learn Unity Asset Bundle Creation

**Goal:** Create custom visual assets using Unity.

### Learning Tasks:
- [ ] Read `docs/ASSET_BUNDLES.md` completely
- [ ] Install Unity Editor (version matching Schedule 1)
- [ ] Create a new Unity project for mod assets
- [ ] Set up the asset bundle build script

### Key Concepts to Understand:
- What asset bundles are and why they're used
- How to create and configure assets in Unity
- Asset bundle naming and organization
- How to load assets at runtime
- Performance considerations

### Practical Exercise:
1. Create or find a simple icon image (256x256 PNG)
2. Import it into Unity
3. Configure it as a sprite
4. Assign it to an asset bundle named "customicons"
5. Build the asset bundle
6. Copy it to your mod's `assets/` folder
7. Load it in your mod using `AssetLoader`
8. Use it as an icon for one of your custom items

### Challenge:
Create a complete asset bundle with:
- Multiple item icons
- A 3D model for an item or NPC
- Custom textures and materials
- Proper organization and naming

### Success Criteria:
✅ You can create and build asset bundles in Unity  
✅ Your mod successfully loads assets from bundles  
✅ You understand how to organize assets  
✅ You can use custom icons for your items

---

## Step 6: Understand Configuration System

**Goal:** Learn how the mod configuration system works.

### Learning Tasks:
- [ ] Read `docs/CONFIGURATION.md`
- [ ] Study `src/Config/ModConfig.cs`
- [ ] Run the mod once to generate the config file
- [ ] Locate and edit the configuration file
- [ ] Test configuration changes

### Key Concepts to Understand:
- JSON configuration format
- How configuration is loaded and saved
- How to add new configuration properties
- How to use configuration values in code
- Default values and validation

### Practical Exercise:
1. Add a new configuration property to `ModConfig.cs`
   - Example: `public float MyItemDamageMultiplier { get; set; } = 1.5f;`
2. Update the `CopyFrom` method to include your property
3. Update the `ResetToDefaults` method to include your property
4. Use the config value in one of your custom items/NPCs/quests
5. Test that the configuration loads, saves, and applies correctly

### Challenge:
Create a complete configuration section for your custom feature:
- Multiple related settings
- Validation to ensure values are in valid ranges
- Documentation in CONFIGURATION.md
- Presets for different playstyles

### Success Criteria:
✅ You can add new configuration properties  
✅ Configuration loads and saves correctly  
✅ You can use config values in your code  
✅ You understand JSON format and structure

---

## Step 7: Integrate with S1API

**Goal:** Learn how to integrate with S1API to interact with the game.

### Learning Tasks:
- [ ] Read the S1API documentation at https://github.com/KaBooMa/S1API
- [ ] Study S1API examples in the official documentation
- [ ] Review the S1API integration points mentioned in the code comments
- [ ] Join the Schedule 1 modding community for S1API support

### Key Concepts to Understand:
- S1API event system
- Player data access
- Game state modification
- Save data persistence
- Cross-compatibility (Mono vs Il2Cpp)

### Practical Exercise:
This requires actual S1API implementation:
1. Hook into a game event (e.g., OnEnemyKilled, OnItemPickup)
2. Access player data (health, position, inventory)
3. Modify game state based on your custom items/quests
4. Save custom data persistently
5. Test with both Mono and Il2Cpp builds if possible

### Important Note:
This step requires deeper knowledge of S1API and the Schedule 1 game structure. The current mod provides the framework, but you'll need to add actual game integration based on S1API capabilities and documentation.

### Success Criteria:
✅ You understand S1API event system  
✅ You can access and modify player data  
✅ Your custom content interacts with the actual game  
✅ Data persists across game sessions

---

## Step 8: Build a Complete Feature

**Goal:** Combine everything you've learned to create a complete, polished feature.

### Project Ideas:

**Crafting System:**
- Create a blacksmith NPC
- Design crafting quests to unlock recipes
- Create craftable custom items
- Add visual assets for crafting materials
- Make it configurable (craft times, costs, etc.)

**Trading System:**
- Create multiple merchant NPCs
- Implement dynamic pricing
- Create custom trade goods
- Add visual assets for trade items
- Track player trading reputation

**Achievement System:**
- Track player accomplishments
- Award items/titles for achievements
- Create UI elements for achievement display
- Make achievements persistent
- Add configuration for achievement difficulty

**Custom Dungeon:**
- Create a quest line to access a special area
- Design unique items found in the dungeon
- Create enemy encounters (if S1API supports)
- Add visual assets for dungeon elements
- Reward completion with special items

**Companion System:**
- Create an NPC that follows the player
- Implement companion commands
- Add companion-specific quests
- Create custom companion items/equipment
- Save companion state

### Requirements:
- [ ] Use at least one custom item
- [ ] Use at least one custom NPC with dialogue
- [ ] Use at least one custom quest
- [ ] Include custom visual assets (icons, models, or UI)
- [ ] Make it configurable
- [ ] Document your feature in a new markdown file
- [ ] Test thoroughly in-game
- [ ] Handle edge cases and errors gracefully

### Success Criteria:
✅ Feature is complete and fully functional  
✅ All systems work together seamlessly  
✅ Feature is documented  
✅ Code is clean and well-commented  
✅ Feature enhances gameplay meaningfully

---

## Step 9: Contribute Back to the Project

**Goal:** Share your learning and help improve the project for others.

### Ways to Contribute:

**Code Contributions:**
- [ ] Fix bugs or issues you encountered
- [ ] Add new example implementations
- [ ] Improve existing systems
- [ ] Add new utility functions
- [ ] Optimize performance

**Documentation:**
- [ ] Improve clarity of existing documentation
- [ ] Add missing information
- [ ] Create tutorials or guides
- [ ] Add code examples
- [ ] Translate documentation

**Community:**
- [ ] Help other users in discussions
- [ ] Answer questions about the mod
- [ ] Share your custom features
- [ ] Report issues you find
- [ ] Suggest new features

### Guidelines:
1. Read `CONTRIBUTING.md` before submitting changes
2. Follow the existing code style
3. Test your changes thoroughly
4. Update documentation if needed
5. Be respectful and helpful to other learners

### Success Criteria:
✅ You've made at least one contribution to the project  
✅ You're helping others learn  
✅ You understand the value of open source collaboration

---

## Additional Resources

### Documentation:
- `docs/API.md` - Complete API reference
- `docs/MODDING_GUIDE.md` - Step-by-step modding guide
- `docs/CONFIGURATION.md` - Configuration documentation
- `docs/ASSET_BUNDLES.md` - Unity asset creation guide

### External Resources:
- [S1API GitHub](https://github.com/KaBooMa/S1API)
- [Schedule 1 Modding Wiki](https://ifbars.github.io/schedule1-modding-wiki/)
- [MelonLoader Documentation](https://melonwiki.xyz/)
- [Unity Documentation](https://docs.unity3d.com/)

### Community:
- Join the Schedule 1 modding Discord
- Check Thunderstore for other mods
- Follow mod development discussions

---

## Tips for Success

1. **Take Your Time:** Don't rush through the steps. Make sure you understand each concept before moving on.

2. **Experiment:** Try modifying the example code to see what happens. Breaking things is part of learning!

3. **Read the Code:** The example implementations are heavily commented. Read them carefully to understand the patterns.

4. **Ask Questions:** If you're stuck, ask in the community. Other modders are happy to help.

5. **Keep Notes:** Document what you learn. It helps reinforce concepts and provides reference for later.

6. **Test Frequently:** Build and test after each change. It's easier to debug small changes than large ones.

7. **Version Control:** Use Git to track your changes. You can always roll back if something breaks.

8. **Start Simple:** Begin with simple modifications before attempting complex features.

9. **Study Other Mods:** Look at other Schedule 1 mods for inspiration and learning.

10. **Have Fun:** Modding is creative work. Enjoy the process of bringing your ideas to life!

---

## Need Help?

- Check the documentation first
- Search for similar issues on GitHub
- Ask in the Schedule 1 modding community
- Open an issue on GitHub if you find a bug
- Be specific when asking for help (include error messages, code snippets, what you tried)

Good luck on your modding journey! 🎮
