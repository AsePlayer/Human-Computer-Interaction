using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PancakeChanger : MonoBehaviour
{
    public Color targetColor = new Color(0, 1, 0, 1); 
    public Material materialToChange;
    public GameObject pan; 
    float time;
    bool isCollision = false;

    public AudioSource sizzle;

    void Start()
    {
        materialToChange = gameObject.GetComponent<Renderer>().material;
        time = 0;
        sizzle.Play(0);
        sizzle.Pause();
    }


    void OnTriggerEnter(Collider trigger)
    {
        // if(collision.Gameobject.name == pan.name)
        // {
        // }
        //this.col = col; 
        Debug.Log("Enter"); 
        isCollision = true;
        sizzle.UnPause();
    }


    void OnTriggerExit(Collider trig)
    {
        Debug.Log("Exit"); 
        isCollision = false;
        //this.col = col; 
        sizzle.Pause();
    }

    void Update()
    {
        if(isCollision)
        {

            Color endValue = targetColor; 
            float duration = 1000; 

            Color startValue = materialToChange.color;

            //Debug.Log("Does it work"); 
            if(time< duration)
            {
                materialToChange.color = Color.Lerp(startValue, endValue, time / duration);
                time += Time.deltaTime;
            }
            else
            {
                materialToChange.color = endValue; 
            }
            
        }
    }
}