using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        
        SceneManager.LoadSceneAsync("LevelSelect");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void BacktoMain()
    {
        SceneManager.LoadSceneAsync("Start Menu");
    }
    public void StartLevel(string a)
    {
        SceneManager.LoadSceneAsync(a);
    }
}
