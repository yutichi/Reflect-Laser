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
        // ���������̂��v���C���[�̒e
        if (other.gameObject.CompareTag("player_bullet"))
        {
            // ���g������
            Destroy(gameObject);

            // �e������
            Destroy(other.gameObject);
        }
    }
}
