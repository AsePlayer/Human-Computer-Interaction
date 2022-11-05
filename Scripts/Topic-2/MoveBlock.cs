using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    public float speed = 5.0f;
    protected Transform myTransform;
    void Start()
    {
        Debug.Log("Tada");
    }

    // Update is called once per frame
    void Update()
    {
        myTransform = GetComponent<Transform>();

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
            Debug.Log("Position Y: " + myTransform.position.y);
        }

    }
}