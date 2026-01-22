using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float offsetY = 5f;
    public float smooth = 3f;

    float maxY;

    void Start()
    {
        maxY = transform.position.y;
    }

    void LateUpdate()
    {
        float targetY = player.position.y + offsetY;

        // š ‰º‚É–ß‚ç‚È‚¢
        if (targetY > maxY)
        {
            maxY = targetY;
        }

        Vector3 targetPos = new Vector3(
            player.position.x,
            maxY,
            transform.position.z
        );

        transform.position = Vector3.Lerp(
            transform.position,
            targetPos,
            smooth * Time.deltaTime
        );
    }
}
