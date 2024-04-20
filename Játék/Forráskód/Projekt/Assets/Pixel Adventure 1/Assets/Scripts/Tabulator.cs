using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tabulator : MonoBehaviour
{
    public InputField nameIp;
    public InputField pass1IP;
    public InputField pass2IP;
    public Button Submit;
    public Button GoTo;
    public Button EXIT;
    public int IPSelected;
    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab) && Input.GetKeyDown(KeyCode.LeftShift)|| Input.GetKeyDown(KeyCode.UpArrow))
        {
            IPSelected--;
            if (IPSelected < 0) IPSelected = 5;
            SelectInputField();
        }
        else if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            IPSelected++;
            if (IPSelected > 5) IPSelected = 0;
            SelectInputField();
        }
        void SelectInputField()
        {
            switch (IPSelected)
            {
                case 0:
                    nameIp.Select();
                    break;
                case 1:
                    pass1IP.Select();
                    break;
                case 2:
                    pass2IP.Select();
                    break;
                case 3:
                    Submit.Select();
                    break;
                case 4:
                    GoTo.Select();
                    break;
                case 5:
                    EXIT.Select();
                    break;
                default:
                    break;
            }
        }
    }
   



}