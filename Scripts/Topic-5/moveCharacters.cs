using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// LoadLevel Script - Topic 5 CLC - by Andrew Esch (Team 9)
// Statement of Own Work: We certify that this program is our own work and ideas, verifying that no help was provided.
// We are aware that the incorporation of material from other's work without acknowledgement is treated as plagiarism.

public class moveCharacters : MonoBehaviour
{
    // Define variables
    public GameObject player1, player2;
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Move two players with arrow keys
        // If shift is being pressed, move player 2 in specified direction
        // Otherwise, move player 1 in specified arrow key direction
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                player2.transform.Translate(new Vector3(0.1f * speed, 0, 0));
            }
            else
            {
                player1.transform.Translate(new Vector3(0.1f * speed, 0, 0));
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                player2.transform.Translate(new Vector3(-0.1f * speed, 0, 0));
            }
            else
            {
                player1.transform.Translate(new Vector3(-0.1f * speed, 0, 0));
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                player2.transform.Translate(new Vector3(0, 0, 0.1f * speed));
            }
            else
            {
                player1.transform.Translate(new Vector3(0, 0, 0.1f * speed));
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                player2.transform.Translate(new Vector3(0, 0, -0.1f * speed));
            }
            else
            {
                player1.transform.Translate(new Vector3(0, 0, -0.1f * speed));
            }
        }
    }
}

