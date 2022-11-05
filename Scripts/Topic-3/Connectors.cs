using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connectors : MonoBehaviour
{
    public GameObject go1;

    private GameObject go2;
    private LineRenderer l;
    private List<Vector3> pos;
    private int flag;
    private Transform myTransform;
    private float speed = 5.0f;

    private void Start()
    {
        l = gameObject.AddComponent<LineRenderer>();
        pos = new List<Vector3>();
        flag = 0;
        go2 = GameObject.Find("CubeA");

    }

    void Update()
    {
        // Draw line to connect two objects
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
       // Debug.Log(go2.name);
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButtonDown(0))
        {
            go2 = GameObject.Find(hit.transform.name);
            var v2: Vector3 = Vector3(.5f, .5f, .5f);
            go2.transform.localScale = Vector3.Scale(v2, go2.transform.localScale); 
        }

        pos.Clear();
        pos.Add(go1.transform.position);
        pos.Add(go2.transform.position);
        l.startWidth = 0.1f;
        l.endWidth = 0.01f;
        l.SetPositions(pos.ToArray());
        l.useWorldSpace = true;

        myTransform = go2.GetComponent<Transform>();

        if (Input.GetKey(KeyCode.RightArrow))
        {
         

            if (myTransform.position.x < 9)
            {
                myTransform.Translate(new Vector3(speed * Time.deltaTime, 0,0));
               // Debug.Log("Position X: " + myTransform.position.x);
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
         

            if (myTransform.position.x > -9)
            {
                myTransform.Translate(new Vector3(-speed * Time.deltaTime, 0,0));
                //Debug.Log("Position X: " + myTransform.position.x);
            }
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
          

            if (myTransform.position.y < 9)
            {
                myTransform.Translate(new Vector3(0, speed * Time.deltaTime,0));
                //Debug.Log("Position y: " + myTransform.position.x);
            }
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
           

            if (myTransform.position.y > -9)
            {
                myTransform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
                //Debug.Log("Position y: " + myTransform.position.x);
            }
        }
    }
}