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


    //    Debug.Log("Obstaclce col " + other);
        if (other.gameObject.tag == "Player")                  // if obstacle hit player
        {
            if (PowerUpManager.Instance.ShieldModeActive == true)
            {
                PowerUpManager.Instance.ShieldHit();
                gameObject.SetActive(false);
                return;
            }
            else
            {
                thePlayerMotor.PlayerDeath();
            }
        }
        if (other.gameObject.tag == "ObstacleRemover")
        {
            gameObject.SetActive(false);
        }


    }

   
}
