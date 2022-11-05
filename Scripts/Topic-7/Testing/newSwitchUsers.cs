using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// LoadLevel Script - Topic 5 CLC - by Andrew Esch (Team 9)
// Statement of Own Work: We certify that this program is our own work and ideas, verifying that no help was provided.
// We are aware that the incorporation of material from other's work without acknowledgement is treated as plagiarism.

public class newSwitchUsers : MonoBehaviour
{
    // Define gameObjects and text boxes
    public GameObject g2;
    public TMP_Text t1, t2;
    private TMP_Text temp1, temp2;

    // Start is called before the first frame update
    void Start()
    {
        // Switch text boxes at start to confuse the user
        temp1 = t1;
        temp2 = t2;
        t1.text = temp2.text;
        t2.text = temp1.text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision c)
    {
        // If the enemy and player collide, switch the text message
        if (c.gameObject.tag == g2.tag)
        {
            temp1.text = t1.text;
            t1.text = t2.text;
            t2.text = temp1.text;
        }
    }
}
