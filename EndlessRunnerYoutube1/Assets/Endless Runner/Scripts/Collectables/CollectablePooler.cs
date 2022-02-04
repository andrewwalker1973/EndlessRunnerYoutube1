using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablePooler : MonoBehaviour
{
    public static CollectablePooler Instance;         // Make this s static instance so that we can call it from anywhere
    public GameObject StraightLineCoins;          // Add all game objects into array so we cn getenerate alist from it
    public GameObject JumpLineCoins;
    [SerializeField] GameObject Magnet;
    [SerializeField] GameObject Crystal;
    public List<GameObject> StraightLineCoinsPieces;    // Define the List of Level1 Low obstacle pieces
    public List<GameObject> JumpCoinsPieces;
    [SerializeField] List<GameObject> CrystalPieces;
    [SerializeField] List<GameObject> MagnetPieces;
    public int StraightLineCoinsCount = 10;               // How many Low single lane obstacles to create
    public int JumpCoinsPiecesCount = 10;
    [SerializeField] int CrystalPiecesCount = 5;
    [SerializeField] int MagnetPiecesCount = 5;


    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        #region StraightLineCoins
        StraightLineCoinsPieces = new List<GameObject>();           // Define the List as a list of Game objects

        for (int i = 0; i < StraightLineCoinsCount; i++)              // for all the Level1LowLevelBlocks generate a pooled piece at start
        {
            GameObject obj = Instantiate(StraightLineCoins) as GameObject;  // instatiate it into the pool
            obj.SetActive(false);                                                   // disable the game object 
            StraightLineCoinsPieces.Add(obj);                                                   // add obj to the list of pooled objects for Level1LowObstaclePieces
        }
        #endregion

        #region JumpCoins
        JumpCoinsPieces = new List<GameObject>();           // Define the List as a list of Game objects

        for (int i = 0; i < JumpCoinsPiecesCount; i++)              // for all the Level1LowLevelBlocks generate a pooled piece at start
        {
            GameObject obj = Instantiate(JumpLineCoins) as GameObject;  // instatiate it into the pool
            obj.SetActive(false);                                                   // disable the game object 
            JumpCoinsPieces.Add(obj);                                                   // add obj to the list of pooled objects for Level1LowObstaclePieces
        }
        #endregion

        #region Crystals
        CrystalPieces = new List<GameObject>();           // Define the List as a list of Game objects

        for (int i = 0; i < CrystalPiecesCount; i++)              // for all the Level1LowLevelBlocks generate a pooled piece at start
        {
            GameObject obj = Instantiate(Crystal) as GameObject;  // instatiate it into the pool
            obj.SetActive(false);                                                   // disable the game object 
            CrystalPieces.Add(obj);                                                   // add obj to the list of pooled objects for Level1LowObstaclePieces
        }
        #endregion

        #region Magnet
        MagnetPieces = new List<GameObject>();           // Define the List as a list of Game objects

        for (int i = 0; i < MagnetPiecesCount; i++)              // for all the Level1LowLevelBlocks generate a pooled piece at start
        {
            GameObject obj = Instantiate(Magnet) as GameObject;  // instatiate it into the pool
            obj.SetActive(false);                                                   // disable the game object 
            MagnetPieces.Add(obj);                                                   // add obj to the list of pooled objects for Level1LowObstaclePieces
        }
        #endregion
    }









    #region GetStraightLineCoinsPooledObject
    // Get Low level obstacle object
    public GameObject GetStraightLineCoinsPooledObject()
    {
        for (int i = 0; i < StraightLineCoinsPieces.Count; i++)                   // check each pooled object in list
        {
            if (!StraightLineCoinsPieces[i].activeInHierarchy)                    // Check if NOT active in list
            {
                return StraightLineCoinsPieces[i];                                // Send back to game if not active
            }
        }
        // If not obstacle available in List Create a new one
        GameObject obj = Instantiate(StraightLineCoins) as GameObject;    // create obj of Obstaclees 
        obj.SetActive(false);                                       // turn off by default;
        StraightLineCoinsPieces.Add(obj);                                     // Add gameobject to pooledObjects List
        return obj;                                                 // Return the new game object to the List and it can be used going forward in the list
    }
    #endregion

    #region GetJumpLineCoinsPooledObject
    // Get Low level obstacle object
    public GameObject GetJumpLineCoinsPooledObject()
    {
        for (int i = 0; i < JumpCoinsPieces.Count; i++)                   // check each pooled object in list
        {
            if (!JumpCoinsPieces[i].activeInHierarchy)                    // Check if NOT active in list
            {
                return JumpCoinsPieces[i];                                // Send back to game if not active
            }
        }
        // If not obstacle available in List Create a new one
        GameObject obj = Instantiate(JumpLineCoins) as GameObject;    // create obj of Obstaclees 
        obj.SetActive(false);                                       // turn off by default;
        JumpCoinsPieces.Add(obj);                                     // Add gameobject to pooledObjects List
        return obj;                                                 // Return the new game object to the List and it can be used going forward in the list
    }
    #endregion

    #region GetCrystalPooledObject
    // Get Low level obstacle object
    public GameObject GetCrystalPooledObject()
    {
        for (int i = 0; i < CrystalPieces.Count; i++)                   // check each pooled object in list
        {
            if (!CrystalPieces[i].activeInHierarchy)                    // Check if NOT active in list
            {
                return CrystalPieces[i];                                // Send back to game if not active
            }
        }
        // If not obstacle available in List Create a new one
        GameObject obj = Instantiate(Crystal) as GameObject;    // create obj of Obstaclees 
        obj.SetActive(false);                                       // turn off by default;
        CrystalPieces.Add(obj);                                     // Add gameobject to pooledObjects List
        return obj;                                                 // Return the new game object to the List and it can be used going forward in the list
    }
    #endregion

    #region GetMagnetPooledObject
    // Get Magnet object
    public GameObject GetMagnetPooledObject()
    {
        for (int i = 0; i < MagnetPieces.Count; i++)                   // check each pooled object in list
        {
            if (!MagnetPieces[i].activeInHierarchy)                    // Check if NOT active in list
            {
                return MagnetPieces[i];                                // Send back to game if not active
            }
        }
        // If not Magnet available in List Create a new one
        GameObject obj = Instantiate(Magnet) as GameObject;    // create obj of Obstaclees 
        obj.SetActive(false);                                       // turn off by default;
        MagnetPieces.Add(obj);                                     // Add gameobject to pooledObjects List
        return obj;                                                 // Return the new game object to the List and it can be used going forward in the list
    }
    #endregion
}
