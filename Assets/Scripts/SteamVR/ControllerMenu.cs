using System.Collections;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ControllerMenu : MonoBehaviour
{
    public static ControllerMenu instance;

    public GameObject mainMenuPrefab, howToPlayPrefab;

    [HideInInspector]
    public GameObject activeMenu;

    private SteamVR_Action_Boolean menuButton = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Menu");

    private void Awake()
    {
        instance = this;
    }

    private void FixedUpdate()
    {
        CheckMenuButton();
    }

    private void CheckMenuButton()
    {
        if (OpenVR.Input != null)
        {
            foreach (Hand hand in Player.instance.hands)
            {
                if (menuButton.GetStateDown(hand.handType))
                {
                    if (activeMenu == null) // Window isn't open
                    {
                        activeMenu = Instantiate(mainMenuPrefab, hand.transform);

                    }
                    else if (activeMenu.transform.parent == hand.transform) // Window is open in current hand
                    {
                        Destroy(activeMenu);
                        activeMenu = null;
                    }
                    else // Window is open in other hand
                    {
                        Destroy(activeMenu);
                        activeMenu = Instantiate(mainMenuPrefab, hand.transform);
                    }

                    break;
                }
            }
        }
    }
}
