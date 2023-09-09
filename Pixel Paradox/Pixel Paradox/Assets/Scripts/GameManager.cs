using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
       public static GameManager instance;
    public CanvasGroup mainMenu;
   
    private void Awake(){
    {
    instance = this;
   }
   
   }
   void FixedUpdate()
   {

         mainMenu.alpha += Time.deltaTime;
        
       }
      
}
