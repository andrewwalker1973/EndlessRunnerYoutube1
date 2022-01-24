using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawn : MonoBehaviour
{
  [TextArea]
   [Tooltip("Info on Line placement for coins")]
    public string Notes = "For Jump set y=0.4,Normal y=0.3, for Slide y= 0.1";

    private GameObject CoinLine;             // Variable for game object to be created
    [SerializeField] bool straightLine;
    [SerializeField] bool jumpLine;

  

    void OnEnable()                             // Perform the actions as soon as the script is brought online
    {

        if ((!straightLine) && (!jumpLine))
        {
            Debug.LogError("You need to select a coin line type");
            return;
        }

        if ((straightLine) && (jumpLine))
        {
            Debug.LogError("You can only select one coin line type");
            return;
        }

        if (straightLine)
       {
            CoinLine = CollectablePooler.Instance.GetStraightLineCoinsPooledObject();            // Call GetLowObstaclePooledObject from Level1Obstacle script and retun a gameobject
            CoinLine.transform.localPosition = this.transform.position;                  // Set Gameobject position to be position of this gameobject
            CoinLine.SetActive(true);                                                    // Show the gameobject in the game world
            CoinLine.transform.GetChild(0).gameObject.SetActive(true);
            CoinLine.transform.GetChild(1).gameObject.SetActive(true);
            CoinLine.transform.GetChild(2).gameObject.SetActive(true);
        }

        if (jumpLine)
        {
            CoinLine = CollectablePooler.Instance.GetJumpLineCoinsPooledObject();            // Call GetLowObstaclePooledObject from Level1Obstacle script and retun a gameobject
            CoinLine.transform.localPosition = this.transform.position;                  // Set Gameobject position to be position of this gameobject
            CoinLine.SetActive(true);                                                    // Show the gameobject in the game world
            CoinLine.transform.GetChild(0).gameObject.SetActive(true);
            CoinLine.transform.GetChild(1).gameObject.SetActive(true);
            CoinLine.transform.GetChild(2).gameObject.SetActive(true);
            CoinLine.transform.GetChild(3).gameObject.SetActive(true);
            CoinLine.transform.GetChild(4).gameObject.SetActive(true);
        }
   
    }
}
