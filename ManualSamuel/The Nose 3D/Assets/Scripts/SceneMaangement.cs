using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneMaangement : MonoBehaviour
{ 
//Pause Menu Inputs
     public Button restartButton;
     public Button resumeButton;
     public Button quitButton;
     public GameObject optionsMenu;
     public Button exitButton;
     public GameObject pauseButtonOBJ;
     public GameObject pauseMenu;
     public Button pauseButton;
     public Button exitForMain;
//Lobby Scene Inputs
     public Button loadGameButton;
     public Button optionsButton;   
//These are keys to control the buttons(will ease the difficulty while changing into joystick mechanics)
  private void Update()
  {
    //To start the story mode
   if(Input.GetKeyDown(KeyCode.E))
   {
    loadGameButton.onClick.Invoke();
   }
    //To open the options menu
   if(Input.GetKeyDown(KeyCode.T))
   {
    optionsButton.onClick.Invoke();
   }
   //To pause the game
    if(Input.GetKeyDown(KeyCode.Escape))
   {
    pauseButton.onClick.Invoke();
   }
   //To resume the game
    if(Input.GetKeyDown(KeyCode.R))
   {
    resumeButton.onClick.Invoke();
   }
   //To restart the game
   if(Input.GetKeyDown(KeyCode.M))
   {
    restartButton.onClick.Invoke();
   }
   //To kill the options menu 
   if(Input.GetKeyDown(KeyCode.A))
   {
    exitButton.onClick.Invoke();
   }   
   //To quit the game
   if(Input.GetKeyDown(KeyCode.B))
   {
    quitButton.onClick.Invoke();
   }
   //To open the options menu in the main level
   if(Input.GetKeyDown(KeyCode.P))
   {
    optionsButton.onClick.Invoke();
   }
   //To kill the options menu in the main level
    if(Input.GetKeyDown(KeyCode.K))
   {
    exitForMain.onClick.Invoke();
   }
   
   

  }

//Scene management and loading
  public void LoadScene()
  {
     SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.playClicked);
    SceneManager.LoadScene("Main Level");
   
  }

//Options Menu Activation & Deactivation
  public void Options()
  {
   optionsMenu.gameObject.SetActive(true);
   SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.optionsClicked);
  }
  public void OptionsExit()
  {
    optionsMenu.gameObject.SetActive(false);
    SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.exitFromOptions);
  }

  //Pause Menu and its control
    public void PauseMenu()
    {
      Time.timeScale = 0f;
      pauseMenu.gameObject.SetActive(true);
      pauseButtonOBJ.gameObject.SetActive(false);
    }
    public void ResumeButton()
    {
     Time.timeScale = 1f;
     pauseMenu.gameObject.SetActive(false);
     pauseButtonOBJ.gameObject.SetActive(true);
    }
    public void RestartButton()
    {
      SceneManager.LoadScene("MainGame");
    }
    public void Exit()
    {
      SceneManager.LoadScene("Lobby");
    }
    public void ExitForMain()
    {
      optionsMenu.gameObject.SetActive(false);
    }

    //The end

   
}

