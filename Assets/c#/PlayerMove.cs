using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;

    [Header("Jump")]
    public float jumpForce = 6f;
    public float gravityScale = 0.5f;
    public bool isGrounded;

    [Header("Death")]
    public float fallLimit = 5f;   // これ以上落ちたら死ぬ
    float maxHeightY;

    bool isDead = false;


    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;

        maxHeightY = transform.position.y;
    }

    void Update()
    {
        if (isDead)
        {
            // ★ 死亡後 Enter でリザルト
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("SceneResult");
            }
            return;
        }

        // ジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.1f)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // 最高到達高度更新
        if (transform.position.y > maxHeightY)
        {
            maxHeightY = transform.position.y;
        }

        // 落下死亡判定
        if (transform.position.y < maxHeightY - fallLimit)
        {
            Die();
        }
    }

    void FixedUpdate()
    {
        if (isDead) return;

        float h = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(h * speed, rb.velocity.y, rb.velocity.z);

        rb.AddForce(Physics.gravity * gravityScale, ForceMode.Acceleration);

        if (isGrounded && rb.velocity.y < 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, -0.5f, rb.velocity.z);
        }
    }

    // 接地中ずっと呼ばれる
    void OnCollisionStay(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground")) return;

        // 「下から当たっているか」をチェック
        foreach (ContactPoint contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                isGrounded = true;
                return;
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }



    void Die()
    {
        if (isDead) return;

        isDead = true;

        // ★ 高度スコア保存
        GameData.maxHeight = maxHeightY;

        rb.velocity = Vector3.zero;
    }



















}