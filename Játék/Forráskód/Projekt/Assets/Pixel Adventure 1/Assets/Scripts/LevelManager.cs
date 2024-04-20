using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button[] buttons;

    private void Start()
    {
        int unlockedLevels = PlayerPrefs.GetInt("UnlockedLevels");

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
       
        for (int i = 0; i < unlockedLevels+1; i++)
        {

            buttons[i].interactable = true;

        }
    }
}