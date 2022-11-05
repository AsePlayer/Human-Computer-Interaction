using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMovement : MonoBehaviour
{
    // Define Spiral Variables
    public int frequency = 2;
    public float keys = 20;
    public float amplitude = 10f;
    public float radius = 10f;
    public float zVal = 1f;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        CreateSpiral();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateSpiral()
    {
        // Define Particle System and turn on "velocityovertime"
        ParticleSystem ps = GetComponent<ParticleSystem>();
        var vel = ps.velocityOverLifetime;
        vel.enabled = true;
        vel.space = ParticleSystemSimulationSpace.Local;

        // Set start speed
        var main = ps.main;
        main.startSpeed = 0f;

        // Create Animated X Curve
        AnimationCurve curveX = new AnimationCurve();
        for (int i = 0; i < keys; i++)
        {
            float timeX = (i / (keys - 1));
            float val = amplitude * Mathf.Sin(timeX * (frequency * 2) * Mathf.PI); // Define x coordinates of the spiral by sine wave

            curveX.AddKey(timeX, val);//add the calculated point to the curve
        }
        vel.x = new ParticleSystem.MinMaxCurve(radius, curveX);

        // Create Animated Y Curve
        AnimationCurve curveY = new AnimationCurve();
        for (int i = 0; i < keys; i++)
        {
            float timeY = (i / (keys - 1));
            float val = amplitude * Mathf.Cos(timeY * (frequency * 2) * Mathf.PI); // Define y coordinates of the spiral by cosine wave

            curveY.AddKey(timeY, val);
        }
        vel.y = new ParticleSystem.MinMaxCurve(radius, curveY);

        // Create Simple Animated Z Curve
        AnimationCurve curveZ = new AnimationCurve();
        time = 0f;
        curveZ.AddKey(time, zVal);
        vel.z = new ParticleSystem.MinMaxCurve(radius, curveZ);
    }
}
