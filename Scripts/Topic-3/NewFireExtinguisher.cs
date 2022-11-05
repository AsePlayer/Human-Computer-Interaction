using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFireExtinguisher : MonoBehaviour
{
    // Define Connector GameObjects
    public GameObject player, fireExtinguisher;
    private GameObject go2;

    // Define Connector Lines
    public LineRenderer l;
    private LineRenderer l1;

    // Define positions, transforms, and speed
    private List<Vector3> pos;
    private int flag;
    private Transform myTransform;
    public float speed = 5.0f;

    // Player statistics
    public float moveSpeed = 3.0f;
    public float rotateSpeed = 25.0f;
    private Vector3 playerLocation;

    // Define Particle System
    public ParticleSystem ps;
    private bool extinguisherEnabled;

    private void Start()
    {
        // Add line objects to scene for new lines, since an object cannot have multiple Line Renderer components
        l1 = Instantiate(l, transform);

        // Add position vectors
        pos = new List<Vector3>();

        flag = 0;

        // Set gameObjects to player by default
        go2 = player;

        // Disable Particle System on start
        var emission = ps.emission;
        extinguisherEnabled = false;
        emission.enabled = false;
    }

    void Update()
    {
        // Update player location, associated with FireExtinguisher location
        playerLocation = player.transform.position;

        if (go2 != player)
        {
            go2.transform.position = new Vector3(playerLocation.x, playerLocation.y + 1.5f, playerLocation.z + 2.75f);
            go2.transform.rotation = player.transform.rotation;
        }

        // Draw line to connect two objects
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Select & Deselect code (uses Mouse input)
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0) && GameObject.Find(hit.transform.name) == go2)
        {
            go2 = player;
        }
        else if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0) && GameObject.Find(hit.transform.name) == fireExtinguisher)
        {
            go2 = fireExtinguisher;
        }

        // Set line from player to go2
        pos.Clear();
        pos.Add(player.transform.position);
        pos.Add(go2.transform.position);
        l1.startWidth = 0.1f;
        l1.endWidth = 0.01f;
        l1.SetPositions(pos.ToArray());
        l1.useWorldSpace = true;

        myTransform = go2.GetComponent<Transform>();

        // Move right using arrow key
        if (Input.GetKey(KeyCode.RightArrow))
        {
            player.transform.Translate(new Vector3(moveSpeed * Time.deltaTime, 0, 0));
        }

        // Move left using arrow key
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            player.transform.Translate(new Vector3(-moveSpeed * Time.deltaTime, 0, 0));
        }

        // Move backwards using arrow key
        if (Input.GetKey(KeyCode.DownArrow))
        {
            player.transform.Translate(new Vector3(0, 0, -moveSpeed * Time.deltaTime));
        }

        // Move forward using arrow key
        if (Input.GetKey(KeyCode.UpArrow))
        {
            player.transform.Translate(new Vector3(0, 0, moveSpeed * Time.deltaTime));
        }

        // Rotate up using "W" key
        if (Input.GetKey("w"))
        {
            player.transform.Rotate(-rotateSpeed * Time.deltaTime, 0.0f, 0.0f, Space.World);
        }

        // Rotate down using "S" key
        if (Input.GetKey("s"))
        {
            player.transform.Rotate(rotateSpeed * Time.deltaTime, 0.0f, 0.0f, Space.World);
        }

        // Rotate left using "A" key
        if (Input.GetKey("a"))
        {
            player.transform.Rotate(0.0f, -rotateSpeed * Time.deltaTime, 0.0f, Space.World);
        }

        // Rotate right using "D" key
        if (Input.GetKey("d"))
        {
            player.transform.Rotate(0.0f, rotateSpeed * Time.deltaTime, 0.0f, Space.World);
        }

        // Activate FireExtinguisher using "E" key
        if (Input.GetKey("e"))
        {
            if (go2 != player)
            {
                extinguisherEnabled = true;
            }
        }

        // Deactivate FireExtinguisher using "R" key
        if (Input.GetKey("r"))
        {
            extinguisherEnabled = false;
        }

        ActivateExtinguisher(extinguisherEnabled);
    }

    private void ActivateExtinguisher(bool enabled)
    {
        // If enabled, send the player backwards & give the FireExtinguisher a smoke particle effect
        if (enabled)
        {
            player.transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
        }

        var emission = ps.emission;
        emission.enabled = enabled;
    }
}