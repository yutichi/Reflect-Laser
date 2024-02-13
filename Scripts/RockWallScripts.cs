using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockWallScripts : MonoBehaviour
{
    //初速(タイミングが決まる)
    [SerializeField]
    private float _firstTimmer;

    //消える壁(見た目)
    [SerializeField]
    private SpriteRenderer _rockWall;

    //消える壁(判定)
    [SerializeField]
    private BoxCollider2D _boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        _rockWall.enabled = false;
        _boxCollider.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        _firstTimmer += Time.deltaTime;

        if (_firstTimmer >= 5)
        {
            _rockWall.enabled = true;
            _boxCollider.isTrigger = false;

            StartCoroutine(DelayCoroutine(1, () =>
            {
                _firstTimmer = 0;
                _rockWall.enabled = false;
                _boxCollider.isTrigger = true;
            }));
        }
    }

    private IEnumerator DelayCoroutine(float seconds, Action action)
    {
        yield return new WaitForSeconds(seconds);
        action?.Invoke();
    }
}
