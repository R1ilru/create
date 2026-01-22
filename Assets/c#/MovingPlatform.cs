using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveRange = 2f;
    public float speed = 2f;

    float startX;
    float offset;

    void Start()
    {
        startX = transform.position.x;
        offset = Random.Range(0f, Mathf.PI * 2f);
    }

    void Update()
    {
        float x = startX + Mathf.Sin(Time.time * speed + offset) * moveRange;
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    // ★ プレイヤーが乗った
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    // ★ プレイヤーが降りた
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
