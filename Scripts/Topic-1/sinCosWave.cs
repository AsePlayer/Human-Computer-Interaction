using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sinCosWave : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject cube1;
    public GameObject cube2;

    float index;
    private float sinWidth, sinWidth2;


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision has been made!");
        Color color2 = cube2.GetComponent<Renderer>().material.GetColor("_Color");

        if(collision.gameObject.name == "Cube")
        {
            //Grab the color of what hit me and change the color
            GetComponent<Renderer>().material.color = collision.gameObject.GetComponent<Renderer>().material.GetColor("_Color");
            cube1.GetComponent<Renderer>().material.color = color2;
            Debug.Log("colors swapped!");
        }

    }

    private void Update()
    {
        //Sin and Cos width values
        index += Time.deltaTime;
        sinWidth = 3 * Mathf.Cos(1 * index);
        sinWidth2 = 3 * Mathf.Sin(1 * index);

        //Sin and Cos scale transform on the cubes
        cube1.transform.localScale = new Vector3(sinWidth, 1.0f, 1.0f);
        cube2.transform.localScale = new Vector3(sinWidth2, 1.0f, 1.0f);
     
    }


}
