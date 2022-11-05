using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject star;
    public GameObject planet;
    private float radius, x, y, z, px, py, theta, delta;

    void Start() {
        star = GameObject.Find("Star1");

        Debug.Log("Star position: " + star.transform.position);
        Debug.Log("Planet A position: " + planet.transform.position);

        x = star.transform.position.x;
        y = star.transform.position.y;
        z = star.transform.position.z;
        radius = 2.0f;
        theta = 0;
        delta = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        CircularOrbit();

    }

    void CircularOrbit()
    {
        theta = theta + delta;
        px = x+0.7f + radius * Mathf.Cos(theta);
        py = y + radius * Mathf.Sin(theta);
        Vector3 planetPosition = new Vector3(px, py, z);
        planet.transform.position = planetPosition;
    }
}
