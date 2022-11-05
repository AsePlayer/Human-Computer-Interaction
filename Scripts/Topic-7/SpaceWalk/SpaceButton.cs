using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 positionToMoveTo; 
    private Vector3 origin; 
    void Start()
    {
        origin = transform.position; 
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
                if (hit.transform.name == gameObject.name) 
                {  
                    StartCoroutine(ButtonDown(positionToMoveTo, 2)); 
                    Debug.Log("Button Clicked"); 
                }  
            }  
        }
    }

    IEnumerator ButtonDown(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
        }
        
        transform.position = targetPosition;
        yield return new WaitForSeconds(1); 

        time = 0;
        startPosition = transform.position;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, origin, time / duration);
            time += Time.deltaTime;
        }
        
        transform.position = origin;
 
    }

}
