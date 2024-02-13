using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapChipScripts : MonoBehaviour
{
    [SerializeField]
    private Image _targetChip;

    [SerializeField]
    private GameObject _mapChip;
    public static GameObject MapChipPrefab;

    private Vector3 _mapChipPos;
    public static Vector3 MapChipPos;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()
    {
        MapChipPrefab = _mapChip;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ポインタの画面表示
    public void MousePointIn()
    {
        Image TargetChip = _targetChip.gameObject.GetComponent<Image>();
        TargetChip.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        //_mapChipPos = TargetChip.transform.position;
        //Debug.Log(_mapChipPos);
    }

    //ポインタの画面非表示
    public void MousePointOut()
    {
        Image TargetChip = _targetChip.gameObject.GetComponent<Image>();
        TargetChip.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }


}
