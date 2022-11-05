using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleConnectors : MonoBehaviour
{
    // Define Connector GameObjects
    public GameObject go1;
    private GameObject go2, go3, go4;

    // Define Connector Lines
    public LineRenderer l;
    private LineRenderer l1, l2, l3;

    // Define positions, transforms, and speed
    private List<Vector3> pos, pos2, pos3;
    private int flag;
    private Transform myTransform, myTransform2, myTransform3;
    private float speed = 5.0f;

    private void Start()
    {
        // Add line objects to scene for new lines, since an object cannot have multiple Line Renderer components
        l1 = Instantiate(l, transform);
        l2 = Instantiate(l, transform);
        l3 = Instantiate(l, transform);

        // Add position vectors
        pos = new List<Vector3>();
        pos2 = new List<Vector3>();
        pos3 = new List<Vector3>();

        flag = 0;

        // Set gameObjects to go1 by default
        go2 = go1;
        go3 = go1;
        go4 = go1;
    }

    void Update()
    {
        // Draw line to connect two objects
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        // Debug.Log(go2.name);


        /* 
         * Modified Code: Add the capability to select, deselect, and move three cubes at once
         * First, determine if a click in scene is a select or a deselect (start with checking deselects)
         * If the gameObject is already defined, deselect it
         * Otherwise, set the defined gameObjects in the following order: go2, go3, and go
         */

        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0) && GameObject.Find(hit.transform.name) == go4)
        {
            go4 = go1;
        } else if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0) && GameObject.Find(hit.transform.name) == go3)
        {
            go3 = go1;
        } else if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0) && GameObject.Find(hit.transform.name) == go2)
        {
            go2 = go1;
        } else if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0) && go3 != go1)
        {
            go4 = GameObject.Find(hit.transform.name);
        } else if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0) && go2 != go1)
        {
            go3 = GameObject.Find(hit.transform.name);
        } else if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
        {
            go2 = GameObject.Find(hit.transform.name);
        }

        // Set line from go1 to go2
        pos.Clear();
        pos.Add(go1.transform.position);
        pos.Add(go2.transform.position);
        l1.startWidth = 0.1f;
        l1.endWidth = 0.01f;
        l1.SetPositions(pos.ToArray());
        l1.useWorldSpace = true;

        // Set line from go1 to go3
        pos2.Clear();
        pos2.Add(go1.transform.position);
        pos2.Add(go3.transform.position);
        l2.startWidth = 0.1f;
        l2.endWidth = 0.01f;
        l2.SetPositions(pos2.ToArray());
        l2.useWorldSpace = true;

        // Set line from go1 to go4
        pos3.Clear();
        pos3.Add(go1.transform.position);
        pos3.Add(go4.transform.position);
        l3.startWidth = 0.1f;
        l3.endWidth = 0.01f;
        l3.SetPositions(pos3.ToArray());
        l3.useWorldSpace = true;

        // Get transforms of all objects
        myTransform = go2.GetComponent<Transform>();
        myTransform2 = go3.GetComponent<Transform>();
        myTransform3 = go4.GetComponent<Transform>();

        // Move all objects using arrow keys (if defined by mouse-click)
        // Note: To fix the accidentally moving gameObject go1, check to ensure that none of the
        // other defined GameObjects equal go1. If not, move the object in the specified direction.
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (myTransform.position.x < 9)
            {
                if (go2 != go1)
                {
                    myTransform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
                }

                if (go3 != go1)
                {
                    myTransform2.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
                }

                if (go4 != go1)
                {
                    myTransform3.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
                }
                // Debug.Log("Position X: " + myTransform.position.x);
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (myTransform.position.x > -9)
            {
                if (go2 != go1)
                {
                    myTransform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
                }

                if (go3 != go1)
                {
                    myTransform2.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
                }

                if (go4 != go1)
                {
                    myTransform3.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
                }
                //Debug.Log("Position X: " + myTransform.position.x);
            }
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (myTransform.position.y < 9)
            {
                if (go2 != go1)
                {
                    myTransform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
                }

                if (go3 != go1)
                {
                    myTransform2.Translate(new Vector3(0, speed * Time.deltaTime, 0));
                }

                if (go4 != go1)
                {
                    myTransform3.Translate(new Vector3(0, speed * Time.deltaTime, 0));
                }
                //Debug.Log("Position y: " + myTransform.position.x);
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (myTransform.position.y > -9)
            {
                if (go2 != go1)
                {
                    myTransform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
                }

                if (go3 != go1)
                {
                    myTransform2.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
                }

                if (go4 != go1)
                {
                    myTransform3.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
                }
                //Debug.Log("Position y: " + myTransform.position.x);
            }
        }
    }
}