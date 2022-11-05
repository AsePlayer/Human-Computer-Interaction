using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// LoadLevel Script - Topic 5 CLC - by Andrew Esch (Team 9)
// Statement of Own Work: We certify that this program is our own work and ideas, verifying that no help was provided.
// We are aware that the incorporation of material from other's work without acknowledgement is treated as plagiarism.

// WORK IN PROGRESS; define more fine-tuned rocket path details for next CLC

public class rocketPath : MonoBehaviour
{
    // Define speed variable
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Launch the rocket upwards!
        transform.Translate(new Vector3(0, 0.1f * speed, 0));
    }
}
