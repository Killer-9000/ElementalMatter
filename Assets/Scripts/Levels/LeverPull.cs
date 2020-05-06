using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPull : MonoBehaviour
{
    public Animator RDoorAnim;
    public Animator LDoorAnim;
    void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.tag == "LeverPulled")
        {
            RDoorAnim.Play("RDoor");

           LDoorAnim.Play("LDoor");
        }
    }
}
