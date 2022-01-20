using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowFullLaneObstacle : MonoBehaviour
{
    private GameObject LowFullLaneObstacle1;             // Variable for game object to be created



    void OnEnable()                             // Perform the actions as soon as the script is brought online
    {

        LowFullLaneObstacle1 = Level1Obstacles.Instance.GetLowFullLaneObstaclePooledObject();            // Call GetLowObstaclePooledObject from Level1Obstacle script and retun a gameobject
        LowFullLaneObstacle1.transform.localPosition = this.transform.position;                  // Set Gameobject position to be position of this gameobject
        LowFullLaneObstacle1.SetActive(true);                                                    // Show the gameobject in the game world

    }
}
