/*

Authors: Andrew Esch
Date: 9/11/2021

Statement of Own Work: We certify that this program is our work and ideas, verifying that no help was provided.
We are aware that the incorporation of material from other's work without acknowledgement is treated as plagiarism.

*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Duplicate_Cubes : MonoBehaviour
{
    public GameObject cube1;
    public GameObject cube2;

    // Start is called before the first frame update
    void Start()
    {
        cube1 = GameObject.Find("Cube1");
        cube2 = GameObject.Find("Cube2");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("o"))
        {
            Debug.Log("Duplicated");

            GameObject clone1;
            GameObject clone2;

            float x = Random.Range(-10.0f, 10.0f);
            float z = Random.Range(-10.0f, 10.0f);

            var pos1 = new Vector3(x, 4f, z);
            var pos2 = new Vector3(x, 0.5f, z);

            clone1 = Instantiate(cube1, pos1, transform.rotation);
            clone2 = Instantiate(cube2, pos2, transform.rotation);
        }
    }
}
