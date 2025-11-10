using Schedule1EnhancedMod.Core;

namespace Schedule1EnhancedMod.Quests;

/// <summary>
/// Manages all custom quests in the mod
/// Handles quest registration, progress tracking, and completion
/// </summary>
public class QuestManager : BaseManager
{
    private readonly Dictionary<string, CustomQuest> _registeredQuests = new();
    private readonly List<CustomQuest> _activeQuests = new();
    private readonly List<CustomQuest> _completedQuests = new();
    
    protected override void OnInitialize()
    {
        MelonLoader.MelonLogger.Msg("Initializing Quest Manager...");
        
        // Register example quests here
        // RegisterQuest(new ExampleQuest());
    }
    
    /// <summary>
    /// Register a custom quest with the manager
    /// </summary>
    /// <param name="quest">The custom quest to register</param>
    public void RegisterQuest(CustomQuest quest)
    {
        if (_registeredQuests.ContainsKey(quest.QuestId))
        {
            MelonLoader.MelonLogger.Warning($"Quest with ID '{quest.QuestId}' is already registered");
            return;
        }
        
        _registeredQuests[quest.QuestId] = quest;
        quest.OnRegister();
        
        MelonLoader.MelonLogger.Msg($"Registered quest: {quest.QuestName} (ID: {quest.QuestId})");
    }
    
    /// <summary>
    /// Start a quest
    /// </summary>
    /// <param name="questId">The ID of the quest to start</param>
    public bool StartQuest(string questId)
    {
        if (!_registeredQuests.TryGetValue(questId, out var quest))
        {
            MelonLoader.MelonLogger.Error($"Quest '{questId}' not found");
            return false;
        }
        
        if (_activeQuests.Contains(quest))
        {
            MelonLoader.MelonLogger.Warning($"Quest '{quest.QuestName}' is already active");
            return false;
        }
        
        if (_completedQuests.Contains(quest))
        {
            MelonLoader.MelonLogger.Warning($"Quest '{quest.QuestName}' is already completed");
            return false;
        }
        
        _activeQuests.Add(quest);
        quest.Start();
        
        MelonLoader.MelonLogger.Msg($"Started quest: {quest.QuestName}");
        return true;
    }
    
    /// <summary>
    /// Complete a quest
    /// </summary>
    /// <param name="questId">The ID of the quest to complete</param>
    public void CompleteQuest(string questId)
    {
        if (!_registeredQuests.TryGetValue(questId, out var quest))
        {
            return;
        }
        
        if (!_activeQuests.Contains(quest))
        {
            return;
        }
        
        _activeQuests.Remove(quest);
        _completedQuests.Add(quest);
        quest.Complete();
        
        MelonLoader.MelonLogger.Msg($"Completed quest: {quest.QuestName}");
    }
    
    /// <summary>
    /// Get all active quests
    /// </summary>
    public IEnumerable<CustomQuest> GetActiveQuests()
    {
        return _activeQuests;
    }
    
    /// <summary>
    /// Get all completed quests
    /// </summary>
    public IEnumerable<CustomQuest> GetCompletedQuests()
    {
        return _completedQuests;
    }
    
    /// <summary>
    /// Update all active quests
    /// </summary>
    public void Update()
    {
        foreach (var quest in _activeQuests.ToList())
        {
            quest.Update();
        }
    }
    
    protected override void OnCleanup()
    {
        foreach (var quest in _registeredQuests.Values)
        {
            quest.OnUnregister();
        }
        
        _registeredQuests.Clear();
        _activeQuests.Clear();
        _completedQuests.Clear();
        
        MelonLoader.MelonLogger.Msg("Quest Manager cleaned up");
    }
}
