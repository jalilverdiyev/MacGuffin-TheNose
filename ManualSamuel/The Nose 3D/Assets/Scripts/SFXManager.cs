using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SFXManager : MonoBehaviour
{
    public AudioSource Audio;

    public AudioClip spaceKey;
    public AudioClip OnPointer;
    public AudioClip playClicked;
    public AudioClip optionsClicked;
    public AudioClip exitFromOptions;
    public AudioClip setVolumes;
    public AudioClip setQuality;
    public AudioClip setResolution;
    public AudioClip fullScreen;

   
   public static SFXManager sfxInstance;

    private void Awake()
    {   
       if(sfxInstance !=null && sfxInstance !=this)
       {
          Destroy(this.gameObject);
          return;
       }
        sfxInstance = this;
        DontDestroyOnLoad(this);
    }
}
