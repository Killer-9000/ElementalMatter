using UnityEngine;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class CanvasInteraction : MonoBehaviour
{
    private SteamVR_Action_Boolean triggerButton = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabPinch");

    // Update is called once per frame
    void Update()
    {
        foreach (Hand hand in Player.instance.hands)
        {
            if (Physics.Raycast(hand.transform.position, hand.transform.forward, out RaycastHit hitInfo, 20f)) // Cast out a ray infront of the control
            {
                if (hitInfo.transform.gameObject.layer == 5) // Check to see if its part of the UI layer
                {
                    Debug.DrawRay(hand.transform.position, hand.transform.forward, Color.white);

                    if (triggerButton.GetState(hand.handType))
                        hitInfo.transform.gameObject.GetComponent<Button>().onClick.Invoke();
                }
            }
        }
    }
}
