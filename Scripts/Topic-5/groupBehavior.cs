using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// LoadLevel Script - Topic 5 CLC - by Andrew Esch (Team 9)
// Statement of Own Work: We certify that this program is our own work and ideas, verifying that no help was provided.
// We are aware that the incorporation of material from other's work without acknowledgement is treated as plagiarism.

public class groupBehavior : MonoBehaviour
{
    // Define Enemy Game Objects
    public GameObject p1, p2, p3;
    public GameObject e1, e2, e3;
    public float activateDistance = 4f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get Player 1's distance to enemies
        var e1distance = Vector3.Distance(p1.transform.position, e1.transform.position);
        var e2distance = Vector3.Distance(p1.transform.position, e2.transform.position);
        var e3distance = Vector3.Distance(p1.transform.position, e3.transform.position);
        
        // If any enemy is within range, change all activated players to the color green (to resemble the emotion of fear)
        if (e1distance <= activateDistance || e2distance <= activateDistance || e3distance <= activateDistance)
        {
            p1.GetComponent<Renderer>().material.color = new Color(153, 50, 204);
            p2.GetComponent<Renderer>().material.color = new Color(153, 50, 204);
            p3.GetComponent<Renderer>().material.color = new Color(153, 50, 204);
        }
    }
}
