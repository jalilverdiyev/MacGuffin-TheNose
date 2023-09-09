using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    Resolution[] resolutions;
    public AudioMixer musicMixer; 
     public AudioMixer sfxMixer; 
      public AudioMixer voiceMixer; 
    public TMP_Dropdown resolutionDropdown;
    void Start()
    {
       int currentResolutionIndex = 0;
      
       resolutions =  Screen.resolutions;
      
       resolutionDropdown.ClearOptions();
      
       List<string> options = new List<string>();
      
       for(int i = 0; i < resolutions.Length; i++)
     {
        string option = resolutions[i].width + "x" + resolutions[i].height;
        
        options.Add(option);
        
        if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
        {
            currentResolutionIndex = i;
        }
     
     }
      resolutionDropdown.AddOptions(options);
      resolutionDropdown.value = currentResolutionIndex;
      resolutionDropdown.RefreshShownValue();
    }
    
      public void SetMusicVolume(float volume)
    {
      
      musicMixer.SetFloat("music", volume);
     
    }
      public void SetSFXVolume(float volume)
    {
      
      sfxMixer.SetFloat("sfx", volume);
     
    }
      public void SetNarratorVolume(float volume)
    {
      
      voiceMixer.SetFloat("narrator", volume);
     
    }
      public void SetQuality(int qualityIndex)
    {
      QualitySettings.SetQualityLevel(qualityIndex);
  
    }
      public void SetFullScreen(bool isFullscreen)
    {
    Screen.fullScreen = isFullscreen;
    
    }
      public void SetResolution(int resolutionIndex )
    {
         Resolution resolution = resolutions[resolutionIndex];
       Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
