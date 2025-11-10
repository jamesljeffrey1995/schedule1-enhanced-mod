using Schedule1EnhancedMod.Core;

namespace Schedule1EnhancedMod.NPCs;

/// <summary>
/// Manages all custom NPCs in the mod
/// Handles NPC registration, spawning, and interaction
/// </summary>
public class NPCManager : BaseManager
{
    private readonly Dictionary<string, CustomNPC> _registeredNPCs = new();
    
    protected override void OnInitialize()
    {
        MelonLoader.MelonLogger.Msg("Initializing NPC Manager...");
        
        // Register example NPCs here
        // RegisterNPC(new ExampleNPC());
    }
    
    /// <summary>
    /// Register a custom NPC with the manager
    /// </summary>
    /// <param name="npc">The custom NPC to register</param>
    public void RegisterNPC(CustomNPC npc)
    {
        if (_registeredNPCs.ContainsKey(npc.NPCId))
        {
            MelonLoader.MelonLogger.Warning($"NPC with ID '{npc.NPCId}' is already registered");
            return;
        }
        
        _registeredNPCs[npc.NPCId] = npc;
        npc.OnRegister();
        
        MelonLoader.MelonLogger.Msg($"Registered NPC: {npc.NPCName} (ID: {npc.NPCId})");
    }
    
    /// <summary>
    /// Get a registered NPC by its ID
    /// </summary>
    /// <param name="npcId">The ID of the NPC to retrieve</param>
    /// <returns>The custom NPC, or null if not found</returns>
    public CustomNPC? GetNPC(string npcId)
    {
        _registeredNPCs.TryGetValue(npcId, out var npc);
        return npc;
    }
    
    /// <summary>
    /// Get all registered NPCs
    /// </summary>
    /// <returns>Collection of all registered NPCs</returns>
    public IEnumerable<CustomNPC> GetAllNPCs()
    {
        return _registeredNPCs.Values;
    }
    
    protected override void OnCleanup()
    {
        foreach (var npc in _registeredNPCs.Values)
        {
            npc.OnUnregister();
        }
        
        _registeredNPCs.Clear();
        MelonLoader.MelonLogger.Msg("NPC Manager cleaned up");
    }
}
