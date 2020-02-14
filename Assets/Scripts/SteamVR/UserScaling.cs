using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class UserScaling : MonoBehaviour
{
    public float speed = 0.1f;

    public float MaxHeightLimit = 100f;
    public float MinHeightLimit = 0.1f;

    private SteamVR_Action_Boolean scaleUp = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("ScaleUp");
    private SteamVR_Action_Boolean scaleDown = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("ScaleDown");

    void Update()
    {
        CheckHandInput();
    }

    private void CheckHandInput()
    {
        if (OpenVR.Input != null)
        {
            foreach (Hand hand in Player.instance.hands)
            {
                if (scaleUp.GetState(hand.handType))
                {
                    Vector3 upScale = this.transform.localScale + (Vector3.one / 10 * speed);
                    if (upScale.y <= MaxHeightLimit)
                        this.transform.localScale = upScale;
                }
                else if (scaleDown.GetState(hand.handType))
                {
                    Vector3 downScale = this.transform.localScale - (Vector3.one / 10 * speed);
                    if (downScale.y >= MinHeightLimit)
                        this.transform.localScale = downScale;
                }
            }
        }
    }
}
