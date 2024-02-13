using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class FixedReflect : MonoBehaviour
{
    //�X�N���v�g
    public LaserScripts _laserScripts;

    //���[�U�[
    [SerializeField]
    private GameObject _laser;

    //���ˌ�
    [SerializeField]
    private Vector3 _nozzle;

    //�����蔻��
    [SerializeField]
    private CircleCollider2D _circleCollider2D;

    public int _rotate;
    public static int Rotate;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        //�Œ蔽�ˑ�̍쓮
        if (LaserScripts._reflection == true)
        {
                Debug.Log("EEE");

            for (int i = 0; i <= 0; i++)
            {
                Debug.Log("RRR");
                _circleCollider2D.isTrigger = false;
                Instantiate(_laser, transform.position + _nozzle, Quaternion.identity);
                LaserScripts._reflection = false;
            }
        }

        //���[�U�[���������甭�˂���
        if(_circleCollider2D.isTrigger == false)
        {
            StartCoroutine(DelayCoroutine(5f, () =>
            {
                _circleCollider2D.isTrigger = true;
            }));
        }
    }

    private IEnumerator DelayCoroutine(float seconds, Action action)
    {
        yield return new WaitForSeconds(seconds);
        action?.Invoke();
    }
}
