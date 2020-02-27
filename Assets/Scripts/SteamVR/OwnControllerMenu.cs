//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using Valve.VR;
//using Valve.VR.InteractionSystem;

//public class OwnControllerMenu : MonoBehaviour
//{
//    public static ControllerMenu instance;

//    [HideInInspector]
//    public GameObject activeMenu;

//    private SteamVR_Action_Boolean menuButton = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Menu");

//    // Start is called before the first frame update
//    void Awake()
//    {
//        //instance = this;
//    }

//    // Update is called once per frame
//    void FixedUpdate()
//    {
//        CheckMenuButton();
//    }

//    public void CheckMenuButton()
//    {
//        foreach (Hand hand in Player.instance.hands)
//        {
//            if (menuButton.GetStateDown(hand.handType))
//            {

//            }

//            break;
//        }
        
//    }

//}
