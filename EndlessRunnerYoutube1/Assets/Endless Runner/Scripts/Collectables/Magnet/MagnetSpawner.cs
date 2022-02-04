using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetSpawner : MonoBehaviour
{
    [SerializeField] bool MagnetRandomOccurance;
    private int RandomMagnetOccuranceint;
    private GameObject Magnet;             // Variable for game object to be created



    void OnEnable()                             // Perform the actions as soon as the script is brought online
    {


        if (MagnetRandomOccurance)
        {
            RandomMagnetOccuranceint = Random.Range(0, 100);
            if (RandomMagnetOccuranceint < 50)
            {
                return;
            }
            else
            {
                Magnet = CollectablePooler.Instance.GetMagnetPooledObject();            // Call GetLowObstaclePooledObject from Level1Obstacle script and retun a gameobject
                Magnet.transform.localPosition = this.transform.position;                  // Set Gameobject position to be position of this gameobject
                Magnet.SetActive(true);                                                    // Show the gameobject in the game world
            }

        }
        if (!MagnetRandomOccurance)
        {

            Magnet = CollectablePooler.Instance.GetMagnetPooledObject();            // Call GetLowObstaclePooledObject from Level1Obstacle script and retun a gameobject
            Magnet.transform.localPosition = this.transform.position;                  // Set Gameobject position to be position of this gameobject
            Magnet.SetActive(true);                                                    // Show the gameobject in the game world
        }


    }
}
