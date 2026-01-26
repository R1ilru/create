using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float offsetY = 5f;
    public float smooth = 3f;

    float maxY;
    float fixedX;

    void Start()
    {
        maxY = transform.position.y;
        fixedX = transform.position.x; // Åö èâä˙XÇå≈íË
    }

    void LateUpdate()
    {
        float targetY = player.position.y + offsetY;

        // â∫Ç…ñﬂÇÁÇ»Ç¢
        if (targetY > maxY)
        {
            maxY = targetY;
        }

        Vector3 targetPos = new Vector3(
            fixedX,          // Åö ç∂âEÇÕå≈íË
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
