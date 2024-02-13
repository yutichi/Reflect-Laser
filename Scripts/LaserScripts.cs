using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class LaserScripts : MonoBehaviour
{
    //���[�U�[�̈ړ��֘A
    [SerializeField]
    private float _speedX, _speedY;

    private float SpeedX = 7.5f;
    private float SpeedY = 7.5f;

    public static bool _reflection;
    public static bool _goal;

    //SE
    public AudioClip _mirrorSound, _fixedSound, _wallSound, _goalSound;
    AudioSource audioSource;

    void Start()
    {
        _reflection = false;

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //���[�U�[�ړ�
        transform.Translate(_speedX * Time.deltaTime, _speedY * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //���˔�(��)
        if(collision.gameObject.CompareTag("MirrorL"))
        {
            if(_speedX > 0 && _speedY == 0) 
            {
                _speedX = 0;
                _speedY = SpeedY;
            }
            else if (_speedX < 0 && _speedY == 0)
            {
                _speedX = 0;
                _speedY = -SpeedY;
            }
            else if (_speedX == 0 && _speedY > 0)
            {
                _speedX = SpeedX;
                _speedY = 0;
            }
            else if (_speedX == 0 && _speedY < 0)
            {
                _speedX = -SpeedX;
                _speedY = 0;
            }

            audioSource.PlayOneShot(_mirrorSound);
        }

        //���˔�(�E)
        if (collision.gameObject.CompareTag("MirrorR"))
        {
            if (_speedX > 0 && _speedY == 0)
            {
                _speedX = 0;
                _speedY = -SpeedY;
            }
            else if (_speedX < 0 && _speedY == 0)
            {
                _speedX = 0;
                _speedY = SpeedY;
            }
            else if (_speedX == 0 && _speedY > 0)
            {
                _speedX = -SpeedX;
                _speedY = 0;
            }
            else if (_speedX == 0 && _speedY < 0)
            {
                _speedX = SpeedX;
                _speedY = 0;
            }

            audioSource.PlayOneShot(_mirrorSound);
        }

        //�Œ蔽�ˑ�
        if (collision.gameObject.CompareTag("Reflection"))
        {
            _speedX = 0;
            _speedY = 0;

            audioSource.PlayOneShot(_fixedSound);

            StartCoroutine(DelayCoroutine(1, () =>
            {
                _reflection = true;
                Debug.Log(_reflection);

                Destroy(this.gameObject);
            }));
        }

        //�S�[��
        if(collision.gameObject.CompareTag("Goal"))
        {
            _speedX = 0;
            _speedY = 0;
            audioSource.PlayOneShot(_goalSound);

            _goal = true;
        }

        //��
        if(collision.gameObject.CompareTag("Wall"))
        {
            audioSource.PlayOneShot(_wallSound);

            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�������
        if (collision.gameObject.CompareTag("RockWall"))
        {
            audioSource.PlayOneShot(_wallSound);

            Destroy(this.gameObject);
        }
    }

    private IEnumerator DelayCoroutine(float seconds, Action action)
    {
        yield return new WaitForSeconds(seconds);
        action?.Invoke();
    }
}
