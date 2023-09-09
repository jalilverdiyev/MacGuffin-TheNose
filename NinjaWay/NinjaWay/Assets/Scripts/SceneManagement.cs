using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{ 
    public GameObject optionsPanel;
    public void PlayGame()
   {
        
        SceneManager.LoadSceneAsync("Main Level");
        Time.timeScale = 1f;
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("You exitted the game");
    }
    public void OptionsPanel()
    {
        optionsPanel.gameObject.SetActive(true);
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
          SceneManager.LoadScene("Main Level");
          Time.timeScale = 1f;
        }

        
    }
}
