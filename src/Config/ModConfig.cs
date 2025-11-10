using System.Text.Json;

namespace Schedule1EnhancedMod.Config;

/// <summary>
/// Configuration manager for the mod
/// Handles loading and saving mod settings
/// </summary>
public class ModConfig
{
    // File path for the configuration
    private static readonly string ConfigPath = Path.Combine(
        MelonLoader.MelonEnvironment.UserDataDirectory,
        "Schedule1EnhancedMod_Config.json"
    );
    
    // Configuration properties
    public bool EnableDebugLogging { get; set; } = false;
    public bool EnableCustomItems { get; set; } = true;
    public bool EnableCustomNPCs { get; set; } = true;
    public bool EnableCustomQuests { get; set; } = true;
    
    // Gameplay settings
    public float CustomItemDropChance { get; set; } = 0.1f;
    public int QuestRewardMultiplier { get; set; } = 1;
    
    // UI settings
    public bool ShowQuestNotifications { get; set; } = true;
    public bool ShowItemPickupMessages { get; set; } = true;
    
    /// <summary>
    /// Load configuration from file
    /// Creates default configuration if file doesn't exist
    /// </summary>
    public void Load()
    {
        try
        {
            if (File.Exists(ConfigPath))
            {
                string json = File.ReadAllText(ConfigPath);
                var loadedConfig = JsonSerializer.Deserialize<ModConfig>(json);
                
                if (loadedConfig != null)
                {
                    // Copy loaded values to this instance
                    CopyFrom(loadedConfig);
                    MelonLoader.MelonLogger.Msg($"Configuration loaded from {ConfigPath}");
                }
            }
            else
            {
                // Create default configuration
                Save();
                MelonLoader.MelonLogger.Msg($"Created default configuration at {ConfigPath}");
            }
        }
        catch (Exception ex)
        {
            MelonLoader.MelonLogger.Error($"Failed to load configuration: {ex.Message}");
            MelonLoader.MelonLogger.Msg("Using default configuration");
        }
    }
    
    /// <summary>
    /// Save configuration to file
    /// </summary>
    public void Save()
    {
        try
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            
            string json = JsonSerializer.Serialize(this, options);
            File.WriteAllText(ConfigPath, json);
            
            MelonLoader.MelonLogger.Msg($"Configuration saved to {ConfigPath}");
        }
        catch (Exception ex)
        {
            MelonLoader.MelonLogger.Error($"Failed to save configuration: {ex.Message}");
        }
    }
    
    /// <summary>
    /// Copy values from another config instance
    /// </summary>
    private void CopyFrom(ModConfig other)
    {
        EnableDebugLogging = other.EnableDebugLogging;
        EnableCustomItems = other.EnableCustomItems;
        EnableCustomNPCs = other.EnableCustomNPCs;
        EnableCustomQuests = other.EnableCustomQuests;
        CustomItemDropChance = other.CustomItemDropChance;
        QuestRewardMultiplier = other.QuestRewardMultiplier;
        ShowQuestNotifications = other.ShowQuestNotifications;
        ShowItemPickupMessages = other.ShowItemPickupMessages;
    }
    
    /// <summary>
    /// Reset to default values
    /// </summary>
    public void ResetToDefaults()
    {
        EnableDebugLogging = false;
        EnableCustomItems = true;
        EnableCustomNPCs = true;
        EnableCustomQuests = true;
        CustomItemDropChance = 0.1f;
        QuestRewardMultiplier = 1;
        ShowQuestNotifications = true;
        ShowItemPickupMessages = true;
        
        MelonLoader.MelonLogger.Msg("Configuration reset to defaults");
    }
}
