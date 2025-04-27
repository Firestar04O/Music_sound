using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject Gameplay;
    public GameObject Pausa;
    private void Awake()
    {
        Pausa.SetActive(false);
        Gameplay.SetActive(true);
    }
    public void ShowGameplay()
    {
        Pausa.SetActive(false);
        Gameplay.SetActive(true);
    }
    public void ShowPausePanel()
    {
        Pausa.SetActive(true);
        Gameplay.SetActive(false);
    }
}
