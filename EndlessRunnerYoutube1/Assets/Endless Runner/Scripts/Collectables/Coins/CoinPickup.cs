using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
  // private ScoreManager theScoreManager;       // reference the score manager

    public Transform playerTransform;
    public float moveSpeed = 17f;
    private int coinScore = 1;

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
            ScoreManager.Instance.AddCoins(coinScore);
            gameObject.SetActive(false);                    // set game object disable

        }
     
        if (other.gameObject.tag == "CoinDetector")
        {
            coinMoveScript.enabled = true;
        }
    }
}
