using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{

    private PlayerMotor thePlayerMotor;               // To reference the CameraSwitter script
    private void Start()
    {
        thePlayerMotor = FindObjectOfType<PlayerMotor>(); // Find the PlayerMotor script in the world and call it thePlayerMotor
    }
    private void OnTriggerEnter(Collider other)
    {
        


        if (other.gameObject.tag == "Player")                  // if obstacle hit player
        {
            Debug.LogError("You Died");
            thePlayerMotor.PlayerDeath();
            //gameObject.SetActive(false);                        // Disable the object.
        }


    }
}
