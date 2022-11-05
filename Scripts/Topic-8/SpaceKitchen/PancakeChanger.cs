using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PancakeChanger : MonoBehaviour
{
    public Color targetColor = new Color(0, 1, 0, 1); 
    private Material materialToChangeBottom, materialToChangeTop;
    public GameObject pan;
    public GameObject pancakeBottom, pancakeTop;
    float timeBottom, timeTop;
    bool isCollisionBottom = false;
    bool isCollisionTop = false;
    public float duration = 100000f;
    public float cooldown = 0.5f;
    private float waitTime;

    private float rot = 0f;

    public AudioSource sizzle;

    void Start()
    {
        materialToChangeBottom = pancakeBottom.GetComponent<Renderer>().material;
        materialToChangeTop = pancakeTop.GetComponent<Renderer>().material;
        timeBottom = 0f;
        timeTop = 0f;
        sizzle.Play(0);
        sizzle.Pause();
    }


    void OnCollisionEnter(Collision c)
    {
        if (c.gameObject.name == pan.name)
        {
            sizzle.UnPause();

            if (rot == 180f)
            {
                Debug.Log("Top");
                isCollisionTop = true;
            }
            else
            {
                Debug.Log("Bottom");
                isCollisionBottom = true;
            }
        }
    }


    void OnCollisionExit(Collision c)
    {
        if (c.gameObject.name == pan.name)
        {
            sizzle.Pause();

            if (rot == 180f)
            {
                isCollisionTop = false;
            }
            else
            {
                isCollisionBottom = false;
            }
        }
    }

    void Update()
    {
        if (waitTime < cooldown + 0.1f)
        {
            waitTime += Time.deltaTime;
        }

        if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch) || Input.GetKey("a"))
        {
            if (waitTime >= cooldown)
            {
                waitTime = 0f;
                Vector3 rotx = transform.rotation.eulerAngles;

                if (rot == 0)
                {
                    rot = 180f;
                }
                else
                {
                    rot = 0f;
                }

                rotx = new Vector3(rot, rotx.y, rotx.z);
                transform.rotation = Quaternion.Euler(rotx);
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z);
            }
        }
        if (isCollisionBottom)
        {

            Color endValue = targetColor; 
            Color startValue = materialToChangeBottom.color;

            //Debug.Log("Does it work"); 
            if(timeBottom < duration)
            {
                materialToChangeBottom.color = Color.Lerp(startValue, endValue, timeBottom / duration);
                timeBottom += Time.deltaTime;
            }
            else
            {
                materialToChangeBottom.color = endValue;
            }
            
        }

        if (isCollisionTop)
        {
            Color endValue = targetColor;
            Color startValue = materialToChangeTop.color;

            if (timeTop < duration)
            {
                materialToChangeTop.color = Color.Lerp(startValue, endValue, timeTop / duration);
                timeTop += Time.deltaTime;
            }
            else
            {
                materialToChangeTop.color = endValue;
            }

        }
    }
}