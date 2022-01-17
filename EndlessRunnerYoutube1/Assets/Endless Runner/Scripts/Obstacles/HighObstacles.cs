using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighObstacles : MonoBehaviour
{
    private GameObject HighObstacle;             // Variable for game object to be created



    void OnEnable()                             // Perform the actions as soon as the script is brought online
    {

        HighObstacle = Level1Obstacles.Instance.GetHighObstaclePooledObject();            // Call GetLowObstaclePooledObject from Level1Obstacle script and retun a gameobject
        HighObstacle.transform.localPosition = this.transform.position;                  // Set Gameobject position to be position of this gameobject
        HighObstacle.SetActive(true);                                                    // Show the gameobject in the game world

    }
}
