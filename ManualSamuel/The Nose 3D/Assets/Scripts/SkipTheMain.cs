using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipTheMain : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Lobby");
            
              SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.spaceKey);
        }
    }
}
