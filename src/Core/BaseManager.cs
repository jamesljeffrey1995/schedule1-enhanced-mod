namespace Schedule1EnhancedMod.Core;

/// <summary>
/// Base manager class for all mod systems
/// Provides common functionality for initialization and cleanup
/// </summary>
public abstract class BaseManager
{
    protected bool IsInitialized { get; private set; }
    
    /// <summary>
    /// Initialize the manager
    /// Override this in derived classes to add initialization logic
    /// </summary>
    public virtual void Initialize()
    {
        if (IsInitialized)
        {
            MelonLoader.MelonLogger.Warning($"{GetType().Name} is already initialized");
            return;
        }
        
        OnInitialize();
        IsInitialized = true;
    }
    
    /// <summary>
    /// Override this to implement initialization logic
    /// </summary>
    protected virtual void OnInitialize()
    {
        // Override in derived classes
    }
    
    /// <summary>
    /// Cleanup resources
    /// Override this in derived classes to add cleanup logic
    /// </summary>
    public virtual void Cleanup()
    {
        if (!IsInitialized)
        {
            return;
        }
        
        OnCleanup();
        IsInitialized = false;
    }
    
    /// <summary>
    /// Override this to implement cleanup logic
    /// </summary>
    protected virtual void OnCleanup()
    {
        // Override in derived classes
    }
}
