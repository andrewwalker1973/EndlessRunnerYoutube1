using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
  
        if (other.gameObject.CompareTag("Player"))       // if hit the player
        {
            Debug.Log("Coin Pickup Successful");

            gameObject.SetActive(false);                    // set game object disable

        }
    }
}
