using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalPickup : MonoBehaviour
{
    private int crystalScore = 1;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))       // if hit the player
        {
            Debug.Log("Crystal Pickup Successful");
            ScoreManager.Instance.AddCrystals(crystalScore);
            gameObject.SetActive(false);                    // set game object disable

        }
    }
}
