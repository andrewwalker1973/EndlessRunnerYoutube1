using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCollector : MonoBehaviour
{

    public static CollectableCollector Instance;         // Make this s static instance so that we can call it from anywhere

    void Awake()
    {
        Instance = this;
    }

    // Find Coin detector object
      public GameObject coinDetectorObj;
   // private GameObject playerBubble;

    void Start()
    {
        // find the game object that will detect coins
          coinDetectorObj = GameObject.FindGameObjectWithTag("CoinDetector");
      //  playerBubble = GameObject.FindGameObjectWithTag("PlayerBubble");
        coinDetectorObj.SetActive(false);
       // playerBubble.SetActive(false);
    }

  public void CollectMagnet()
    {
        Debug.Log("Magnet Pickup Successful CollectMagnet");
        StartCoroutine(ActivateCoin());

    }

    IEnumerator ActivateCoin()
    {
        Debug.Log("CoinDetector activated");
        coinDetectorObj.SetActive(true);
       // playerBubble.SetActive(true);
        yield return new WaitForSeconds(6f);
        coinDetectorObj.SetActive(false);
      //  playerBubble.SetActive(false);


    }
}
