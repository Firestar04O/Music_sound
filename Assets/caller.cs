using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caller : MonoBehaviour
{
    void Update()
    {
        SceneController.Instance.CallFadeTransition();
    }
}
