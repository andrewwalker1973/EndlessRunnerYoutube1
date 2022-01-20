using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighFullLaneObstacle : MonoBehaviour
{
    private GameObject HighFullLaneObstacle1;             // Variable for game object to be created



    void OnEnable()                             // Perform the actions as soon as the script is brought online
    {

        HighFullLaneObstacle1 = Level1Obstacles.Instance.GetHighFullLaneObstaclePooledObject();            // Call GetLowObstaclePooledObject from Level1Obstacle script and retun a gameobject
        HighFullLaneObstacle1.transform.localPosition = this.transform.position;                  // Set Gameobject position to be position of this gameobject
        HighFullLaneObstacle1.SetActive(true);                                                    // Show the gameobject in the game world

    }
}
