using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    public void TryAgain()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void QuiTheGame()
    {
        Application.Quit();
    }


}
