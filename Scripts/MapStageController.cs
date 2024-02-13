using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapStageController : MonoBehaviour
{
    public FadeScripts _fadeScripts;

    //��
    [SerializeField]
    private GameObject _mirrorL, _mirrorR;

    //�|�[�Y���
    [SerializeField]
    private GameObject _pausePanel;

    //�N���A���
    public GameObject _clearPanel;

    private Vector3 clickPosition;

    private bool Left, Right;
    private bool _menuTrigger;

    public AudioClip _buttonSound, _putSound;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        _fadeScripts.FadeInTrigger();

        Left = false;
        Right = false;

        _pausePanel.SetActive(false);
        _clearPanel.SetActive(false);

        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //���N���b�N�ŋ��o��(�N���b�N�����ꏊ)
        if (Input.GetMouseButtonDown(0) && Left == true 
                                        && _menuTrigger == false)
        {
            clickPosition = Input.mousePosition;
            clickPosition.z = 10f;
            Instantiate(_mirrorL, Camera.main.ScreenToWorldPoint(clickPosition), _mirrorL.transform.rotation, transform);
            audioSource.PlayOneShot(_putSound);
        }
        else if (Input.GetMouseButtonDown(0) && Right == true
                                             && _menuTrigger == false)
        {
            clickPosition = Input.mousePosition;
            clickPosition.z = 10f;
            Instantiate(_mirrorR, Camera.main.ScreenToWorldPoint(clickPosition), _mirrorR.transform.rotation);
            audioSource.PlayOneShot(_putSound);

        }
    }

    //���̑����ʂɃ|�C���^���������Ƃ��̔���
    public void MenuPointIn()
    {
        _menuTrigger = true;
    }

    //���̑����ʂ���|�C���^�����ꂽ���̔���
    public void MenuPointOut()
    {
        _menuTrigger = false;
    }

    //�g�����̑I��(��)
    public void LeftMirror()
    {
        Left = true;
        Right = false;
    }

    //�g�����̑I��(�E)
    public void RightMirror()
    {
        Left = false;
        Right = true;
    }

    //�|�[�Y���
    public void PauseButton()
    {
        audioSource.PlayOneShot(_buttonSound);
        Time.timeScale = 0;
        _pausePanel.SetActive(true);
    }

    //���̃X�e�[�W
    public void NextStage(int Num)
    {
        _fadeScripts.FadeOutLoadTrigger();
        audioSource.PlayOneShot(_buttonSound);
        LaserScripts._goal = false;


        StartCoroutine(DelayCoroutine(1.5f, () =>
        {
            SceneManager.LoadScene(Num + 2);
        }));
    }

    //�ĊJ
    public void Continue()
    {

        audioSource.PlayOneShot(_buttonSound);
        Time.timeScale = 1;
        _pausePanel.SetActive(false);
    }

    //���X�^�[�g
    public void Restart()
    {
        LaserScripts._goal = false;
        audioSource.PlayOneShot(_buttonSound);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //�^�C�g���ɖ߂�
    public void BackTitle()
    {
        LaserScripts._goal = false;
        audioSource.PlayOneShot(_buttonSound);

        SceneManager.LoadScene(0);
    }

    private IEnumerator DelayCoroutine(float seconds, Action action)
    {
        yield return new WaitForSeconds(seconds);
        action?.Invoke();
    }
}
