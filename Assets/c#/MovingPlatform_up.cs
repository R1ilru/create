using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform_up : MonoBehaviour
{
    public float moveRange = 2f;   // 上下に動く幅
    public float speed = 2f;       // 移動スピード

    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float y = Mathf.Sin(Time.time * speed) * moveRange;
        transform.position = startPos + new Vector3(0, y, 0);
    }
}
