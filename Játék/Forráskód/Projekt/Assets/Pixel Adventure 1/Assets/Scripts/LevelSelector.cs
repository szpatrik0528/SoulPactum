using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public int level;
    void Start()
    {
    }

    public void OpenScene()
    {
        SceneManager.LoadScene("Level " + level.ToString());
    }
    public void OpenEnd()
    {
        SceneManager.LoadScene("end");
    }
    
}
