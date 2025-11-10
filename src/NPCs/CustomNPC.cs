namespace Schedule1EnhancedMod.NPCs;

/// <summary>
/// Base class for all custom NPCs
/// Extend this class to create your own NPCs with dialogue and behavior
/// </summary>
public abstract class CustomNPC
{
    /// <summary>
    /// Unique identifier for this NPC
    /// </summary>
    public abstract string NPCId { get; }
    
    /// <summary>
    /// Display name of the NPC
    /// </summary>
    public abstract string NPCName { get; }
    
    /// <summary>
    /// Description or background of the NPC
    /// </summary>
    public abstract string Description { get; }
    
    /// <summary>
    /// The dialogue system for this NPC
    /// </summary>
    public DialogueSystem Dialogue { get; protected set; }
    
    /// <summary>
    /// NPC's spawn location (if applicable)
    /// </summary>
    public virtual string? SpawnLocation => null;
    
    /// <summary>
    /// Whether this NPC is currently spawned in the world
    /// </summary>
    public bool IsSpawned { get; protected set; }
    
    protected CustomNPC()
    {
        Dialogue = new DialogueSystem(this);
    }
    
    /// <summary>
    /// Called when the NPC is registered with the NPCManager
    /// </summary>
    public virtual void OnRegister()
    {
        MelonLoader.MelonLogger.Msg($"Registering NPC: {NPCName}");
        InitializeDialogue();
    }
    
    /// <summary>
    /// Called when the NPC is unregistered (mod shutdown)
    /// </summary>
    public virtual void OnUnregister()
    {
        MelonLoader.MelonLogger.Msg($"Unregistering NPC: {NPCName}");
        if (IsSpawned)
        {
            Despawn();
        }
    }
    
    /// <summary>
    /// Override this to set up the NPC's dialogue tree
    /// </summary>
    protected abstract void InitializeDialogue();
    
    /// <summary>
    /// Spawn the NPC in the world
    /// </summary>
    public virtual void Spawn()
    {
        if (IsSpawned)
        {
            MelonLoader.MelonLogger.Warning($"NPC {NPCName} is already spawned");
            return;
        }
        
        // Spawn logic would go here - integrate with S1API
        IsSpawned = true;
        OnSpawn();
        MelonLoader.MelonLogger.Msg($"Spawned NPC: {NPCName}");
    }
    
    /// <summary>
    /// Despawn the NPC from the world
    /// </summary>
    public virtual void Despawn()
    {
        if (!IsSpawned)
        {
            return;
        }
        
        // Despawn logic would go here
        IsSpawned = false;
        OnDespawn();
        MelonLoader.MelonLogger.Msg($"Despawned NPC: {NPCName}");
    }
    
    /// <summary>
    /// Called when the NPC spawns
    /// </summary>
    protected virtual void OnSpawn() { }
    
    /// <summary>
    /// Called when the NPC despawns
    /// </summary>
    protected virtual void OnDespawn() { }
    
    /// <summary>
    /// Called when the player interacts with this NPC
    /// </summary>
    public virtual void OnInteract()
    {
        MelonLoader.MelonLogger.Msg($"Interacting with {NPCName}");
        Dialogue.StartDialogue();
    }
}
