using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMove : MonoBehaviour
{

    // maybe remove coinpick up scripr ?
    CoinPickup coinScript;
    CoinMove coinMoveScript;

    // Start is called before the first frame update
    void Start()
    {
        coinScript = gameObject.GetComponent<CoinPickup>();
        coinMoveScript = gameObject.GetComponent<CoinMove>();
    }

    // Update is called once per frame
    void Update()
    {
        // add if clause to make sure move is enabled
        transform.position = Vector3.MoveTowards(transform.position, coinScript.playerTransform.position,
           coinScript.moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerBubble" || other.gameObject.tag == "Player")
        {
            //Add count or give points etc etc.
            coinMoveScript.enabled = false;
            gameObject.SetActive(false);
        }
        
    }
}
