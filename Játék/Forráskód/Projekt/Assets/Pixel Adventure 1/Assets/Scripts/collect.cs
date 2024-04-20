using System.Net.Mime;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collect : MonoBehaviour
{
    public int cherries = 0;
    public string cherriessz;

    [SerializeField] private AudioSource collectSoundEffect;
    [SerializeField] private Text pontszam;

    void Start()
    {
        LoadScore();
        pontszam.text = "Pontszám: " + cherries;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collectSoundEffect.Play();
        if (collision.gameObject.CompareTag("cseresznye"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            cherries+=10;
            
            pontszam.text = "Pontszám: " + cherries;
        }
        else if (collision.gameObject.CompareTag("dinnye"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            cherries+=100;
            
            pontszam.text = "Pontszám: " + cherries;
        }
        else if (collision.gameObject.CompareTag("kiwi"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            cherries+=50;
            
            pontszam.text = "Pontszám: " + cherries;
        }

    }
     public void SetScore()
    {
        cherriessz = cherries.ToString();
        PlayerPrefs.SetString("pont", cherriessz);
    }
    private void LoadScore()
    {
        cherries = int.Parse(PlayerPrefs.GetString("pont"));
    }
}

