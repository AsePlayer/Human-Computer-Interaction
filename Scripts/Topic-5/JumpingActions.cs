using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// LoadLevel Script - Topic 5 CLC - by Andrew Esch (Team 9)
// Statement of Own Work: We certify that this program is our own work and ideas, verifying that no help was provided.
// We are aware that the incorporation of material from other's work without acknowledgement is treated as plagiarism.

public class JumpingActions : MonoBehaviour
{
    // Define jumpHeight variable for user
    // Define onGround boolean and jump counters
    
    public float jumpHeight;
    private bool isOnGround;
    private int inAirCounter;
    private int totalJumpCounter;

    // Define backflip variables
    public Vector3 backflipDirection = new Vector3(1,0,0);
    public float backflipDuration;
    private float convertTime = 200;
    private float totalTime;

    // Start is called before the first frame update
    void Start()
    {
        // Set grounded to true
        isOnGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        // If the player is on the ground and presses the "E" key, then jump!
        if (Input.GetKeyDown("e") && isOnGround)
        {
            transform.Translate(new Vector3(0f, jumpHeight, 0f));
            inAirCounter++;
            totalJumpCounter++;
            isOnGround = false;

        } else if (Input.GetKeyDown("e") && inAirCounter == 1)
        {
            // While in the air, the player can double jump! However, after the second jump, they cannot jump anymore.
            transform.Translate(new Vector3(0f, jumpHeight, 0f));
            inAirCounter = 0;
            totalJumpCounter++;

            // If the total jump counter exceeds 5, make the player backflip during the double jump!
            if (totalJumpCounter >= 5)
            {
                totalTime = Time.deltaTime * backflipDuration * convertTime;
                transform.Rotate(backflipDirection * totalTime);
                totalJumpCounter = 0;
            }
        }

    }

    // While on the groumd, set grounded variable to true.
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.transform.parent.name == "FloorObject")
        {
            isOnGround = true;
        }
    }
}
