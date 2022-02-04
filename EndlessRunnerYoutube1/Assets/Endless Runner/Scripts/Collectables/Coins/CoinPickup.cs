using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{

    public Transform playerTransform;
    public float moveSpeed = 17f;

    CoinMove coinMoveScript;

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("PlayerBubble").transform;
        coinMoveScript = gameObject.GetComponent<CoinMove>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))       // if hit the player
        {
            Debug.Log("Coin Pickup Successful");

            gameObject.SetActive(false);                    // set game object disable

        }
     
        if (other.gameObject.tag == "CoinDetector")
        {
            coinMoveScript.enabled = true;
        }
    }
}
