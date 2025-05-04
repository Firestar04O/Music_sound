using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance { get; private set; }
    [SerializeField] private Image FadeImage;
    [SerializeField] private Color FadeInColor;
    [SerializeField] private float FadeInTime;
    [SerializeField] private Color FadeOutColor;
    [SerializeField] private float FadeOutTime;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        CallFadeIn();
    }
    public void CallFadeIn()
    {
        StartCoroutine(FadeTransition(FadeInTime, FadeOutColor, FadeInColor));
    }
    public void CallFadeTransition()
    {
        StartCoroutine(FadeTransition(FadeOutTime, FadeInColor, FadeOutColor));
        StartCoroutine(FadeTransition(FadeInTime, FadeOutColor, FadeInColor, FadeOutTime * 1.25f));
    }
    IEnumerator FadeTransition(float fadeTime, Color currentColor, Color targetColor, float waitTime = 0f)
    {
        yield return new WaitForSeconds(waitTime);
        float _time = 0;
        FadeImage.color = currentColor;
        while (_time < fadeTime)
        {
            _time += Time.deltaTime;
            float _value = _time / fadeTime;
            FadeImage.color = Color.Lerp(currentColor, targetColor, _value);
            yield return null;
        }
        FadeImage.color = targetColor;
    }
}
