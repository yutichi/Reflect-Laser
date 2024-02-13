using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorScripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // 当たったのがプレイヤーの弾
        if (other.gameObject.CompareTag("player_bullet"))
        {
            // 自身を消す
            Destroy(gameObject);

            // 弾も消す
            Destroy(other.gameObject);
        }
    }
}
