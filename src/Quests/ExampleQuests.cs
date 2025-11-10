namespace Schedule1EnhancedMod.Quests;

/// <summary>
/// Example quest - Wolf problem
/// Demonstrates a simple combat/elimination quest
/// </summary>
public class ExampleWolfQuest : CustomQuest
{
    public override string QuestId => "enhanced_wolf_problem";
    
    public override string QuestName => "The Wolf Problem";
    
    public override string Description => "Elder Sarah has asked you to deal with the wolves threatening the village. Defeat 5 wolves to complete this quest.";
    
    private const int WolvesRequired = 5;
    private int _wolvesDefeated = 0;
    
    protected override void InitializeObjectives()
    {
        var objective = new QuestObjective($"Defeat {WolvesRequired} wolves near the village");
        Objectives.Add(objective);
    }
    
    protected override void InitializeRewards()
    {
        Rewards.Gold = 100;
        Rewards.Experience = 50;
        Rewards.Items.Add("Enhanced Health Potion");
    }
    
    protected override void OnStart()
    {
        base.OnStart();
        // This is where you would hook into game events to track wolf kills
        // Example: S1API.Events.OnEnemyKilled += OnEnemyKilled;
    }
    
    /// <summary>
    /// This would be called when an enemy is killed
    /// Hooked up through S1API event system
    /// </summary>
    public void OnEnemyKilled(string enemyType)
    {
        if (Status != QuestStatus.InProgress)
        {
            return;
        }
        
        if (enemyType == "Wolf")
        {
            _wolvesDefeated++;
            MelonLoader.MelonLogger.Msg($"Wolves defeated: {_wolvesDefeated}/{WolvesRequired}");
            
            if (_wolvesDefeated >= WolvesRequired)
            {
                Objectives[0].MarkComplete();
            }
        }
    }
    
    protected override void OnComplete()
    {
        base.OnComplete();
        MelonLoader.MelonLogger.Msg("The village is safe from wolves! Return to Elder Sarah for your reward.");
    }
}

/// <summary>
/// Example quest - Gathering quest
/// Demonstrates a collection/gathering quest
/// </summary>
public class ExampleGatheringQuest : CustomQuest
{
    public override string QuestId => "enhanced_herb_gathering";
    
    public override string QuestName => "Herb Collection";
    
    public override string Description => "The village healer needs rare herbs for medicine. Collect 10 Moonflower Petals from the forest.";
    
    private const int HerbsRequired = 10;
    private int _herbsCollected = 0;
    
    protected override void InitializeObjectives()
    {
        var objective = new QuestObjective($"Collect {HerbsRequired} Moonflower Petals");
        Objectives.Add(objective);
    }
    
    protected override void InitializeRewards()
    {
        Rewards.Gold = 75;
        Rewards.Experience = 30;
        Rewards.Items.Add("Enhanced Multi-Tool");
    }
    
    /// <summary>
    /// Call this when the player collects a herb
    /// Would be integrated with the item pickup system
    /// </summary>
    public void OnItemCollected(string itemName)
    {
        if (Status != QuestStatus.InProgress)
        {
            return;
        }
        
        if (itemName == "Moonflower Petal")
        {
            _herbsCollected++;
            MelonLoader.MelonLogger.Msg($"Moonflower Petals collected: {_herbsCollected}/{HerbsRequired}");
            
            if (_herbsCollected >= HerbsRequired)
            {
                Objectives[0].MarkComplete();
            }
        }
    }
}

/// <summary>
/// Example quest - Multi-objective quest
/// Demonstrates a quest with multiple objectives
/// </summary>
public class ExampleMultiObjectiveQuest : CustomQuest
{
    public override string QuestId => "enhanced_trader_quest";
    
    public override string QuestName => "Trader's Request";
    
    public override string Description => "Marcus the Trader needs help with several tasks to expand his business.";
    
    protected override void InitializeObjectives()
    {
        Objectives.Add(new QuestObjective("Deliver package to the neighboring town"));
        Objectives.Add(new QuestObjective("Collect rare materials (0/3)"));
        Objectives.Add(new QuestObjective("Escort caravan safely"));
    }
    
    protected override void InitializeRewards()
    {
        Rewards.Gold = 250;
        Rewards.Experience = 100;
        Rewards.Items.Add("Enhanced Health Potion");
        Rewards.Items.Add("Enhanced Multi-Tool");
        Rewards.Items.Add("Merchant's Token");
    }
    
    /// <summary>
    /// Complete objective 1 - package delivery
    /// </summary>
    public void CompletePackageDelivery()
    {
        if (Status == QuestStatus.InProgress && !Objectives[0].IsComplete)
        {
            Objectives[0].MarkComplete();
            MelonLoader.MelonLogger.Msg("Package delivered successfully!");
            ShowObjectives();
        }
    }
    
    /// <summary>
    /// Progress objective 2 - material collection
    /// </summary>
    private int _materialsCollected = 0;
    public void CollectMaterial()
    {
        if (Status == QuestStatus.InProgress && !Objectives[1].IsComplete)
        {
            _materialsCollected++;
            Objectives[1].Description = $"Collect rare materials ({_materialsCollected}/3)";
            
            if (_materialsCollected >= 3)
            {
                Objectives[1].MarkComplete();
                MelonLoader.MelonLogger.Msg("All materials collected!");
            }
            
            ShowObjectives();
        }
    }
    
    /// <summary>
    /// Complete objective 3 - escort
    /// </summary>
    public void CompleteEscort()
    {
        if (Status == QuestStatus.InProgress && !Objectives[2].IsComplete)
        {
            Objectives[2].MarkComplete();
            MelonLoader.MelonLogger.Msg("Caravan arrived safely!");
            ShowObjectives();
        }
    }
    
    protected override void OnComplete()
    {
        base.OnComplete();
        MelonLoader.MelonLogger.Msg("Marcus is very pleased with your work! He offers you a discount at his shop.");
    }
}
