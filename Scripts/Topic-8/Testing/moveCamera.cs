 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveCamera : MonoBehaviour
{
    public float speed = 80.0f;
    public float camPos = 0.0f;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Scene m_Scene = SceneManager.GetActiveScene();

        if (Input.GetKey("w"))
        {
            transform.Translate(new Vector3(0.1f, 0, 0));
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(new Vector3(-0.1f, 0, 0));
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(new Vector3(0, 0, 0.1f));
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(new Vector3(0, 0, -0.1f));
        }

        if (Input.GetKey("u"))
        {
            transform.Translate(new Vector3(0, 0, -speed * Time.deltaTime));
            camPos = camPos - speed;
            Debug.Log("camPos=" + camPos);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));

            camPos = camPos + speed;
            Debug.Log("camPos=" + camPos);
            if ((camPos > 400.0f) && (m_Scene.name == "DataPlot"))
                SceneManager.LoadScene("Insight");
        }

        if (Input.GetKey("r"))
        {
            transform.Rotate(new Vector3(0, speed * Time.deltaTime, 0));
        }

        ////reading the input:
        //float horizontalAxis = CrossPlatformInputManager.GetAxis("Horizontal");
        //float verticalAxis = CrossPlatformInputManager.GetAxis("Vertical");

        ////assuming we only using the single camera:
        //var camera = Camera.main;

        ////camera forward and right vectors:
        //var forward = camera.transform.forward;
        //var right = camera.transform.right;

        ////project forward and right vectors on the horizontal plane (y = 0)
        //forward.y = 0f;
        //right.y = 0f;
        //forward.Normalize();
        //right.Normalize();

        ////this is the direction in the world space we want to move:
        //var desiredMoveDirection = forward * verticalAxis + right * horizontalAxis;

        ////now we can apply the movement:
        //transform.Translate(desiredMoveDirection * speedMeUp * Time.deltaTime);
    }
}
