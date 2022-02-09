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
/*
    // Find Coin detector object
      public GameObject coinDetectorObj;
    // private GameObject playerBubble;

    private float magnetDuration;

    void Start()
    {
        // find the game object that will detect coins
          coinDetectorObj = GameObject.FindGameObjectWithTag("CoinDetector");
      //  playerBubble = GameObject.FindGameObjectWithTag("PlayerBubble");
        coinDetectorObj.SetActive(false);
       // playerBubble.SetActive(false);
    }

  public void CollectMagnet(float time)
    {
        Debug.Log("Magnet Pickup Successful CollectMagnet");
        magnetDuration = time;
        StartCoroutine(ActivateCoin(magnetDuration));

    }

    IEnumerator ActivateCoin(float time)
    {
        Debug.Log("CoinDetector activated" + time);
        coinDetectorObj.SetActive(true);
       // playerBubble.SetActive(true);
        yield return new WaitForSeconds(time);
        coinDetectorObj.SetActive(false);
      //  playerBubble.SetActive(false);


    }
*/
}
