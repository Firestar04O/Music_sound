using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoomController : MonoBehaviour
{
    public UnityEvent OnEnterRoom;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnEnterRoom.Invoke();

            SceneController.Instance.CallFadeTransition();
        }
    }
}
