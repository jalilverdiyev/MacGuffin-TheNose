using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroytheCamera : MonoBehaviour
{
    private void Awake()
   {
     Camera[] cameras= FindObjectsOfType<Camera>();
     if(cameras.Length > 1)
     {
       Destroy(cameras[1].gameObject);
     }
   }
}
