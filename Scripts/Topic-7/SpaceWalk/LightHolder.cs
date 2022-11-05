using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightHolder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Rigidbody rb; 
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "LightHolder")
        {
            Debug.Log ("Success!");
            rb = other.GetComponent<Rigidbody>(); 
            rb.isKinematic = true; 
        }
    }
}
