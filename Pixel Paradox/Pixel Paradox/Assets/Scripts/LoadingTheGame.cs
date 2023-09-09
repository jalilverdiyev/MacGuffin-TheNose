using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingTheGame : MonoBehaviour
{
    public Slider progressBar;

    public string[] scenesToLoad; // Add the names of your scenes to load here
    private int currentSceneIndex = 0;
    private AsyncOperation asyncOperation;

    private void Start()
    {
        progressBar.value = 0f;
        LoadSceneAsync(scenesToLoad[currentSceneIndex]);
    }

    private void LoadSceneAsync(string sceneName)
    {
        asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        asyncOperation.allowSceneActivation = false;

        // Ensure the progress bar updates while the scene loads.
        StartCoroutine(UpdateProgressBar());
    }
      public IEnumerator DelayedLoadNextScene()
    {
        yield return new WaitForSeconds(3f); // Delay for 3 seconds
        LoadNextScene();
    }

    private IEnumerator UpdateProgressBar()
    {
        while (!asyncOperation.isDone)
        {
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f); // Divide by 0.9 to reach 100%
            progressBar.value = progress;

            if (progress >= 0.9f)
            {
                // Loading is almost complete. You can now allow scene activation.
                asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }

  

    public void LoadNextScene()
    {
        if (currentSceneIndex < scenesToLoad.Length - 1)
        {
            currentSceneIndex++;
            progressBar.value = 0f;
            UnloadPreviousScene(); // Unload the previous scene if needed.
            LoadSceneAsync(scenesToLoad[currentSceneIndex]);
        }
    }

    private void UnloadPreviousScene()
    {
        // You can add code here to unload the previous scene if needed.
        // Use SceneManager.UnloadSceneAsync.
        // Example: SceneManager.UnloadSceneAsync(scenesToLoad[currentSceneIndex - 1]);
    }
}
