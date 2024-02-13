using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TimmerScripts : MonoBehaviour
{
    [SerializeField]
    private int minute;
    [SerializeField]
    private float seconds;

    //�O��Update�̎��̕b��
    private float oldSeconds;
    //�^�C�}�[�\���p�e�L�X�g
    private Text timerText;

    void Start()
    {
        minute = 0;
        seconds = 0f;
        oldSeconds = 0f;
        timerText = GetComponentInChildren<Text>();
    }

    void Update()
    {
        //�^�C�}�[
        seconds += Time.deltaTime;
        if (seconds >= 60f)
        {
            minute++;
            seconds = seconds - 60;
        }
        if ((int)seconds != (int)oldSeconds)
        {
            timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
        }
        oldSeconds = seconds;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            minute = 0;
            seconds = 0f;
            oldSeconds = 0f;
            timerText = GetComponentInChildren<Text>();
        }
    }

    //�^�C�}�[���Z�b�g
    public void Retry()
    {
            minute = 0;
            seconds = 0f;
            oldSeconds = 0f;
            timerText = GetComponentInChildren<Text>();
    }
}
