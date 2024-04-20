using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class halal : MonoBehaviour
{
    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private Text halalokszama;
    private int halalszam;
    private string halalszamsz;


    private Animator anim;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        LoadHalalScore();
        halalokszama.text = "Halál: " + halalszam;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            Die();
        }
    }
    private void Die()
    {
        //deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("halal");
        halalszam++;
        SetHalalScore();
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void SetHalalScore()
    {
        halalszamsz = halalszam.ToString();
        PlayerPrefs.SetString("halal", halalszamsz);
    }
    private void LoadHalalScore()
    {
        halalszam = int.Parse(PlayerPrefs.GetString("halal"));
    }
}