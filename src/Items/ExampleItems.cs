namespace Schedule1EnhancedMod.Items;

/// <summary>
/// Example custom item - A health potion
/// This demonstrates how to create a consumable item
/// </summary>
public class ExampleHealthPotion : CustomItem
{
    public override string ItemId => "enhanced_health_potion";
    
    public override string ItemName => "Enhanced Health Potion";
    
    public override string Description => "A powerful potion that restores health. This is an example item to demonstrate the custom item system.";
    
    public override string Category => "Consumable";
    
    public override int BaseValue => 50;
    
    public override int MaxStackSize => 10;
    
    public override float Weight => 0.5f;
    
    // Amount of health to restore
    private const int HealthRestoreAmount = 50;
    
    public override void OnRegister()
    {
        base.OnRegister();
        MelonLoader.MelonLogger.Msg($"Health Potion registered - Restores {HealthRestoreAmount} HP");
    }
    
    public override bool OnUse()
    {
        // This is where you would integrate with S1API to actually restore health
        // Example (pseudocode):
        // var player = S1API.Player.GetLocalPlayer();
        // if (player != null)
        // {
        //     player.Health += HealthRestoreAmount;
        //     MelonLoader.MelonLogger.Msg($"Restored {HealthRestoreAmount} health!");
        //     return true;
        // }
        
        MelonLoader.MelonLogger.Msg($"Used {ItemName} - Would restore {HealthRestoreAmount} HP (S1API integration needed)");
        return true;
    }
}

/// <summary>
/// Example custom item - A special tool
/// This demonstrates how to create a tool/equipment item
/// </summary>
public class ExampleEnhancedTool : CustomItem
{
    public override string ItemId => "enhanced_multitool";
    
    public override string ItemName => "Enhanced Multi-Tool";
    
    public override string Description => "A versatile tool that can be used for multiple purposes. Demonstrates equipment system.";
    
    public override string Category => "Tool";
    
    public override int BaseValue => 250;
    
    public override int MaxStackSize => 1; // Tools typically don't stack
    
    public override float Weight => 2.0f;
    
    private bool _isEquipped = false;
    
    // Tool properties
    private const float EfficiencyBonus = 1.5f;
    
    public override void OnEquip()
    {
        base.OnEquip();
        _isEquipped = true;
        
        // This is where you would apply stat modifiers via S1API
        // Example: Apply work speed bonus, gather rate bonus, etc.
        MelonLoader.MelonLogger.Msg($"Equipped {ItemName} - Efficiency bonus: {EfficiencyBonus}x");
    }
    
    public override void OnUnequip()
    {
        base.OnUnequip();
        _isEquipped = false;
        
        // Remove stat modifiers here
        MelonLoader.MelonLogger.Msg($"Unequipped {ItemName} - Efficiency bonus removed");
    }
    
    public override bool OnUse()
    {
        if (!_isEquipped)
        {
            MelonLoader.MelonLogger.Msg($"{ItemName} must be equipped to use");
            return false;
        }
        
        // Tool-specific use logic here
        MelonLoader.MelonLogger.Msg($"Using {ItemName} with {EfficiencyBonus}x efficiency");
        return true;
    }
}
