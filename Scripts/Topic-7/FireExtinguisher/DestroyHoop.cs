using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DestroyHoop : MonoBehaviour
{
    public GameObject eventManager;

    void Start()
    {

    }

    void OnCollisionEnter(Collision c)
    {
        eventManager.GetComponent<GameGenerator>().currCount -= 1;
        eventManager.GetComponent<GameGenerator>().hoopsRemaining.GetComponent<TextMeshPro>().text = "Hoops Left: " + eventManager.GetComponent<GameGenerator>().currCount.ToString();
        Destroy(gameObject);
    }
}
