using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    int currentSceneIndex;
    public void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadNextScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void ReplayTheScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void BackToMenu()
    {
        Destroy(FindObjectOfType<MusicPlayer>());
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
    }

    public void Quitgame()
    {
        Application.Quit();
    }
}
