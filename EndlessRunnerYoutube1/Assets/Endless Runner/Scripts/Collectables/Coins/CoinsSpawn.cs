using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawn : MonoBehaviour
{
  [TextArea]
   [Tooltip("Info on Line placement for coins")]
    public string Notes = "For Jump set y=0.4,Normal y=0.3, for Slide y= 0.1";

    private GameObject CoinLine;             // Variable for game object to be created
    [SerializeField] bool straightLine;
    [SerializeField] bool jumpLine;
    [SerializeField] bool slideLine;

    


    void OnEnable()                             // Perform the actions as soon as the script is brought online
    {

        if ((!straightLine) && (!jumpLine) && (!slideLine))
        {
            Debug.LogError("You need to select a coin line type");
            return;
        }

        if ((straightLine) && (jumpLine))
        {
            Debug.LogError("You can only select one coin line type");
            return;
        }

        if (straightLine)
       {
            CoinLine = CollectablePooler.Instance.GetStraightLineCoinsPooledObject();            // Call GetStraightLineCoinsPooledObject from CollectablePooler script and retun a gameobject
            CoinLine.transform.localPosition = Vector3.zero;                                    // Because magnet may have moved everything, restet to local positon

            // Set each Child object back to 0 position
           CoinLine.transform.GetChild(0).gameObject.transform.localPosition = Vector3.zero;
           CoinLine.transform.GetChild(1).gameObject.transform.localPosition = Vector3.zero;
           CoinLine.transform.GetChild(2).gameObject.transform.localPosition = Vector3.zero;


            CoinLine.transform.localPosition = this.transform.position;                  // Set Gameobject position to be position of this gameobject

            // define the localtion of each child object in relation to spawn point
            CoinLine.transform.GetChild(0).gameObject.transform.position = this.transform.position + new Vector3(0f, 0.5f, 0f);
            CoinLine.transform.GetChild(1).gameObject.transform.position = this.transform.position + new Vector3(0f, 0.5f, 2f);
            CoinLine.transform.GetChild(2).gameObject.transform.position = this.transform.position + new Vector3(0f, 0.5f, 4f);

            CoinLine.SetActive(true);                                                    // Show the gameobject in the game world
            CoinLine.transform.GetChild(0).gameObject.SetActive(true);                  // enbale each child obejct
            CoinLine.transform.GetChild(1).gameObject.SetActive(true);                  // enbale each child obejct
            CoinLine.transform.GetChild(2).gameObject.SetActive(true);                  // enbale each child obejct
        }

        if (slideLine)
        {
            CoinLine = CollectablePooler.Instance.GetStraightLineCoinsPooledObject();            // Call GetStraightLineCoinsPooledObject from CollectablePooler script and retun a gameobject
            CoinLine.transform.localPosition = Vector3.zero;                                    // Because magnet may have moved everything, restet to local positon

            // Set each Child object back to 0 position
            CoinLine.transform.GetChild(0).gameObject.transform.localPosition = Vector3.zero;
            CoinLine.transform.GetChild(1).gameObject.transform.localPosition = Vector3.zero;
            CoinLine.transform.GetChild(2).gameObject.transform.localPosition = Vector3.zero;


            CoinLine.transform.localPosition = this.transform.position;                  // Set Gameobject position to be position of this gameobject

            // define the localtion of each child object in relation to spawn point
            CoinLine.transform.GetChild(0).gameObject.transform.position = this.transform.position + new Vector3(0f, 0.5f, 0f);
            CoinLine.transform.GetChild(1).gameObject.transform.position = this.transform.position + new Vector3(0f, 0.5f, 2f);
            CoinLine.transform.GetChild(2).gameObject.transform.position = this.transform.position + new Vector3(0f, 0.5f, 4f);

            CoinLine.SetActive(true);                                                    // Show the gameobject in the game world
            CoinLine.transform.GetChild(0).gameObject.SetActive(true);                  // enbale each child obejct
            CoinLine.transform.GetChild(1).gameObject.SetActive(true);                  // enbale each child obejct
            CoinLine.transform.GetChild(2).gameObject.SetActive(true);                  // enbale each child obejct
        }

        if (jumpLine)
        {
            CoinLine = CollectablePooler.Instance.GetJumpLineCoinsPooledObject();            // Call GetJumpLineCoinsPooledObject from CollectablePooler script and retun a gameobject
            CoinLine.transform.localPosition = Vector3.zero;                                    // Because magnet may have moved everything, restet to local positon
            // Set each Child object back to 0 position
            CoinLine.transform.GetChild(0).gameObject.transform.localPosition = Vector3.zero;
            CoinLine.transform.GetChild(1).gameObject.transform.localPosition = Vector3.zero;
            CoinLine.transform.GetChild(2).gameObject.transform.localPosition = Vector3.zero;
           CoinLine.transform.GetChild(3).gameObject.transform.localPosition = Vector3.zero;
            CoinLine.transform.GetChild(4).gameObject.transform.localPosition = Vector3.zero;
            CoinLine.transform.localPosition = this.transform.position;                  // Set Gameobject position to be position of this gameobject

            // define the localtion of each child object in relation to spawn point
            CoinLine.transform.GetChild(0).gameObject.transform.position = this.transform.position + new Vector3(0f, 0.3f, -3.5f);
            CoinLine.transform.GetChild(1).gameObject.transform.position = this.transform.position + new Vector3(0f, 1.2f, 0f);
            CoinLine.transform.GetChild(2).gameObject.transform.position = this.transform.position + new Vector3(0f, 0.8f, 1.5f);
            CoinLine.transform.GetChild(3).gameObject.transform.position = this.transform.position + new Vector3(0f, 0.3f, 3.5f);
            CoinLine.transform.GetChild(4).gameObject.transform.position = this.transform.position + new Vector3(0f, 0.8f, -1.6f);
            CoinLine.SetActive(true);                                                    // Show the gameobject in the game world
            CoinLine.transform.GetChild(0).gameObject.SetActive(true);                  // enbale each child obejct
            CoinLine.transform.GetChild(1).gameObject.SetActive(true);                  // enbale each child obejct
            CoinLine.transform.GetChild(2).gameObject.SetActive(true);                  // enbale each child obejct
            CoinLine.transform.GetChild(3).gameObject.SetActive(true);                  // enbale each child obejct
            CoinLine.transform.GetChild(4).gameObject.SetActive(true);                  // enbale each child obejct
        }
   
    }
}
