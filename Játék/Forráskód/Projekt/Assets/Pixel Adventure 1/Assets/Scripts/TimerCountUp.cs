using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountUp : MonoBehaviour
{
    public int score = 0;
    public int scoreMin = 0;
    public bool finished = false;
    public Text scoreText;

    public void Start()
    {
        StartCoroutine(time());
    }

    IEnumerator time()
    {
        while (finished==false)
        {
            timeCount();
            yield return new WaitForSeconds(1);
        }
    }

    void timeCount()
    {
        score += 1;
        if (score%60==0 && score!=0)
        {
            score = 0;
            scoreMin += 1;
        }
        
        scoreText.text = scoreMin.ToString()+ ":" + score.ToString("00");
          
    }
    void endTimeCount()
    {
        finished = true;
        PlayerPrefs.SetString("Finishtime", scoreText.text);
    }  
}
