using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// LoadLevel Script - Topic 5 CLC - by Andrew Esch, Diego Guerra, and Ryan Scott (Team 9)
// Statement of Own Work: We certify that this program is our own work and ideas, verifying that no help was provided.
// We are aware that the incorporation of material from other's work without acknowledgement is treated as plagiarism.

public class FollowPlayer : MonoBehaviour
{
    // Define follow speed and stop distance for player
    public float followSpeed = 5;
    public float stopDistance = 2;
    public float maxDistance = 5;
    public GameObject player;

    Transform playerTransform;

    void GetPlayerTransform()
    {
        // Look at player by getting rotation
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.Log("Player not specified in Inspector");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initialize Follower
        GetPlayerTransform();
        //transform.rotation = new Quaternion(270f, 0f, 0f, Space.Self);
        transform.Rotate(270.0f, 0.0f, 0.0f, Space.Self);
    }

    // Update is called once per frame
    void Update()
    {
        // Look at player
        transform.LookAt(player.transform);

        // If player distance is greater than stop distance, follow the player!
        var distance = Vector3.Distance(playerTransform.position, transform.position);
        if (distance >= stopDistance && distance <= maxDistance)
        {
            transform.position += transform.forward * followSpeed * Time.deltaTime;
        }
    }
}