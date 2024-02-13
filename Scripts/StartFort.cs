using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFort : MonoBehaviour
{
    //���[�U�[
    [SerializeField]
    private GameObject _laser;

    //���[�U�[�̔��ˈʒu
    [SerializeField]
    private Vector3 _nozzle;

    private bool _shotTrigger = false;

    private Vector3 clickPosition;

    public AudioClip _startSound;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _nozzle = transform.Find("StartFortNozzle").localPosition;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //�E�N���b�N�Ń��[�U�[����
        if (Input.GetMouseButtonDown(1) && _shotTrigger == false) 
        {
            Instantiate(_laser, transform.position + _nozzle, Quaternion.identity);

            _shotTrigger = true;
            audioSource.PlayOneShot(_startSound);
        }
    }
}
