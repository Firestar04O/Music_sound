using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerControl : MonoBehaviour
{
    public string ScenaryToGo;
    private void OnEnable()
    {
        Player.OnChange += ChangeScenery;
    }
    private void OnDisable()
    {
        Player.OnChange -= ChangeScenery;
    }
    public void ChangeScenery()
    {
        SceneManager.LoadScene(ScenaryToGo);
    }
}
