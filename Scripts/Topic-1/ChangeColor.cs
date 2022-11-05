/*

Authors: Andrew Esch, Ryan Scott, Diego Guerra
Date: 9/11/2021

Statement of Own Work: We certify that this program is our work and ideas, verifying that no help was provided.
We are aware that the incorporation of material from other's work without acknowledgement is treated as plagiarism.

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    // To alter an object's velocity, assign a variable to the Rigidbody component
    public Rigidbody rbCube1;

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided");

        ContactPoint contact = collision.contacts[0];
        Vector3 position = contact.point;

        // Get the color of BottomCube before it changes
        GameObject cube2 = GameObject.Find("Cube2");
        Color color2 = cube2.GetComponent<Renderer>().material.GetColor("_Color");

        if (collision.gameObject.name == "Cube1")
        {
            GetComponent<Renderer>().material.color = collision.gameObject.GetComponent<Renderer>().material.GetColor("_Color");

            GameObject cube1 = GameObject.Find("Cube1");
            cube1.GetComponent<Renderer>().material.color = color2;
            Debug.Log("Colors Swapped");

            // Using the new Rigidbody variable, make Cube1 jump on Cube2 whenever collision occurs
            rbCube1.velocity = new Vector3(0, 5, 0);
            Debug.Log("Cube1 Jumped");
        }

        // Print out new color of bottom cube (in RGB)
        Debug.Log("Cube2 color:" + cube2.GetComponent<Renderer>().material.GetColor("_Color"));

    }

    // Updates on pressing start; Initial variables generated in runtime
    void Start()
    {
        // Assign Rigidbody variable to cube1
        GameObject cube1 = GameObject.Find("Cube1");
        rbCube1 = cube1.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
