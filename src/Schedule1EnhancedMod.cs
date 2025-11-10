using MelonLoader;
using S1API;
using Schedule1EnhancedMod.Config;
using Schedule1EnhancedMod.Core;
using Schedule1EnhancedMod.Items;
using Schedule1EnhancedMod.NPCs;
using Schedule1EnhancedMod.Quests;

namespace Schedule1EnhancedMod;

/// <summary>
/// Main mod class - Entry point for the Schedule 1 Enhanced Mod
/// This class inherits from MelonMod which is the base class for all MelonLoader mods
/// </summary>
public class Schedule1EnhancedMod : MelonMod
{
    // Mod Information
    public const string ModName = "Schedule 1 Enhanced Mod";
    public const string ModVersion = "1.0.0";
    public const string ModAuthor = "James Jeffrey";
    
    // Mod Components
    public static ModConfig? Config { get; private set; }
    public static ItemManager? ItemManager { get; private set; }
    public static NPCManager? NPCManager { get; private set; }
    public static QuestManager? QuestManager { get; private set; }
    
    /// <summary>
    /// Called when the mod is first initialized
    /// This is where you set up your mod and register everything
    /// </summary>
    public override void OnInitializeMelon()
    {
        LoggerInstance.Msg($"Initializing {ModName} v{ModVersion}");
        
        try
        {
            // Initialize configuration
            Config = new ModConfig();
            Config.Load();
            LoggerInstance.Msg("Configuration loaded successfully");
            
            // Initialize core systems
            InitializeManagers();
            
            // Register custom content
            RegisterCustomContent();
            
            LoggerInstance.Msg($"{ModName} initialized successfully!");
        }
        catch (Exception ex)
        {
            LoggerInstance.Error($"Failed to initialize mod: {ex.Message}");
            LoggerInstance.Error(ex.StackTrace);
        }
    }
    
    /// <summary>
    /// Initialize all the manager systems
    /// </summary>
    private void InitializeManagers()
    {
        ItemManager = new ItemManager();
        LoggerInstance.Msg("Item Manager initialized");
        
        NPCManager = new NPCManager();
        LoggerInstance.Msg("NPC Manager initialized");
        
        QuestManager = new QuestManager();
        LoggerInstance.Msg("Quest Manager initialized");
    }
    
    /// <summary>
    /// Register all custom content (items, NPCs, quests)
    /// This is where you add your custom content to the game
    /// </summary>
    private void RegisterCustomContent()
    {
        // Register custom items
        // Example: ItemManager.RegisterItem(new ExampleCustomItem());
        LoggerInstance.Msg("Custom items registered");
        
        // Register custom NPCs
        // Example: NPCManager.RegisterNPC(new ExampleNPC());
        LoggerInstance.Msg("Custom NPCs registered");
        
        // Register custom quests
        // Example: QuestManager.RegisterQuest(new ExampleQuest());
        LoggerInstance.Msg("Custom quests registered");
    }
    
    /// <summary>
    /// Called every frame - use sparingly for performance
    /// </summary>
    public override void OnUpdate()
    {
        // Update managers that need per-frame updates
        // Keep this minimal for performance!
    }
    
    /// <summary>
    /// Called when the application is quitting
    /// Good place for cleanup
    /// </summary>
    public override void OnApplicationQuit()
    {
        LoggerInstance.Msg($"{ModName} shutting down...");
        
        // Save configuration
        Config?.Save();
        
        // Cleanup managers
        ItemManager?.Cleanup();
        NPCManager?.Cleanup();
        QuestManager?.Cleanup();
        
        LoggerInstance.Msg($"{ModName} shutdown complete");
    }
}
