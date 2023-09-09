using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerController : MonoBehaviour
{
    Animator animator;
    public float breathDuration = 10.0f; // Nefes alma vaxti (10 saniye)
    private float breathTimer = 0.0f;
    // Karakterin nefes alıp almadığını kontrol etmek üçün

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKey("w"))
        {
            animator.SetBool("isWalking", true);
            if (breathTimer <= breathDuration)
            {
                animator.SetBool("NefesKesilmesi", false); 

            }
            else
            {
                animator.SetBool("NefesKesilmesi", true);

            }

        }
        else
            animator.SetBool("isWalking", false);
            //animator.SetBool("NefesKesilmesi", false);
            



        // Animator Controller'daki QPressed şərtini true olarak ayarlayarak geç
        animator.SetBool("QPressed", true);


        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Q tuşuna basıldı, nefes almayı yeniden başlat
            breathTimer = 0.0f;
            Debug.Log("Q isliyir");
            // Animator Controller'daki QPressed şartını true olarak ayarlayarak geç
            animator.SetBool("QPressed", true);
        }
        else
        {
            // Q tuşuna basılmadı, zamanı artır
            breathTimer += Time.deltaTime;

            // Məlum bir vaxt boyunca nefes alınmazsa animasyonu oynat
            if (breathTimer >= breathDuration)
            {
                animator.SetBool("NefesKesilmesi",true); // "NefesKesilmesi" trigger'ını etkinleştir

                // Animator Controller'daki QPressed şartını false olarak ayarlayarak geçişi ləğv et
                animator.SetBool("QPressed", false);
            }

            // Kalan vaxti Console'a yazdır
            int remainingTime = Mathf.CeilToInt(breathDuration - breathTimer);
            Debug.Log("Kalan Vaxt: " + remainingTime.ToString("0.00") + " saniye");
        }


    }

    
}
