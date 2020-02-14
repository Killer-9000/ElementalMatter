using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class MenuButtonScripts : MonoBehaviour
{
    public GameObject MainMenu, HowToPlay, Log, player;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //Finds player
    }

    public void btnHowToPlay()
    {
        Debug.Log("Button Pressed!");
        Transform parent = player.GetComponent<ControllerMenu>().activeMenu.transform.parent; //Finds the hand that the menu is with
        Destroy(player.GetComponent<ControllerMenu>().activeMenu); //Destroys the active menu
        player.GetComponent<ControllerMenu>().activeMenu = Instantiate(HowToPlay, parent.transform); //Instanciates the new prefab to the hand

    }

    public void btnChangeLog()
    {
        Debug.Log("Button Pressed!");
        Transform parent = player.GetComponent<ControllerMenu>().activeMenu.transform.parent; //Finds the hand that the menu is with
        Destroy(player.GetComponent<ControllerMenu>().activeMenu); //Destroys the active menu
        player.GetComponent<ControllerMenu>().activeMenu = Instantiate(Log, parent.transform); //Instanciates the new prefab to the hand

    }

    public void btnGoBackToMenu()
    {
        Debug.Log("Button Pressed!");
        Transform parent = player.GetComponent<ControllerMenu>().activeMenu.transform.parent; //Finds the hand that the menu is with
        Destroy(player.GetComponent<ControllerMenu>().activeMenu); //Destroys the active menu
        player.GetComponent<ControllerMenu>().activeMenu = Instantiate(MainMenu, parent.transform); //Instanciates the new prefab to the hand
    }
}




