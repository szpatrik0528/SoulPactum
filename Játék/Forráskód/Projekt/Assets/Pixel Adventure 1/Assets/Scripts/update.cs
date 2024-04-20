using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class update : MonoBehaviour
{
    public Text username;
    public Text id;
    public Text halal;
    public Text levels;
    public Text pont;
    public int pontszam;

    public string pontszamszoveg;
    public string halalszamszoveg;
    public string levelsszoveg;

    public string nev;
    public int halalszam;
    public int levelszam;
    public int skin;


    public Server server;

    public void Start()
    {
        // MásikSzkript

        username.text = PlayerPrefs.GetString("Lusername");
        nev = PlayerPrefs.GetString("Lusername");
        id.text = PlayerPrefs.GetString("id");

        pontszamszoveg = PlayerPrefs.GetString("pont");
        pontszam = int.Parse(PlayerPrefs.GetString("pont"));

        halalszamszoveg = PlayerPrefs.GetString("halal");
        halalszam = +int.Parse(PlayerPrefs.GetString("halal"));

        levelsszoveg = PlayerPrefs.GetString("ReachedIndex");
        levelszam = int.Parse(PlayerPrefs.GetString("ReachedIndex"));
        PlayerPrefs.SetInt("UnlockedLevels", levelszam);


        

        levels.text = "Szint: " + levelszam;
        pont.text = "Pontszám: " + pontszam;
        halal.text = "Halálok: " + halalszam;


        StartCoroutine(server.setHalal(nev, halalszamszoveg));
        StartCoroutine(server.setPontszam(nev, pontszamszoveg));
        StartCoroutine(server.setLevels(nev, levelsszoveg));
        
    }
}