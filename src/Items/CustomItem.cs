namespace Schedule1EnhancedMod.Items;

/// <summary>
/// Base class for all custom items
/// Extend this class to create your own custom items
/// </summary>
public abstract class CustomItem
{
    /// <summary>
    /// Unique identifier for this item
    /// Should be unique across all mods (use a prefix like "yourmod_itemname")
    /// </summary>
    public abstract string ItemId { get; }
    
    /// <summary>
    /// Display name shown to the player
    /// </summary>
    public abstract string ItemName { get; }
    
    /// <summary>
    /// Description of the item
    /// </summary>
    public abstract string Description { get; }
    
    /// <summary>
    /// Item category (e.g., "Weapon", "Tool", "Consumable")
    /// </summary>
    public virtual string Category => "Misc";
    
    /// <summary>
    /// Base value/price of the item
    /// </summary>
    public virtual int BaseValue => 100;
    
    /// <summary>
    /// Maximum stack size (1 = non-stackable)
    /// </summary>
    public virtual int MaxStackSize => 1;
    
    /// <summary>
    /// Weight of the item
    /// </summary>
    public virtual float Weight => 1.0f;
    
    /// <summary>
    /// Path to the item's icon in the asset bundle
    /// </summary>
    public virtual string? IconPath => null;
    
    /// <summary>
    /// Called when the item is registered with the ItemManager
    /// Use this to set up any necessary resources or hooks
    /// </summary>
    public virtual void OnRegister()
    {
        MelonLoader.MelonLogger.Msg($"Registering item: {ItemName}");
    }
    
    /// <summary>
    /// Called when the item is unregistered (mod shutdown)
    /// Use this to clean up any resources
    /// </summary>
    public virtual void OnUnregister()
    {
        MelonLoader.MelonLogger.Msg($"Unregistering item: {ItemName}");
    }
    
    /// <summary>
    /// Called when the item is used by the player
    /// </summary>
    /// <returns>True if the item was used successfully</returns>
    public virtual bool OnUse()
    {
        MelonLoader.MelonLogger.Msg($"Used item: {ItemName}");
        return true;
    }
    
    /// <summary>
    /// Called when the item is equipped (if applicable)
    /// </summary>
    public virtual void OnEquip()
    {
        MelonLoader.MelonLogger.Msg($"Equipped item: {ItemName}");
    }
    
    /// <summary>
    /// Called when the item is unequipped (if applicable)
    /// </summary>
    public virtual void OnUnequip()
    {
        MelonLoader.MelonLogger.Msg($"Unequipped item: {ItemName}");
    }
}
