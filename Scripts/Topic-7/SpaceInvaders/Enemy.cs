using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public List<GameObject> destinationLocations = new List<GameObject>();
    private int listSize;
    public int rng;
    public Vector3 goTowards;
    private GameObject controller;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        listSize = destinationLocations.Count;
        audioSource = GetComponent<AudioSource>();
        controller = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<Rigidbody>().AddForce(goTowards);
        StartCoroutine(LerpPosition(goTowards, 2));
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Shootable"))
        {
            //Debug.Log("Shot");
            //audioSource.PlayOneShot(audioSource.clip, 1);
            controller.GetComponent<SpaceInvaderController>().enemyDied();
            Destroy(this.gameObject); 
            Destroy(col.gameObject); 
            //Instantiate
        }
    }

    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }

}
