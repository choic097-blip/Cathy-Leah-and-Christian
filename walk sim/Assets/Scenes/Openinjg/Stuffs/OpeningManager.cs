using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OpeningManager : MonoBehaviour
{
    [Header("UI Reference")]
    public Image fadeImage;
    public CanvasGroup UIInteractableGroup;

    [Header("Audio Reference")]
    public AudioSource effectSource; 
    public AudioSource bgmSource;    
    public float bgmFadeDuration = 1.5f; 

    void Start()
    {
        fadeImage.color = new Color(0, 0, 0, 1);
        UIInteractableGroup.interactable = false;
        UIInteractableGroup.blocksRaycasts = false; 
        bgmSource.volume = 0f; 

        StartCoroutine(StartSequence());
    }

    IEnumerator StartSequence()
    {
        effectSource.Play();

        float fadeTime = 2.0f; 
        float currentFadeTime = 0f;

        while (currentFadeTime < fadeTime)
        {
            currentFadeTime += Time.deltaTime;
            fadeImage.color = new Color(0, 0, 0, Mathf.Lerp(1f, 0f, currentFadeTime / fadeTime));
            yield return null;
        }

        bgmSource.Play();
        bgmSource.loop = true;
        
        UIInteractableGroup.interactable = true;
        UIInteractableGroup.blocksRaycasts = true; 

        yield return StartCoroutine(FadeInBGM());
        
        fadeImage.gameObject.SetActive(false); 
    }

    IEnumerator FadeInBGM()
    {
        float currentVolTime = 0f;

        while (currentVolTime < bgmFadeDuration)
        {
            currentVolTime += Time.deltaTime;
            bgmSource.volume = Mathf.Lerp(0f, 1f, currentVolTime / bgmFadeDuration);
            yield return null;
        }

        bgmSource.volume = 1f; 
    }
}