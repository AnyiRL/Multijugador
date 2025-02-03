using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtomFunctions : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadFlappyScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);    
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
