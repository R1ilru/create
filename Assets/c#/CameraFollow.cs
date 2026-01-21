using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float offsetY = 5f;

    float maxY;

    void Start()
    {
        maxY = transform.position.y;
    }

    public float smooth = 3f;

    void LateUpdate()
    {
        Vector3 targetPos = new Vector3(
            player.position.x,
            player.position.y + offsetY,
            transform.position.z
        );

        transform.position = Vector3.Lerp(
            transform.position,
            targetPos,
            smooth * Time.deltaTime
        );
    }
}
