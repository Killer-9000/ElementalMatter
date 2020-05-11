﻿using System.Collections;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public float speed = 0.5f;

    public Transform doorLeft;
    public Transform doorRight;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer != 9)
            return;

        StopCoroutine("CloseDoors");
        StartCoroutine("OpenDoors", speed);
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.layer != 9)
            return;

        StopCoroutine("OpenDoors");
        StartCoroutine("CloseDoors", -speed);
    }

    IEnumerator OpenDoors(float speed)
    {
        while (doorLeft.localPosition.x < 3.69)
        {
            doorLeft.Translate(Vector3.right * speed);
            doorRight.Translate(Vector3.left * speed);
            yield return null;
        }
    }

    IEnumerator CloseDoors(float speed)
    {
        while (doorLeft.localPosition.x > 1.153)
        {
            doorLeft.Translate(Vector3.right * speed);
            doorRight.Translate(Vector3.left * speed);
            yield return null;
        }
    }
}
