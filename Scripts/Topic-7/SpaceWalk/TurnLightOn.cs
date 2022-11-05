using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLightOn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SpaceButton; 
    //public GameObject Holder; 
    bool isHolder; 
    bool isButtonClicked; 

    private Material mat; 
    public Color target; 
    public GameObject parent; 
    private Light lightbulb; 

    void Start()
    {
        isHolder = false; 
        isButtonClicked = false; 
        mat = gameObject.GetComponent<Renderer>().material; 
        lightbulb = parent.GetComponent<Light>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {  
            Debug.Log("Step1"); 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  
            RaycastHit hit;  
            if (Physics.Raycast(ray, out hit)) 
            {  
                Debug.Log("Step2");  
                Debug.Log(hit.collider.gameObject.name);  
                if (hit.transform.name == SpaceButton.name) 
                {  
                    isButtonClicked = !isButtonClicked;  
                    Debug.Log("Button Clicked"); 
                }  
            }  
        }  


        if(isButtonClicked == true && isHolder == true)
        {
            //mat.color = target; 
            lightbulb.enabled = true; 
        }
        if(isButtonClicked == false || isHolder == false)
        {
            lightbulb.enabled = false; 
        }
    } 

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Finish")
        {
            Debug.Log("Amoungus"); 
            isHolder = true; 
        }
    }


    
}
