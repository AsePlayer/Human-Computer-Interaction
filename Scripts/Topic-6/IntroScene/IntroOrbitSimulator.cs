using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;
using System;

public class IntroOrbitSimulator : MonoBehaviour
{
    // Define gravitational variables
    public GameObject planet, rocket;
    private Vector3 planetPosition, rocketPosition;
    public float planetMass = 1000000000000.0f; // Variable: m1
    public float rocketMass = 10000.0f; // Variable: m2
    public Vector3 startVelocity = new Vector3(-40, 20, 0f);
    public float rotateSpeed = 1.2f;

    // Define launch conditions
    private bool launched;

    // Start is called before the first frame update
    void Start()
    {
        // Launch rocket
        rocket.transform.GetComponent<Rigidbody>().AddForce(startVelocity, ForceMode.VelocityChange);
        launched = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Update gravitional force over time
        if (launched)
        {
            calculateGravityVector();
            rotateAroundPlanet();
        }
    }

    private void calculateGravityVector()
    {
        // Variable: r
        Vector3 diff = planet.transform.position - rocket.transform.position;
        float distance = diff.magnitude;

        // Direction Vector
        Vector3 gravityDirection = diff.normalized;

        // Variable: G
        float gravitationalConstant = 6.67408f * Mathf.Pow(10, -11);

        // Force of Gravity: Fg = G*(m1*m2)/(r^2)
        float gravitationalForce = (gravitationalConstant * planetMass * rocketMass) / (distance * distance);
        Vector3 gravityVector = (gravityDirection * gravitationalForce);

        // Update gravity vector and rotation
        rocket.transform.GetComponent<Rigidbody>().AddForce(gravityVector, ForceMode.Acceleration);
    }

    private void rotateAroundPlanet()
    {
        rocket.transform.rotation *= Quaternion.AngleAxis(rotateSpeed * Time.deltaTime, Vector3.right);
    }
}
