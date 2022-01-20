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

    private int lowRandomInt,highRandomInt,LowFullRandomInt, HighFullRandomInt;                          //Used for Random Generation of Levels
    private int prevlowRandomInt, prevhighRandomInt,prevLowFullRandomInt, prevHighFullRandomInt;                      // check for last trackpiece selected


    public GameObject[] Level1LowObstacle;          // Add all game objects into array so we cn getenerate alist from it
    public GameObject[] Level1HighObstacle;
    public GameObject[] Level1LowFullLaneObstacle;
    public GameObject[] Level1HighFullLaneObstacle;
    public List<GameObject> Level1LowObstaclePieces;    // Define the List of Level1 Low obstacle pieces
    public List<GameObject> Level1HighObstaclePieces;
    public List<GameObject> Level1LowFullLaneObstaclePieces;
    public List<GameObject> Level1HighFullLaneObstaclePieces;
    public int Level1LowLevelBlocks = 10;               // How many Low single lane obstacles to create
    public int Level1HighLevelBlocks = 10;
    public int Level1LowFullLaneBlocks = 10;
    public int Level1HighFullLaneBlocks = 10;


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

        #region LowFullLaneObstacles
        Level1LowFullLaneObstaclePieces = new List<GameObject>();           // Define the List as a list of Game objects

        for (int i = 0; i < Level1LowFullLaneBlocks; i++)              // for all the Level1LowLevelBlocks generate a pooled piece at start
        {
            while (LowFullRandomInt == prevLowFullRandomInt)                                  // keep checking to reduce the number of duplicate obstacle pieces
            {
                LowFullRandomInt = Random.Range(0, Level1LowFullLaneObstacle.Length);              // Random number between 0 and how manay pieces defined in Level1LowObstacle

            }
            prevLowFullRandomInt = LowFullRandomInt;                                          // Record what the last Obstacle piece was 
            GameObject lowfullobj = Instantiate(Level1LowFullLaneObstacle[LowFullRandomInt]) as GameObject;  // instatiate it into the pool
            lowfullobj.SetActive(false);                                                   // disable the game object 
            Level1LowFullLaneObstaclePieces.Add(lowfullobj);                                                   // add obj to the list of pooled objects for Level1LowObstaclePieces
        }
        #endregion

        #region HighFullLaneObstacles
        Level1HighFullLaneObstaclePieces = new List<GameObject>();           // Define the List as a list of Game objects

        for (int i = 0; i < Level1HighFullLaneBlocks; i++)              // for all the Level1LowLevelBlocks generate a pooled piece at start
        {
            while (HighFullRandomInt == prevHighFullRandomInt)                                  // keep checking to reduce the number of duplicate obstacle pieces
            {
                HighFullRandomInt = Random.Range(0, Level1HighFullLaneObstacle.Length);              // Random number between 0 and how manay pieces defined in Level1LowObstacle

            }
            prevHighFullRandomInt = HighFullRandomInt;                                          // Record what the last Obstacle piece was 
            GameObject highfullobj = Instantiate(Level1HighFullLaneObstacle[HighFullRandomInt]) as GameObject;  // instatiate it into the pool
            highfullobj.SetActive(false);                                                   // disable the game object 
            Level1HighFullLaneObstaclePieces.Add(highfullobj);                                                   // add obj to the list of pooled objects for Level1LowObstaclePieces
        }
        #endregion
    }



    #region GetLowObstaclePooledObject
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
        lowRandomInt = Random.Range(0, Level1LowObstacle.Length);                      // Rando asset from Level1LowObstacle array
        GameObject obj = Instantiate(Level1LowObstacle[lowRandomInt]) as GameObject;    // create obj of Obstaclees 
        obj.SetActive(false);                                       // turn off by default;
        Level1LowObstaclePieces.Add(obj);                                     // Add gameobject to pooledObjects List
        return obj;                                                 // Return the new game object to the List and it can be used going forward in the list
    }
    #endregion

    #region GetHighObstaclePooledObject
    // Get High level obstacle object
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
        highRandomInt = Random.Range(0, Level1HighObstacle.Length);                      // Rando asset from Level1LowObstacle array
        GameObject highobj = Instantiate(Level1HighObstacle[highRandomInt]) as GameObject;    // create obj of Obstaclees 
        highobj.SetActive(false);                                       // turn off by default;
        Level1HighObstaclePieces.Add(highobj);                                     // Add gameobject to pooledObjects List
        return highobj;                                                 // Return the new game object to the List and it can be used going forward in the list
    }
    #endregion

    #region GetLowFullLaneObstaclePooledObject
    // Get High level obstacle object
    public GameObject GetLowFullLaneObstaclePooledObject()
    {
        for (int i = 0; i < Level1LowFullLaneObstaclePieces.Count; i++)                   // check each pooled object in list
        {
            if (!Level1LowFullLaneObstaclePieces[i].activeInHierarchy)                    // Check if NOT active in list
            {
                return Level1LowFullLaneObstaclePieces[i];                                // Send back to game if not active
            }
        }
        // If not obstacle available in List Create a new one
        LowFullRandomInt = Random.Range(0, Level1LowFullLaneObstacle.Length);                      // Rando asset from Level1LowObstacle array
        GameObject lowfullobj = Instantiate(Level1LowFullLaneObstacle[LowFullRandomInt]) as GameObject;    // create obj of Obstaclees 
        lowfullobj.SetActive(false);                                       // turn off by default;
        Level1LowFullLaneObstaclePieces.Add(lowfullobj);                                     // Add gameobject to pooledObjects List
        return lowfullobj;                                                 // Return the new game object to the List and it can be used going forward in the list
    }
    #endregion

    #region GetHighFullLaneObstaclePooledObject
    // Get High level obstacle object
    public GameObject GetHighFullLaneObstaclePooledObject()
    {
        for (int i = 0; i < Level1HighFullLaneObstaclePieces.Count; i++)                   // check each pooled object in list
        {
            if (!Level1HighFullLaneObstaclePieces[i].activeInHierarchy)                    // Check if NOT active in list
            {
                return Level1HighFullLaneObstaclePieces[i];                                // Send back to game if not active
            }
        }
        // If not obstacle available in List Create a new one
        HighFullRandomInt = Random.Range(0, Level1HighFullLaneObstacle.Length);                      // Rando asset from Level1LowObstacle array
        GameObject highfullobj = Instantiate(Level1HighFullLaneObstacle[HighFullRandomInt]) as GameObject;    // create obj of Obstaclees 
        highfullobj.SetActive(false);                                       // turn off by default;
        Level1HighFullLaneObstaclePieces.Add(highfullobj);                                     // Add gameobject to pooledObjects List
        return highfullobj;                                                 // Return the new game object to the List and it can be used going forward in the list
    }
    #endregion
}
