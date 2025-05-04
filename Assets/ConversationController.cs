using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using Unity.VisualScripting;

public class ConversationController : MonoBehaviour
{
    public TextMeshProUGUI nameField;
    public TextMeshProUGUI conversationField;
    public Canvas conversationPanel;

    public UnityEvent OnStartConversation;
    public UnityEvent OnFinishConversation;

    public ConversationData conversationAsset; 

    private int currentLine;
    public bool isInConversation;
    void Start()
    {
        currentLine = 0;
        isInConversation = false;
    }
    public void OnConversation(InputAction.CallbackContext context)
    {
        if (isInConversation && context.performed)
        {
            ShowNextLine();
        }
    }
    public void StartConversation()
    {
        if (conversationAsset == null || conversationAsset.lines.Count == 0)
            return;

        conversationPanel.gameObject.SetActive(true);
        currentLine = 0;
        isInConversation = true;

        OnStartConversation?.Invoke();
        ShowLine(conversationAsset.lines[currentLine]);
    }
    public void ShowNextLine()
    {
        currentLine++;

        if (currentLine >= conversationAsset.lines.Count)
        {
            EndConversation();
            return;
        }

        ShowLine(conversationAsset.lines[currentLine]);
    }

    public void ShowLine(ConversationLine line)
    {
        nameField.text = line.characterName;
        conversationField.text = line.dialogue;
    }

    public void EndConversation()
    {
        isInConversation = false;
        conversationPanel.gameObject.SetActive(false);
        OnFinishConversation?.Invoke();
    }
}
