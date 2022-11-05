using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireExtinguisher : MonoBehaviour
{
    // Prototype script, but will work with more code based on OVRPlayer and angles from in-game
    // Work in progress

    public float speed = 1f;
    protected Transform myTransform;
    public GameObject fireExtinguisher;
    public GameObject player;
    private float angle;

    // Update is called once per frame
    void Update()
    {
        // Update angle based on angle of the fire extinguisher
        angle = fireExtinguisher.rotation.x;

        // Launch Player using the 
        if (Input.GetKey(KeyCode.E))
        {
            LaunchPlayer(player.transform);
        }
    }

    private void LaunchPlayer(Vector3 direction)
    {
        // Create velocity vector through updating FireExtinguisher variables
        newDirection = new Vector3(direction.x, direction.y, direction.z);
        var velocity = playerVelocity(newDirection*speed, angle+180f);

        // Update velocity of player
        player.transform.Translate(velocity);
    }
}
