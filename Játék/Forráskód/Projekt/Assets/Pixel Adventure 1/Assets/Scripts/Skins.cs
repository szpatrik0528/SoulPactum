using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Skins : MonoBehaviour
{
    public Toggle[] valasztas;
    public Toggle[] feloldottskin;
    public Image[] lakat;
    public int valasztottskin;
    public Sprite[] valasztaskinezet;
    public RuntimeAnimatorController[] animator;

    private void Update()
    {
        try
        {
            skin();
        }
        catch (System.Exception)
        {


        }
    }
    public void skinVerify()
    {
        Debug.Log("SkinId: " + PlayerPrefs.GetInt("skinId"));
        int skinID = PlayerPrefs.GetInt("skinId");
        switch (skinID)
        {
            case 1:
                feloldottskin[0].interactable = true;
                lakat[0].enabled = false;
                break;
            case 2:
                feloldottskin[1].interactable = true;
                lakat[1].enabled = false;

                break;
            case 3:
                feloldottskin[0].interactable = true;
                feloldottskin[1].interactable = true;
                lakat[0].enabled = false;
                lakat[1].enabled = false;

                break;
            default:
                feloldottskin[0].interactable = false;
                feloldottskin[1].interactable = false;
                lakat[0].enabled = true;
                lakat[1].enabled = true;

                break;
        }
    }

    public void valasztmetod()
    {
        if (valasztas[0].isOn)
        {
            valasztottskin = 0;
            PlayerPrefs.SetInt("skin", valasztottskin);
            Debug.Log("Skin: " + PlayerPrefs.GetInt("skin"));
        }
        else if (valasztas[1].isOn)
        {
            valasztottskin = 1;
            PlayerPrefs.SetInt("skin", valasztottskin);
            Debug.Log("Skin: " + PlayerPrefs.GetInt("skin"));
        }
        else if (valasztas[2].isOn)
        {
            valasztottskin = 2;
            PlayerPrefs.SetInt("skin", valasztottskin);
            Debug.Log("Skin: " + PlayerPrefs.GetInt("skin"));
        }
        else if (valasztas[3].isOn)
        {
            valasztottskin = 3;
            PlayerPrefs.SetInt("skin", valasztottskin);
            Debug.Log("Skin: " + PlayerPrefs.GetInt("skin"));
        }
    }
    public void skin()
    {
        valasztottskin = PlayerPrefs.GetInt("skin");
        switch (valasztottskin)
        {
            case 0:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = valasztaskinezet[0];
                this.gameObject.GetComponent<Animator>().runtimeAnimatorController = animator[0];
                break;
            case 1:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = valasztaskinezet[1];
                this.gameObject.GetComponent<Animator>().runtimeAnimatorController = animator[1];
                break;
            case 2:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = valasztaskinezet[2];
                this.gameObject.GetComponent<Animator>().runtimeAnimatorController = animator[2];
                break;
            case 3:
                this.gameObject.GetComponent<SpriteRenderer>().sprite = valasztaskinezet[3];
                this.gameObject.GetComponent<Animator>().runtimeAnimatorController = animator[3];
                break;
        }

    }
}
