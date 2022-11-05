/*
Authors: Andrew Esch
Date: 9/16/2021
Statement of Own Work: I certify that this program is my work and ideas, verifying that no help was provided.
I am aware that the incorporation of material from other's work without acknowledgement is treated as plagiarism.
*/


// Remember, attach this to the OVR controller for this script to work!
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CloneObject : MonoBehaviour
{
    // Define the gameObject (in Unity Editor)
    public GameObject exampleObject;

    // Start is called before the first frame update
    void Start()
    {
        // Or, you can define GameObject on start!
        // exampleObject = GameObject.Find("newCube");
    }

    // Update is called once per frame
    void Update()
    {
        // Define when we should clone the gameObject
        // For this example, have it occur when the user presses the key "c"
        if (Input.GetKeyDown("c"))
        {
            Debug.Log("Cloned object");

            // Define new variable for cloning object
            GameObject clone;

            // Have the clone spawn at the coordinates (10 ,3, -10)
            var pos = new Vector3(10f, 3f, -10f);

            // Ensure the clone spawns with the rotation (0,0,0)
            transform.rotation = Quaternion.identity;

            // Use the Instantiate function to clone the object!
            clone = Instantiate(exampleObject, pos, transform.rotation);
        }
    }
}
