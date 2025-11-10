namespace Schedule1EnhancedMod.Quests;

/// <summary>
/// Quest status enum
/// </summary>
public enum QuestStatus
{
    NotStarted,
    InProgress,
    Completed,
    Failed
}

/// <summary>
/// Base class for all custom quests
/// Extend this class to create your own quests
/// </summary>
public abstract class CustomQuest
{
    /// <summary>
    /// Unique identifier for this quest
    /// </summary>
    public abstract string QuestId { get; }
    
    /// <summary>
    /// Display name of the quest
    /// </summary>
    public abstract string QuestName { get; }
    
    /// <summary>
    /// Description of the quest
    /// </summary>
    public abstract string Description { get; }
    
    /// <summary>
    /// Current status of the quest
    /// </summary>
    public QuestStatus Status { get; protected set; } = QuestStatus.NotStarted;
    
    /// <summary>
    /// Quest objectives
    /// </summary>
    public List<QuestObjective> Objectives { get; protected set; } = new();
    
    /// <summary>
    /// Quest rewards
    /// </summary>
    public QuestRewards Rewards { get; protected set; } = new();
    
    /// <summary>
    /// Called when the quest is registered with the QuestManager
    /// </summary>
    public virtual void OnRegister()
    {
        MelonLoader.MelonLogger.Msg($"Registering quest: {QuestName}");
        InitializeObjectives();
        InitializeRewards();
    }
    
    /// <summary>
    /// Called when the quest is unregistered (mod shutdown)
    /// </summary>
    public virtual void OnUnregister()
    {
        MelonLoader.MelonLogger.Msg($"Unregistering quest: {QuestName}");
    }
    
    /// <summary>
    /// Override this to set up the quest objectives
    /// </summary>
    protected abstract void InitializeObjectives();
    
    /// <summary>
    /// Override this to set up the quest rewards
    /// </summary>
    protected abstract void InitializeRewards();
    
    /// <summary>
    /// Start the quest
    /// </summary>
    public virtual void Start()
    {
        Status = QuestStatus.InProgress;
        OnStart();
        MelonLoader.MelonLogger.Msg($"Quest started: {QuestName}");
        ShowObjectives();
    }
    
    /// <summary>
    /// Called when the quest starts
    /// </summary>
    protected virtual void OnStart() { }
    
    /// <summary>
    /// Update the quest (called every frame for active quests)
    /// </summary>
    public virtual void Update()
    {
        if (Status != QuestStatus.InProgress)
        {
            return;
        }
        
        // Check if all objectives are complete
        if (Objectives.All(o => o.IsComplete))
        {
            Complete();
        }
    }
    
    /// <summary>
    /// Complete the quest
    /// </summary>
    public virtual void Complete()
    {
        Status = QuestStatus.Completed;
        GiveRewards();
        OnComplete();
        MelonLoader.MelonLogger.Msg($"Quest completed: {QuestName}");
    }
    
    /// <summary>
    /// Called when the quest is completed
    /// </summary>
    protected virtual void OnComplete() { }
    
    /// <summary>
    /// Fail the quest
    /// </summary>
    public virtual void Fail()
    {
        Status = QuestStatus.Failed;
        OnFail();
        MelonLoader.MelonLogger.Msg($"Quest failed: {QuestName}");
    }
    
    /// <summary>
    /// Called when the quest fails
    /// </summary>
    protected virtual void OnFail() { }
    
    /// <summary>
    /// Give rewards to the player
    /// </summary>
    protected virtual void GiveRewards()
    {
        MelonLoader.MelonLogger.Msg($"Giving rewards for quest: {QuestName}");
        MelonLoader.MelonLogger.Msg($"  Gold: {Rewards.Gold}");
        MelonLoader.MelonLogger.Msg($"  Experience: {Rewards.Experience}");
        
        foreach (var item in Rewards.Items)
        {
            MelonLoader.MelonLogger.Msg($"  Item: {item}");
        }
    }
    
    /// <summary>
    /// Show quest objectives
    /// </summary>
    protected void ShowObjectives()
    {
        MelonLoader.MelonLogger.Msg($"Objectives for {QuestName}:");
        foreach (var objective in Objectives)
        {
            var status = objective.IsComplete ? "[X]" : "[ ]";
            MelonLoader.MelonLogger.Msg($"  {status} {objective.Description}");
        }
    }
}

/// <summary>
/// Represents a single quest objective
/// </summary>
public class QuestObjective
{
    public string Description { get; set; }
    public bool IsComplete { get; set; }
    public Action? OnComplete { get; set; }
    
    public QuestObjective(string description)
    {
        Description = description;
        IsComplete = false;
    }
    
    public void MarkComplete()
    {
        IsComplete = true;
        OnComplete?.Invoke();
    }
}

/// <summary>
/// Quest rewards
/// </summary>
public class QuestRewards
{
    public int Gold { get; set; }
    public int Experience { get; set; }
    public List<string> Items { get; set; } = new();
}
