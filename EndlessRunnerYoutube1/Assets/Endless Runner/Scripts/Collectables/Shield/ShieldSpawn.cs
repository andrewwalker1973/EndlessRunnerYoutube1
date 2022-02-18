using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldSpawn : MonoBehaviour
{
    [SerializeField] bool ShieldRandomOccurance;
    private int RandomShieldOccuranceint;
    private GameObject Shield;             // Variable for game object to be created

    void OnEnable()                             // Perform the actions as soon as the script is brought online
    {
        if (ShieldRandomOccurance)
        {
            RandomShieldOccuranceint = Random.Range(0, 100);
            if (RandomShieldOccuranceint < 50)
            {
                Debug.Log("Not generating crystal");
                return;
            }
            else
            {
                Shield = CollectablePooler.Instance.GetShieldPooledObject();            // Call GetLowObstaclePooledObject from Level1Obstacle script and retun a gameobject
                Shield.transform.localPosition = this.transform.position;                  // Set Gameobject position to be position of this gameobject
                Shield.SetActive(true);                                                    // Show the gameobject in the game world
            }

        }
        if (!ShieldRandomOccurance)
        {

            Shield = CollectablePooler.Instance.GetShieldPooledObject();            // Call GetLowObstaclePooledObject from Level1Obstacle script and retun a gameobject
            Shield.transform.localPosition = this.transform.position;                  // Set Gameobject position to be position of this gameobject
            Shield.SetActive(true);                                                    // Show the gameobject in the game world
        }


    }
}
