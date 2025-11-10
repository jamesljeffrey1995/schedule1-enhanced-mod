namespace Schedule1EnhancedMod.NPCs;

/// <summary>
/// Example NPC - A friendly merchant
/// Demonstrates how to create an NPC with dialogue
/// </summary>
public class ExampleMerchantNPC : CustomNPC
{
    public override string NPCId => "enhanced_merchant";
    
    public override string NPCName => "Marcus the Trader";
    
    public override string Description => "A friendly merchant who sells rare goods. Example NPC demonstrating the dialogue system.";
    
    public override string SpawnLocation => "Town_Square"; // Example location
    
    protected override void InitializeDialogue()
    {
        // Root dialogue node - greeting
        var rootNode = new DialogueNode("root", 
            "Greetings, traveler! I'm Marcus, and I've got the finest wares in town. What can I do for you?");
        
        rootNode.Options.Add(new DialogueOption(
            "What are you selling?",
            "shop_menu"
        ));
        
        rootNode.Options.Add(new DialogueOption(
            "Tell me about yourself.",
            "about"
        ));
        
        rootNode.Options.Add(new DialogueOption(
            "Goodbye.",
            null // null = end conversation
        ));
        
        Dialogue.AddNode(rootNode);
        
        // Shop menu node
        var shopNode = new DialogueNode("shop_menu",
            "I have potions, tools, and rare materials. Take a look!");
        
        shopNode.Options.Add(new DialogueOption(
            "I'd like to buy something.",
            null,
            () => OpenShop()
        ));
        
        shopNode.Options.Add(new DialogueOption(
            "Maybe later.",
            "root"
        ));
        
        Dialogue.AddNode(shopNode);
        
        // About node
        var aboutNode = new DialogueNode("about",
            "I've been trading for over 20 years. Traveled from one end of the land to the other. " +
            "These days I prefer to stay in one place and let customers come to me.");
        
        aboutNode.Options.Add(new DialogueOption(
            "That's interesting. What else can you tell me?",
            "about_more"
        ));
        
        aboutNode.Options.Add(new DialogueOption(
            "I see. Let's talk about something else.",
            "root"
        ));
        
        Dialogue.AddNode(aboutNode);
        
        // More about node
        var aboutMoreNode = new DialogueNode("about_more",
            "Well, I've seen some strange things in my travels. But that's a story for another time!");
        
        aboutMoreNode.Options.Add(new DialogueOption(
            "Fair enough. Let's get back to business.",
            "root"
        ));
        
        Dialogue.AddNode(aboutMoreNode);
    }
    
    private void OpenShop()
    {
        // This is where you would integrate with S1API to open a shop interface
        MelonLoader.MelonLogger.Msg("Opening Marcus's shop... (S1API integration needed)");
        
        // Example items that would be in the shop:
        MelonLoader.MelonLogger.Msg("Shop Items:");
        MelonLoader.MelonLogger.Msg("  - Enhanced Health Potion (50 gold)");
        MelonLoader.MelonLogger.Msg("  - Enhanced Multi-Tool (250 gold)");
        MelonLoader.MelonLogger.Msg("  - Rare Materials (varies)");
    }
    
    protected override void OnSpawn()
    {
        base.OnSpawn();
        MelonLoader.MelonLogger.Msg($"{NPCName} has opened shop at {SpawnLocation}");
    }
}

/// <summary>
/// Example NPC - A quest giver
/// Demonstrates how to create an NPC that gives quests
/// </summary>
public class ExampleQuestGiverNPC : CustomNPC
{
    public override string NPCId => "enhanced_quest_giver";
    
    public override string NPCName => "Elder Sarah";
    
    public override string Description => "A wise elder who needs help with various tasks. Demonstrates quest integration.";
    
    private bool _hasActiveQuest = false;
    
    protected override void InitializeDialogue()
    {
        // Root dialogue
        var rootNode = new DialogueNode("root",
            "Hello, young one. Our village could use someone like you.");
        
        rootNode.Options.Add(new DialogueOption(
            "Do you need help with something?",
            "quest_check"
        ));
        
        rootNode.Options.Add(new DialogueOption(
            "Just passing through.",
            null
        ));
        
        Dialogue.AddNode(rootNode);
        
        // Quest check node
        var questCheckNode = new DialogueNode("quest_check",
            "As a matter of fact, yes. We've been having trouble with wolves near the village.");
        
        questCheckNode.Options.Add(new DialogueOption(
            "I can help with that.",
            "accept_quest",
            () => AcceptQuest()
        ));
        
        questCheckNode.Options.Add(new DialogueOption(
            "Sorry, I'm busy right now.",
            null
        ));
        
        Dialogue.AddNode(questCheckNode);
        
        // Accept quest node
        var acceptQuestNode = new DialogueNode("accept_quest",
            "Thank you! Deal with those wolves and return to me for your reward.");
        
        acceptQuestNode.Options.Add(new DialogueOption(
            "I'll take care of it.",
            null
        ));
        
        Dialogue.AddNode(acceptQuestNode);
    }
    
    private void AcceptQuest()
    {
        if (_hasActiveQuest)
        {
            MelonLoader.MelonLogger.Msg("You already have an active quest from Elder Sarah");
            return;
        }
        
        _hasActiveQuest = true;
        
        // This is where you would integrate with the QuestManager to start a quest
        MelonLoader.MelonLogger.Msg("Quest accepted: 'Wolf Problem' (QuestManager integration needed)");
        MelonLoader.MelonLogger.Msg("Objective: Defeat 5 wolves near the village");
    }
}
