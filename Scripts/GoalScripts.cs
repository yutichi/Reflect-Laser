using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScripts : MonoBehaviour
{
    [SerializeField]
    private GameObject _clearPanel;

    // Start is called before the first frame update
    void Start()
    {
        _clearPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //ƒS[ƒ‹”»’è
        if(LaserScripts._goal == true) 
        {
            StartCoroutine(DelayCoroutine(1.1f, () =>
            {
                _clearPanel.SetActive(true);
                Time.timeScale = 0;
            }));
        }
    }

    private IEnumerator DelayCoroutine(float seconds, Action action)
    {
        yield return new WaitForSeconds(seconds);
        action?.Invoke();
    }
}
