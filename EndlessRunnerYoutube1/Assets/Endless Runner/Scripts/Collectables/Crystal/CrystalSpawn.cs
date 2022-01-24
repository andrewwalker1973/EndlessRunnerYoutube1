using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSpawn : MonoBehaviour
{
    [SerializeField] bool CrystalRandomOccurance;
    private int RandomCrystalOccuranceint;
    private GameObject Crystal;             // Variable for game object to be created

    void OnEnable()                             // Perform the actions as soon as the script is brought online
    {
        if (CrystalRandomOccurance)
        {
            RandomCrystalOccuranceint = Random.Range(0, 100);
            if (RandomCrystalOccuranceint < 50)
            {
                Debug.Log("Not generating crystal");
                return;
            }
            else
            {
                Crystal = CollectablePooler.Instance.GetCrystalPooledObject();            // Call GetLowObstaclePooledObject from Level1Obstacle script and retun a gameobject
                Crystal.transform.localPosition = this.transform.position;                  // Set Gameobject position to be position of this gameobject
                Crystal.SetActive(true);                                                    // Show the gameobject in the game world
            }

        }
        if (!CrystalRandomOccurance)
        {

            Crystal = CollectablePooler.Instance.GetCrystalPooledObject();            // Call GetLowObstaclePooledObject from Level1Obstacle script and retun a gameobject
            Crystal.transform.localPosition = this.transform.position;                  // Set Gameobject position to be position of this gameobject
            Crystal.SetActive(true);                                                    // Show the gameobject in the game world
        }


    }
}
