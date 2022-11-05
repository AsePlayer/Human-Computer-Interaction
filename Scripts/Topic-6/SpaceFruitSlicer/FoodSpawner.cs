using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{

    public List<GameObject> food = new List<GameObject>();
    public int spotInList;

    private static float spawnrate = 5.0f;
    private float originalSpawnrate = spawnrate;

    private GameObject clone;

    public GameObject goTowards;

    public float size = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        spawnrate -= Time.deltaTime;
        if (spawnrate <= 0.0f)
        {
            spawnrate = originalSpawnrate;
            // Spawnrate ramp up
            if (originalSpawnrate - originalSpawnrate / 5 > 0.0f)
            {
                originalSpawnrate -= originalSpawnrate / 5;
            }

            clone = Instantiate(food[spotInList], GetPointOnUnitCircleCircumference(size), Quaternion.identity);
            clone.GetComponent<Rigidbody>().AddForce((goTowards.transform.position - clone.transform.position) * 7f);
            clone.transform.Rotate(Random.Range(1, 360), Random.Range(1, 360), Random.Range(1, 360));

            if (spotInList >= food.Count - 1)
            {
                spotInList = 0;
            }
            else
            {
                spotInList++;
            }
        }
    }

    public Vector3 GetPointOnUnitCircleCircumference(float size)
    {
        float randomAngle = Random.Range(0f, Mathf.PI * 2f);
        return size * new Vector3(Mathf.Sin(randomAngle), Random.Range(0.1f, 1f), Mathf.Cos(randomAngle)).normalized;
    }
}