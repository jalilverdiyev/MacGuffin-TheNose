using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHeartArm : MonoBehaviour
{
    public GameObject deathPanel;
    private Animator animator;
    private bool isGrounded = true;
    public float breathDuration = 10.0f; // Nefes alma vaxti (10 saniye)
    public float HurtDuration = 3.0f;
    private float breathTimer = 0.0f;
    private float StandUpTimer = 5.0f;
    public GameObject deathPanel2;

    void Start()
    {
        deathPanel.SetActive(false);
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetBool("isGrounded", isGrounded);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Q tuşuna basıldı, nefes almayı yeniden başlat
            breathTimer--;
            // Animator Controller'daki QPressed şartını true olarak ayarlayarak geç
            animator.SetBool("QPressed", true);
            Debug.Log("!!!!!!!!!!!!!!!!!!!!");
        }
        else
        {
            // Q tuşuna basılmadı, zamanı artır
            breathTimer += Time.deltaTime;
            // Məlum bir vaxt boyunca nefes alınmazsa animasyonu oynat
            if (breathTimer >= HurtDuration)
            {
                animator.SetBool("QPressed", false);
                deathPanel.SetActive(true);
                animator.SetBool("NefesKesilmesi", true); // "NefesKesilmesi" trigger'ını etkinleştir
                animator.SetBool("isWalking", false);
                animator.SetBool("isIdle", false);
                
            }
            else
            {
                animator.SetBool("NefesKesilmesi", false); // "NefesKesilmesi" trigger'ını bagliyir
                animator.SetBool("isIdle", true);
            }
            if (breathTimer >= breathDuration)
            {
                animator.SetBool("isDie", true);
                deathPanel.SetActive(true);
                animator.SetBool("QPressed", false);
                deathPanel.SetActive(true);
                deathPanel2.gameObject.SetActive(true);
                Time.timeScale = 0f;
                
            }
            else
            {
                animator.SetBool("isDie", false);
                animator.SetBool("isIdle", true);
                deathPanel2.SetActive(true);
                Time.timeScale = 1f;
            }


            // Kalan vaxti Console'a yazdır
            int remainingTime = Mathf.CeilToInt(breathDuration - breathTimer);
            Debug.Log("Qalan Vaxt: " + remainingTime.ToString("0.00") + " saniye");
        }
    }
}
