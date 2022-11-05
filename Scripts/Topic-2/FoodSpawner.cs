using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{

    public List<GameObject> food = new List<GameObject>();
    public int spotInList;
    
    private static float spawnrate = 8.0f;
    private float originalSpawnrate = spawnrate;

    private GameObject clone;

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
            if(originalSpawnrate - originalSpawnrate / 5 > 0.0f)
            {
                originalSpawnrate -= originalSpawnrate / 5;
            }

            clone = Instantiate(food[spotInList], new Vector3(Random.Range(-2,2), Random.Range(-2, 2), Random.Range(-20, -15)), Quaternion.identity);
            clone.GetComponent<Rigidbody>().AddForce(Random.Range(-1, 2), Random.Range(-1, 1), 3 * Random.Range(-20, -5));
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
}
