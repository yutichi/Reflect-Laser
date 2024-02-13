using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeScripts : MonoBehaviour
{
    public Image fadePanel;            
    public float fadeDuration = 1.0f;   

    public static Image FadePanel;
    public static float FadeDuration;

    void Awake()
    {
        FadeDuration = fadeDuration;
        FadePanel = fadePanel;
    }


    //フェードアウト実行
    public void FadeOutTrigger()
    {
        StartCoroutine(FadeOut());
    }

    //フェードイン実行
    public void FadeInTrigger()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeOutLoadTrigger()
    {
        StartCoroutine(FadeOutLoading());
    }

    public void FadeInLoadTrigger()
    {
        StartCoroutine(FadeInLoading());
    }

    public static IEnumerator FadeOut()
    {
        FadePanel.enabled = true;                 
        float elapsedTime = 0.0f;                 
        Color startColor = FadePanel.color;       
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f); 

        // フェードアウトアニメーションを実行
        while (elapsedTime < FadeDuration)
        {
            elapsedTime += Time.deltaTime;                        
            float t = Mathf.Clamp01(elapsedTime / FadeDuration);  
            FadePanel.color = Color.Lerp(startColor, endColor, t); 
            yield return null;                                     
        }

        FadePanel.color = endColor;  
        FadePanel.enabled = false;   
    }

    public static IEnumerator FadeIn()
    {
        FadePanel.enabled = true;                
        float elapsedTime = 0.0f;                 
        Color startColor = FadePanel.color;       
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0.0f); 

        // フェードアウトアニメーションを実行
        while (elapsedTime < FadeDuration)
        {
            elapsedTime += Time.deltaTime;                        
            float t = Mathf.Clamp01(elapsedTime / FadeDuration);  
            FadePanel.color = Color.Lerp(startColor, endColor, t); 
            yield return null;                                     
        }

        FadePanel.color = endColor;  
        FadePanel.enabled = false;　 
    }

    public static IEnumerator FadeOutLoading()
    {
        FadePanel.enabled = true;                 
        float elapsedTime = 0.0f;                 
        Color startColor = FadePanel.color;       
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f); 

        // フェードアウトアニメーションを実行
        while (elapsedTime < FadeDuration)
        {
            elapsedTime += Time.deltaTime;                     
            float t = Mathf.Clamp01(elapsedTime / FadeDuration);  
            FadePanel.color = Color.Lerp(startColor, endColor, t); 
            yield return null;                                    
        }

        FadePanel.color = endColor;  
    }

    public static IEnumerator FadeInLoading()
    {
        FadePanel.enabled = true;                 
        float elapsedTime = 0.0f;               
        Color startColor = FadePanel.color;       
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0.0f); 

        while (elapsedTime < FadeDuration)
        {
            elapsedTime += Time.deltaTime;                        
            float t = Mathf.Clamp01(elapsedTime / FadeDuration);  
            FadePanel.color = Color.Lerp(startColor, endColor, t); 
            yield return null;                                     
        }

        FadePanel.color = endColor;  
    }
}
