using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorInteractable : MonoBehaviour
{
    public GameObject player;
    public string loadingSceneName;
    public Material closeMaterial;
    public Color closeColor = Color.red;
    public Material openMaterial;
    public Color openColor = Color.blue;
    private MeshRenderer meshRenderer = null;
    public float activateDistance = 250f;
    public float enterDistance = 125f;
    private float pdistance;
    public float o = 1;
    private bool opened = false;

    private Vector3 startPos1, startPos2, startPos3;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        pdistance = Vector3.Distance(transform.position, player.transform.position);

        transform.GetChild(5).GetComponent<Light>().color = closeColor;
        transform.GetChild(4).GetComponent<Renderer>().material = closeMaterial;

        startPos1 = transform.GetChild(1).position;
        startPos2 = transform.GetChild(2).position;
        startPos3 = transform.GetChild(3).position;
    }

    void Update()
    {
        pdistance = Vector3.Distance(transform.position, player.transform.position);

        if (pdistance <= activateDistance && opened == false)
        {
            opened = true;
            StartCoroutine(OpenDoor(1.5f));
        }

        if (pdistance >= activateDistance && opened == true)
        {
            opened = false;
            StartCoroutine(CloseDoor(1.5f));
        }

        if (pdistance <= enterDistance)
        {
            SceneManager.LoadScene(loadingSceneName);
        }
    }

    IEnumerator OpenDoor(float duration)
    {
        // Move objects #2-3 for right side, move object #4 for left side
        float time = 0;
        Vector3 startValue1 = transform.GetChild(1).position;// Object #2
        Vector3 startValue2 = transform.GetChild(2).position; // Object #3
        Vector3 startValue3 = transform.GetChild(3).position; // Object #4

        Vector3 endValue1 = new Vector3(transform.GetChild(1).position.x - 100f*o, transform.GetChild(1).position.y, transform.GetChild(1).position.z);
        Vector3 endValue2 = new Vector3(transform.GetChild(2).position.x - 100f*o, transform.GetChild(2).position.y, transform.GetChild(2).position.z);
        Vector3 endValue3 = new Vector3(transform.GetChild(3).position.x + 100f*o, transform.GetChild(3).position.y, transform.GetChild(3).position.z);

        transform.GetChild(5).GetComponent<Light>().color = openColor;
        transform.GetChild(4).GetComponent<Renderer>().material = openMaterial;

        while (time < duration)
        {
            transform.GetChild(1).position = Vector3.Lerp(startValue1, endValue1, time / duration);
            transform.GetChild(2).position = Vector3.Lerp(startValue2, endValue2, time / duration);
            transform.GetChild(3).position = Vector3.Lerp(startValue3, endValue3, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(1);
    }

    IEnumerator CloseDoor(float duration)
    {
        // Move objects #2-3 for right side, move object #4 for left side
        float time = 0;
        Vector3 startValue1 = transform.GetChild(1).position; // Object #2
        Vector3 startValue2 = transform.GetChild(2).position; // Object #3
        Vector3 startValue3 = transform.GetChild(3).position; // Object #4

        Vector3 endValue1 = new Vector3(transform.GetChild(1).position.x + 100f*o, transform.GetChild(1).position.y, transform.GetChild(1).position.z);
        Vector3 endValue2 = new Vector3(transform.GetChild(2).position.x + 100f*o, transform.GetChild(2).position.y, transform.GetChild(2).position.z);
        Vector3 endValue3 = new Vector3(transform.GetChild(3).position.x - 100f*o, transform.GetChild(3).position.y, transform.GetChild(3).position.z);

        transform.GetChild(5).GetComponent<Light>().color = closeColor;
        transform.GetChild(4).GetComponent<Renderer>().material = closeMaterial;

        while (time < duration)
        {
            transform.GetChild(1).position = Vector3.Lerp(startValue1, endValue1, time / duration);
            transform.GetChild(2).position = Vector3.Lerp(startValue2, endValue2, time / duration);
            transform.GetChild(3).position = Vector3.Lerp(startValue3, endValue3, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.GetChild(1).position = startPos1;
        transform.GetChild(2).position = startPos2;
        transform.GetChild(3).position = startPos3;

        yield return new WaitForSeconds(1);
    }
}
