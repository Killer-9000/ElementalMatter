using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChange : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        LevelChanging();
    }

    void LevelChanging()
    {
        
    }

     void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Hand")
        {
            SceneManager.LoadScene(1);
        }
    }
}
