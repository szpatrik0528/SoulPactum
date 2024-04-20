using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Finish : MonoBehaviour
{
  public collect collect;
  private AudioSource finishSound;
  private bool kszenvan = false;
  
      
  private void Start()
  {
    finishSound = GetComponent<AudioSource>();
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.name == "Player" && !kszenvan)
    {
      collect.SetScore();
      UnlockNewLevel();
      finishSound.Play();
      kszenvan = true;
      Invoke("CompleteLevel", 2f);
    }
  }
  public void CompleteLevel()
  {
    SceneManager.LoadSceneAsync("Start Menu");
    SceneManager.LoadSceneAsync("LevelSelect");
    kszenvan = false;
  }
  void UnlockNewLevel()
  {
    int szint = PlayerPrefs.GetInt("UnlockedLevels");
    if (szint <= SceneManager.GetActiveScene().buildIndex - 3)
    {
      szint++;
    }
    PlayerPrefs.SetInt("UnlockedLevels", szint);
    PlayerPrefs.SetString("ReachedIndex", szint.ToString());
    PlayerPrefs.Save();
    Debug.Log("A szint frissül a végén: " + szint);
  }
}
