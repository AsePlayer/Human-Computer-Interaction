using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;
using System;

public class OrbitSimulatorButtonManager : MonoBehaviour
{
    // Define gravitational variables
    public GameObject planet, rocket;
    private Vector3 planetPosition, rocketPosition;
    public Rigidbody rocketRigidBody;
    public float planetMass = 10000000000.0f; // Variable: m1
    public float rocketMass = 10000.0f; // Variable: m2
    public Vector3 startVelocity = new Vector3(0f, 10f, 0f);

    // Define button object
    public Button launchButton;

    // Define launch conditions
    private bool launched, launchMotion;

    public Text newPlanetMass, newRocketMass, newXVelocity, newYVelocity;

    // Start is called before the first frame update
    void Start()
    {
        launched = false;
        launchMotion = false;
        launchButton.onClick.AddListener(TaskOnClick_Main);
    }

    void TaskOnClick_Main()
    {
        // Launch rocket
        launched = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Update Launch Conditions
        planetMass = float.Parse(newPlanetMass.text.ToString());
        rocketMass = float.Parse(newRocketMass.text.ToString());
        startVelocity = new Vector3(float.Parse(newXVelocity.text.ToString()), float.Parse(newYVelocity.text.ToString()), 0f);

        // Update gravitional force over time
        if (launched)
        {
            rocketRigidBody.AddForce(startVelocity, ForceMode.VelocityChange);
            launched = false;
            launchMotion = true;
        }

        if (launchMotion)
        {
            rocketRigidBody.AddForce(calculateGravityVector(), ForceMode.Impulse);
        }
    }

    public Vector3 calculateGravityVector()
    {
        planetPosition = planet.transform.position;
        rocketPosition = rocket.transform.position;
        
        // Variable: r
        float distance = Vector3.Distance(planetPosition, rocketPosition);

        // Variable: G
        float gravitationalConstant = 6.67408f * Mathf.Pow(10, -11);
        
        // Force of Gravity: Fg = G*(m1*m2)/(r^2)
        float gravitationalForce = (gravitationalConstant * planetMass * rocketMass) / (distance * distance);

        Vector3 gravityDirection = planetPosition - rocketPosition;
        Vector3 forceVector = (gravitationalForce * (gravityDirection / gravityDirection.magnitude));
        return forceVector;
    }
}
