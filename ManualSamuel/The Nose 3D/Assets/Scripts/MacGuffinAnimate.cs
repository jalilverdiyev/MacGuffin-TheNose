using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MacGuffinAnimate : MonoBehaviour
{
    public float waitPeriod = 3f;          
          
   
    void Start()
    {
        StartCoroutine(Wait());
        
    }
 
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitPeriod);
        SceneManager.LoadSceneAsync("LoadingScene");
    }  

 
     

   
}
