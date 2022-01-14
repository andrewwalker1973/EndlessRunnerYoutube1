using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{

    public GameObject platformDestructionPoint;
    // Start is called before the first frame update
    void Start()
    {
        platformDestructionPoint = GameObject.Find("DestructionPoint");         // find the platform desruction point attached to the camera
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < platformDestructionPoint.transform.position.z)   // if gameobject past the point disable it
        {

            gameObject.SetActive(false);        // Disable the game object and have it availbe in the platform pool
        }
    }
}
