namespace Schedule1EnhancedMod.NPCs;

/// <summary>
/// Dialogue system for NPCs
/// Manages conversation trees and player choices
/// </summary>
public class DialogueSystem
{
    private readonly CustomNPC _npc;
    private readonly Dictionary<string, DialogueNode> _dialogueNodes = new();
    private DialogueNode? _currentNode;
    
    public DialogueSystem(CustomNPC npc)
    {
        _npc = npc;
    }
    
    /// <summary>
    /// Add a dialogue node to the system
    /// </summary>
    public void AddNode(DialogueNode node)
    {
        _dialogueNodes[node.Id] = node;
    }
    
    /// <summary>
    /// Start the dialogue from the root node
    /// </summary>
    public void StartDialogue(string? startNodeId = null)
    {
        var nodeId = startNodeId ?? "root";
        
        if (!_dialogueNodes.TryGetValue(nodeId, out var node))
        {
            MelonLoader.MelonLogger.Error($"Dialogue node '{nodeId}' not found for NPC {_npc.NPCName}");
            return;
        }
        
        _currentNode = node;
        ShowCurrentNode();
    }
    
    /// <summary>
    /// Choose a response option
    /// </summary>
    public void ChooseOption(int optionIndex)
    {
        if (_currentNode == null || optionIndex < 0 || optionIndex >= _currentNode.Options.Count)
        {
            return;
        }
        
        var option = _currentNode.Options[optionIndex];
        
        // Execute the option's action if any
        option.OnSelect?.Invoke();
        
        // Move to the next node
        if (!string.IsNullOrEmpty(option.NextNodeId))
        {
            StartDialogue(option.NextNodeId);
        }
        else
        {
            EndDialogue();
        }
    }
    
    /// <summary>
    /// Display the current dialogue node
    /// </summary>
    private void ShowCurrentNode()
    {
        if (_currentNode == null)
        {
            return;
        }
        
        MelonLoader.MelonLogger.Msg($"[{_npc.NPCName}]: {_currentNode.Text}");
        
        if (_currentNode.Options.Count > 0)
        {
            MelonLoader.MelonLogger.Msg("Response options:");
            for (int i = 0; i < _currentNode.Options.Count; i++)
            {
                MelonLoader.MelonLogger.Msg($"  {i + 1}. {_currentNode.Options[i].Text}");
            }
        }
    }
    
    /// <summary>
    /// End the current dialogue
    /// </summary>
    private void EndDialogue()
    {
        MelonLoader.MelonLogger.Msg($"Dialogue with {_npc.NPCName} ended");
        _currentNode = null;
    }
}

/// <summary>
/// Represents a single node in the dialogue tree
/// </summary>
public class DialogueNode
{
    /// <summary>
    /// Unique identifier for this node
    /// </summary>
    public string Id { get; set; }
    
    /// <summary>
    /// The text displayed to the player
    /// </summary>
    public string Text { get; set; }
    
    /// <summary>
    /// Player response options
    /// </summary>
    public List<DialogueOption> Options { get; set; } = new();
    
    public DialogueNode(string id, string text)
    {
        Id = id;
        Text = text;
    }
}

/// <summary>
/// Represents a player response option in dialogue
/// </summary>
public class DialogueOption
{
    /// <summary>
    /// The text shown to the player for this option
    /// </summary>
    public string Text { get; set; }
    
    /// <summary>
    /// The next dialogue node to show (null = end conversation)
    /// </summary>
    public string? NextNodeId { get; set; }
    
    /// <summary>
    /// Optional action to execute when this option is selected
    /// </summary>
    public Action? OnSelect { get; set; }
    
    public DialogueOption(string text, string? nextNodeId = null, Action? onSelect = null)
    {
        Text = text;
        NextNodeId = nextNodeId;
        OnSelect = onSelect;
    }
}
