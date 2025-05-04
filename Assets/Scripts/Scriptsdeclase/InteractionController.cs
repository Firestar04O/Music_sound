using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public ConversationController conversationController;

    private void Update()
    {
        if (conversationController.isInConversation && Input.GetKeyDown(KeyCode.E))
        {
            conversationController.ShowNextLine();
        }
    }
}
