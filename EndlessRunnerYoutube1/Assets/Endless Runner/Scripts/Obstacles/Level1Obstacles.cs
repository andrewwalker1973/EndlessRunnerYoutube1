using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Obstacles : MonoBehaviour
{

    public static Level1Obstacles Instance;         // Make this s static instance so that we can call it from anywhere

    void Awake()
    {
        Instance = this;
    }

    private int lowRandomInt,highRandomInt;                          //Used for Random Generation of Levels
    private int prevlowRandomInt, prevhighRandomInt;                      // check for last trackpiece selected


    public GameObject[] Level1LowObstacle;          // Add all game objects into array so we cn getenerate alist from it
    public GameObject[] Level1HighObstacle;
    public List<GameObject> Level1LowObstaclePieces;    // Define the List of Level1 Low obstacle pieces
    public List<GameObject> Level1HighObstaclePieces;
    public int Level1LowLevelBlocks = 10;               // How many Low single lane obstacles to create
    public int Level1HighLevelBlocks = 10;


    void Start()
    {


        #region LowObstacles
        Level1LowObstaclePieces = new List<GameObject>();           // Define the List as a list of Game objects

        for (int i = 0; i < Level1LowLevelBlocks; i++)              // for all the Level1LowLevelBlocks generate a pooled piece at start
        {
            while (lowRandomInt == prevlowRandomInt)                                  // keep checking to reduce the number of duplicate obstacle pieces
            {
                lowRandomInt = Random.Range(0, Level1LowObstacle.Length);              // Random number between 0 and how manay pieces defined in Level1LowObstacle

            }
            prevlowRandomInt = lowRandomInt;                                          // Record what the last Obstacle piece was 
            GameObject obj = Instantiate(Level1LowObstacle[lowRandomInt]) as GameObject;  // instatiate it into the pool
            obj.SetActive(false);                                                   // disable the game object 
            Level1LowObstaclePieces.Add(obj);                                                   // add obj to the list of pooled objects for Level1LowObstaclePieces
        }
        #endregion

        #region HighObstacles
        Level1HighObstaclePieces = new List<GameObject>();           // Define the List as a list of Game objects

        for (int i = 0; i < Level1HighLevelBlocks; i++)              // for all the Level1LowLevelBlocks generate a pooled piece at start
        {
            while (highRandomInt == prevhighRandomInt)                                  // keep checking to reduce the number of duplicate obstacle pieces
            {
                highRandomInt = Random.Range(0, Level1HighObstacle.Length);              // Random number between 0 and how manay pieces defined in Level1LowObstacle

            }
            prevhighRandomInt = highRandomInt;                                          // Record what the last Obstacle piece was 
            GameObject highobj = Instantiate(Level1HighObstacle[highRandomInt]) as GameObject;  // instatiate it into the pool
            highobj.SetActive(false);                                                   // disable the game object 
            Level1HighObstaclePieces.Add(highobj);                                                   // add obj to the list of pooled objects for Level1LowObstaclePieces
        }
        #endregion
    }




    // Get Low level obstacle object
    public GameObject GetLowObstaclePooledObject()
    {
        for (int i = 0; i < Level1LowObstaclePieces.Count; i++)                   // check each pooled object in list
        {
            if (!Level1LowObstaclePieces[i].activeInHierarchy)                    // Check if NOT active in list
            {
                return Level1LowObstaclePieces[i];                                // Send back to game if not active
            }
        }
        // If not obstacle available in List Create a new one
      //  Debug.LogWarning("Generated Low Obstacle as none in pool");
        lowRandomInt = Random.Range(0, Level1LowObstacle.Length);                      // Rando asset from Level1LowObstacle array
        GameObject obj = Instantiate(Level1LowObstacle[lowRandomInt]) as GameObject;    // create obj of Obstaclees 
        obj.SetActive(false);                                       // turn off by default;
        Level1LowObstaclePieces.Add(obj);                                     // Add gameobject to pooledObjects List
        return obj;                                                 // Return the new game object to the List and it can be used going forward in the list
    }


    public GameObject GetHighObstaclePooledObject()
    {
        for (int i = 0; i < Level1HighObstaclePieces.Count; i++)                   // check each pooled object in list
        {
            if (!Level1HighObstaclePieces[i].activeInHierarchy)                    // Check if NOT active in list
            {
                return Level1HighObstaclePieces[i];                                // Send back to game if not active
            }
        }
        // If not obstacle available in List Create a new one
       // Debug.LogWarning("Generated Low Obstacle as none in pool");
        highRandomInt = Random.Range(0, Level1HighObstacle.Length);                      // Rando asset from Level1LowObstacle array
        GameObject highobj = Instantiate(Level1HighObstacle[highRandomInt]) as GameObject;    // create obj of Obstaclees 
        highobj.SetActive(false);                                       // turn off by default;
        Level1HighObstaclePieces.Add(highobj);                                     // Add gameobject to pooledObjects List
        return highobj;                                                 // Return the new game object to the List and it can be used going forward in the list
    }

}
