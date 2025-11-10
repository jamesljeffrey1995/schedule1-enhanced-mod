using Schedule1EnhancedMod.Core;

namespace Schedule1EnhancedMod.Items;

/// <summary>
/// Manages all custom items in the mod
/// This handles registration, retrieval, and lifecycle of custom items
/// </summary>
public class ItemManager : BaseManager
{
    private readonly Dictionary<string, CustomItem> _registeredItems = new();
    
    protected override void OnInitialize()
    {
        MelonLoader.MelonLogger.Msg("Initializing Item Manager...");
        
        // Register example items here
        // RegisterItem(new ExampleCustomItem());
    }
    
    /// <summary>
    /// Register a custom item with the manager
    /// </summary>
    /// <param name="item">The custom item to register</param>
    public void RegisterItem(CustomItem item)
    {
        if (_registeredItems.ContainsKey(item.ItemId))
        {
            MelonLoader.MelonLogger.Warning($"Item with ID '{item.ItemId}' is already registered");
            return;
        }
        
        _registeredItems[item.ItemId] = item;
        item.OnRegister();
        
        MelonLoader.MelonLogger.Msg($"Registered item: {item.ItemName} (ID: {item.ItemId})");
    }
    
    /// <summary>
    /// Get a registered item by its ID
    /// </summary>
    /// <param name="itemId">The ID of the item to retrieve</param>
    /// <returns>The custom item, or null if not found</returns>
    public CustomItem? GetItem(string itemId)
    {
        _registeredItems.TryGetValue(itemId, out var item);
        return item;
    }
    
    /// <summary>
    /// Get all registered items
    /// </summary>
    /// <returns>Collection of all registered items</returns>
    public IEnumerable<CustomItem> GetAllItems()
    {
        return _registeredItems.Values;
    }
    
    protected override void OnCleanup()
    {
        foreach (var item in _registeredItems.Values)
        {
            item.OnUnregister();
        }
        
        _registeredItems.Clear();
        MelonLoader.MelonLogger.Msg("Item Manager cleaned up");
    }
}
