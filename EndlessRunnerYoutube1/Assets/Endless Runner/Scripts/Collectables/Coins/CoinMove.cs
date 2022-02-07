using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMove : MonoBehaviour
{
    
   
    CoinPickup coinScript;
    CoinMove coinMoveScript;

    void Start()
    {
       coinScript = gameObject.GetComponent<CoinPickup>();
        coinMoveScript = gameObject.GetComponent<CoinMove>();
    }

    void Update()
    {
 
        if (coinMoveScript.enabled == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, coinScript.playerTransform.position,
            coinScript.moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

            if (other.gameObject.tag == "PlayerBubble" || other.gameObject.tag == "Player")
            {
               ScoreManager.Instance.AddCoins(1);  // add 1 coins
            coinMoveScript = gameObject.GetComponent<CoinMove>();
             coinMoveScript.enabled = false;
            gameObject.SetActive(false);
            }

    }
}
