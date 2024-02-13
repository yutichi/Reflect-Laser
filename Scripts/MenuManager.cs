using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    //スクリプト
    public FadeScripts _fadeScripts;

    //タイトル
    [SerializeField]
    private GameObject _titleScene;

    //ステージ選択
    [SerializeField]
    private GameObject _stageSelect;

    //SE
    public AudioClip _buttonSound;
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        _fadeScripts.FadeInTrigger();
        
        _titleScene.SetActive(true);
        _stageSelect.SetActive(false);

        Time.timeScale = 1f;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ゲームスタートボタン
    public void StartButton()
    {
        _fadeScripts.FadeOutLoadTrigger();
        audioSource.PlayOneShot(_buttonSound);

        StartCoroutine(DelayCoroutine(1.5f, () =>
        {
            _fadeScripts.FadeInTrigger();
        }));

        StartCoroutine(DelayCoroutine(1.2f, () =>
        {
            _titleScene.SetActive(false);        
            _stageSelect.SetActive(true);
        }));
    }

    //ステージ選択ボタン
    public void StageSelectButton(int _stageNum)
    {
        _fadeScripts.FadeOutLoadTrigger();
        audioSource.PlayOneShot(_buttonSound);

        StartCoroutine(DelayCoroutine(1.5f, () =>
        {
            SceneManager.LoadScene(_stageNum + 1);
        }));
    }

    private IEnumerator DelayCoroutine(float seconds, Action action)
    {
        yield return new WaitForSeconds(seconds);
        action?.Invoke();
    }

}
