using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightLineCoinsSpawn : MonoBehaviour
{
    private GameObject StraightLineCoin;             // Variable for game object to be created



    void OnEnable()                             // Perform the actions as soon as the script is brought online
    {

        StraightLineCoin = CollectablePooler.Instance.GetStraightLineCoinsPooledObject();            // Call GetLowObstaclePooledObject from Level1Obstacle script and retun a gameobject
        StraightLineCoin.transform.localPosition = this.transform.position;                  // Set Gameobject position to be position of this gameobject
        StraightLineCoin.SetActive(true);                                                    // Show the gameobject in the game world
        StraightLineCoin.transform.GetChild(0).gameObject.SetActive(true);
        StraightLineCoin.transform.GetChild(1).gameObject.SetActive(true);
        StraightLineCoin.transform.GetChild(2).gameObject.SetActive(true);

    }
}
