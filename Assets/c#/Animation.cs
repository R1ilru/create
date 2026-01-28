using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;

    public float moveSpeed = 5f;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");

        // 横移動
        rb.velocity = new Vector3(h * moveSpeed, rb.velocity.y, rb.velocity.z);

        // Blend Tree
        animator.SetFloat("Speed", Mathf.Abs(h));

        // 向き変更（左右反転）
        if (h > 0.01f)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (h < -0.01f)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
    }
}


