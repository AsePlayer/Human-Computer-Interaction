using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// LoadLevel Script - Topic 5 CLC - by Andrew Esch (Team 9)
// Statement of Own Work: We certify that this program is our own work and ideas, verifying that no help was provided.
// We are aware that the incorporation of material from other's work without acknowledgement is treated as plagiarism.

public class lockRotation : MonoBehaviour
{
    // Define rotation variable and transformation
    public float fixedRotation;
    Transform t;

    void Start()
    {
        // Define transformation
        t = transform;
    }

    void Update()
    {
        // Force the rotation to be locked at a user specified angle
        t.eulerAngles = new Vector3(t.eulerAngles.x, fixedRotation, t.eulerAngles.z);
    }
}
