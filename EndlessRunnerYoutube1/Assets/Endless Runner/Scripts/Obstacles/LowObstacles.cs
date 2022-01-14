using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowObstacles : MonoBehaviour
{

    private GameObject LowObstacle;             // Variable for game object to be created
  
    void OnEnable()                             // Perform the actions as soon as the script is brought online
    {

        LowObstacle = Level1Obstacles.Instance.GetLowObstaclePooledObject();            // Call GetLowObstaclePooledObject from Level1Obstacle script and retun a gameobject
        LowObstacle.transform.localPosition = this.transform.position;                  // Set Gameobject position to be position of this gameobject
        LowObstacle.SetActive(true);                                                    // Show the gameobject in the game world

    }


}
