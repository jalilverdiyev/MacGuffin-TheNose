using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform target; // Takip edilecek nesne (örneğin karakter)
    public float smoothSpeed = 5f; // Takip hızı

    private void LateUpdate()
    {
        if (target != null)
        {
            // Kameranın hedefi takip etmesi
            Vector3 newPosition = target.position;
            newPosition.z = transform.position.z; // Karakterin z ekseni pozisyonunu koru (2D için)
            transform.position = Vector3.Lerp(transform.position, newPosition, smoothSpeed * Time.deltaTime);
        }
    }
}
