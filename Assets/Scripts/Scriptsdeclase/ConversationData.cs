using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationLine
{
    public string characterName;
    public string dialogue;
}
[CreateAssetMenu(fileName = "New Conversation", menuName = "Dialogue/Conversation Data")]
public class ConversationData : ScriptableObject
{
    public List<ConversationLine> lines = new List<ConversationLine>();
}
