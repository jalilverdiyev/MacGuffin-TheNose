using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTest : MonoBehaviour
{
    public float moveSpeed = 5f; // Karakterin hareket hızı
    public float jumpForce = 7f; // Zıplama kuvveti
    private bool isGrounded = true; // Zeminde olup olmadığını kontrol eder
    private Rigidbody rb;
    private Animator animator;

    private float horizontalInput = 0f; // Yatay giriş

    public float maxBreathDuration = 10.0f; // Maksimum nefes alma süresi (10 saniye)
    public float hurtDurationThreshold = 3.0f; // Yaralanma eşik süresi
    private float breathTimer = 0.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey("w"))
        {
            moveZ = 1f; // Yukarı yönde hareket
            animator.SetBool("isWalking", true); // Yürüme animasyonunu etkinleştir
        }
        else if (Input.GetKey("s"))
        {
            moveZ = -1f; // Aşağı yönde hareket
            animator.SetBool("isWalking", true); // Yürüme animasyonunu etkinleştir
        }
        else if (Input.GetKey("a"))
        {
            moveX = -1f; // Sola yönde hareket
            animator.SetBool("isWalking", true); // Yürüme animasyonunu etkinleştir
            transform.localScale = new Vector3(-1, 1, 1); // Sağa dön
        }
        else if (Input.GetKey("d"))
        {
            moveX = 1f; // Sağa yönde hareket
            animator.SetBool("isWalking", true); // Yürüme animasyonunu etkinleştir
            transform.localScale = new Vector3(1, 1, 1); // Sağa dön
        }
        else
        {
            animator.SetBool("isWalking", false); // Hiçbir tuşa basılmadığında yürüme animasyonunu kapat
        }

        Vector3 movement = new Vector3(moveX, 0f, moveZ);
        movement.Normalize();

        rb.velocity = movement * moveSpeed;

        if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Sola dön
        }
        else if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Sağa dön
        }

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("moveSpeed", movement.magnitude);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            breathTimer = 0f;
            animator.SetBool("QPressed", true);
            Debug.Log("Nefes alındı!");
        }
        else
        {
            breathTimer += Time.deltaTime;

            if (breathTimer >= hurtDurationThreshold)
            {
                animator.SetBool("QPressed", false);
                animator.SetBool("NefesKesilmesi", true);
                animator.SetBool("isWalking", false);
                animator.SetBool("isIdle", false);
            }
            else
            {
                animator.SetBool("NefesKesilmesi", false);
            }

            if (breathTimer >= maxBreathDuration)
            {
                animator.SetBool("isDie", true);
                animator.SetBool("QPressed", false);
            }
            else
            {
                animator.SetBool("isDie", false);
            }

            int remainingTime = Mathf.Max(0, Mathf.CeilToInt(maxBreathDuration - breathTimer));
            Debug.Log("Kalan Süre: " + remainingTime.ToString() + " saniye");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
