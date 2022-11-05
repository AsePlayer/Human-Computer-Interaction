using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveIt : MonoBehaviour
{
    private GameObject go;

    private List<Vector3> pos;

    private Transform myTransform;
    private float speed = 5.0f;

    private void Start()
    {
        go = GameObject.Find("Target");
    }

    void Update()
    {
        myTransform = go.GetComponent<Transform>();

        if (Input.GetKey(KeyCode.RightArrow))
        {     
                myTransform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myTransform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            myTransform.Translate(new Vector3(speed * Time.deltaTime,0,0));
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            myTransform.Translate(new Vector3(-speed * Time.deltaTime,0,0));
        }
    }
}