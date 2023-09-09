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
      SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.setVolumes);
     
    }
      public void SetSFXVolume(float volume)
    {
      
      sfxMixer.SetFloat("sfx", volume);
       SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.setVolumes);
    }
      public void SetNarratorVolume(float volume)
    {
      
      voiceMixer.SetFloat("narrator", volume);
        SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.setVolumes);
     
    }
      public void SetQuality(int qualityIndex)
    {
      QualitySettings.SetQualityLevel(qualityIndex);
        SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.setQuality);
  
    }
      public void SetFullScreen(bool isFullscreen)
    {
    Screen.fullScreen = isFullscreen;
      SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.fullScreen);
    
    }
      public void SetResolution(int resolutionIndex )
    {
         Resolution resolution = resolutions[resolutionIndex];
       Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
         SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.setResolution);
    }
}
