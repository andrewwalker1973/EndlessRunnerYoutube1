using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.tag == "Player")                  // if obstacle hit player
        {
            Debug.LogError("You Died");
            gameObject.SetActive(false);                        // Disable the object.
        }


    }
}
