using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinObject : MonoBehaviour
{
    public float xTheta, yTheta, zTheta = 0;
    public GameObject gameObject1;
    public GameObject gameObject2;
    public GameObject gameObject3;

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == gameObject2.name)
        {
            gameObject1.transform.Rotate(xTheta, yTheta, zTheta, Space.Self);
            gameObject3.transform.Rotate(xTheta, yTheta, zTheta, Space.Self);
        }
    }
}
