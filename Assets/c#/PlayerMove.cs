using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;

    [Header("Jump")]
    public float jumpForce = 6f;
    public bool isGrounded;

    [Header("Death")]
    public float fallLimit = 5f;   // これ以上落ちたら死ぬ
    float maxHeightY;

    [Header("Warp")]
    public float leftLimitX = -5f;
    public float rightLimitX = 5f;

    bool isDead = false;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // ★ Unity標準の重力を使う（重要）
        rb.useGravity = true;

        // 回転で倒れないように
        rb.constraints = RigidbodyConstraints.FreezeRotationX |
                         RigidbodyConstraints.FreezeRotationZ;

        maxHeightY = transform.position.y;
    }

    void Update()
    {
        if (isDead)
        {
            // 死亡後 Enter でリザルト
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("SceneResult");
            }
            return;
        }

        // ジャンプ（接地中のみ）
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
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

        // 横移動のみ制御（Yは触らない）
        rb.velocity = new Vector3(h * speed, rb.velocity.y, rb.velocity.z);
    }

    // 接地判定
    void OnCollisionStay(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Ground")) return;

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

        // 高度スコア保存
        GameData.maxHeight = maxHeightY;

        rb.velocity = Vector3.zero;
    }

    void LateUpdate()
    {
        // 横ワープ処理
        Vector3 pos = transform.position;

        if (pos.x < leftLimitX)
            pos.x = rightLimitX;
        else if (pos.x > rightLimitX)
            pos.x = leftLimitX;

        transform.position = pos;
    }
}
