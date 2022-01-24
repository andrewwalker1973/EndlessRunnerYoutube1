using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalPickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))       // if hit the player
        {
            Debug.Log("Crystal Pickup Successful");

            gameObject.SetActive(false);                    // set game object disable

        }
    }
}
