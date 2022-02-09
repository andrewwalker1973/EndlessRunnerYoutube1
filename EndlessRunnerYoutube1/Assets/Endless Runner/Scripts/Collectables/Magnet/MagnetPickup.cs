using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))       // if hit the player
        {
           //CollectableCollector.Instance.CollectMagnet();   // Run the fucntion in CollectableCollector to pickup and manage the magent pickup
          // gameObject.SetActive(false);                    // set game object disable

        }
    }
}
