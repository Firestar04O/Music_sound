using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionEnabler : MonoBehaviour
{
    public InteractionController interactionController;
    public ConversationController conversationController;
    public ConversationData conversationAsset;

    public Transform player; // Asignado desde el inspector
    public float interactionDistance = 3f; // Distancia máxima para poder interactuar

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // o la tecla que uses para interactuar
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= interactionDistance)
            {
                conversationController.conversationAsset = conversationAsset;
                conversationController.StartConversation();
            }
            else
            {
                Debug.Log("Muy lejos para interactuar.");
            }
        }
    }
}
