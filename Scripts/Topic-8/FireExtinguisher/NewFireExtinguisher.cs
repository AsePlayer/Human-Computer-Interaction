using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFireExtinguisher : MonoBehaviour
{
    // Define Connector GameObjects
    public GameObject player, fireExtinguisher;
    private GameObject go2;

    // Define positions, transforms, and speed
    private List<Vector3> pos;
    private int flag;
    private Transform myTransform;
    public float speed = 5.0f;

    // Define Particle System
    public ParticleSystem ps;
    Rigidbody rb;

    void Start()
    {
        // Disable Particle System on start
        rb = player.transform.GetChild(0).GetComponent<Rigidbody>();
        var emission = ps.emission;
        emission.enabled = false;
    }

    void Update()
    {
        // Activate FireExtinguisher using "A" oculus key

        if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch))
        {
            ActivateExtinguisher();
        } else if (Input.GetKey("w")) {
            ActivateExtinguisher();
        }
        else
        {
            var emission = ps.emission;
            emission.enabled = false;
        }
    }

    private void ActivateExtinguisher()
    {
        // If enabled, send the player backwards & give the FireExtinguisher a smoke particle effect
        Vector3 dir = -1 * fireExtinguisher.transform.forward * speed;
        rb.velocity = dir;
        var emission = ps.emission;
        emission.enabled = true;
    }
}