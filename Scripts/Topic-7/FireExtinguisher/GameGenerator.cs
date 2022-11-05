using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameGenerator : MonoBehaviour
{
    public GameObject theEventManager;
    public GameObject hoop;
    private GameObject randHoop;
    public GameObject portalCube;
    private GameObject randPortalCube;
    public TMP_Text wave;
    public TMP_Text hoopsRemaining;
    public TMP_Text currTime;
    public TMP_Text result;

    private int waveNum = 0;
    public int startHoops = 6;
    public int increaseAmount = 2;
    public Vector3 min = new Vector3(-50f, 15f, -50f);
    public Vector3 max = new Vector3(50f, 75f, 50f);
    private Vector3 randVector;
    private Quaternion randRotation;
    public int totalTime = 300;
    private int gameTime;
    private float second = 0;
    public int currCount = 1;

    void Start()
    {
        GenerateHoops();
        StartCoroutine(sleep(3));
    }

    void GenerateHoops()
    {
        // Generate Portal Cube
        randVector = new Vector3(UnityEngine.Random.Range(min.x, max.x), UnityEngine.Random.Range(min.y, max.y), UnityEngine.Random.Range(min.z, max.z));
        randRotation = Quaternion.Euler(0f, UnityEngine.Random.Range(0f, 359.9f), 0f);
        randPortalCube = Instantiate(portalCube, randVector, randRotation);

        waveNum++;

        // Generate Hoops
        for (int i = 0; i < startHoops + increaseAmount * (waveNum - 1); i++)
        {
            randVector = new Vector3(UnityEngine.Random.Range(min.x, max.x), UnityEngine.Random.Range(min.y, max.y), UnityEngine.Random.Range(min.z, max.z));
            randRotation = Quaternion.Euler(270f, UnityEngine.Random.Range(0f, 359.9f), 0f);
            randHoop = Instantiate(hoop, randVector, randRotation);
            randHoop.transform.GetChild(1).GetComponent<TextMeshPro>().text = (i+1).ToString();
            randHoop.GetComponent<DestroyHoop>().eventManager = theEventManager;
        }

        // Set UI & Variables
        currCount = (startHoops + increaseAmount * (waveNum - 1));
        wave.GetComponent<TextMeshPro>().text = "Wave #: " + waveNum.ToString();
        hoopsRemaining.GetComponent<TextMeshPro>().text = "Hoops Left: " + (startHoops + increaseAmount * (waveNum - 1)).ToString();
        gameTime = totalTime;
        currTime.GetComponent<TextMeshPro>().text = "Time: " + gameTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        var inputTracker = randPortalCube.GetComponent<OVRGrabbable>();

        // Deduct gametime
        second += Time.deltaTime;
        if (second >= 1f)
        {
            gameTime -= 1;
            second = 0;
            currTime.GetComponent<TextMeshPro>().text = "Time: " + gameTime.ToString();
        }

        if (gameTime == 0)
        {
            // Display Game Over
            result.GetComponent<TextMeshPro>().text = "Game Over!";
            Destroy(randPortalCube);
        }
        else
        {
            // Check if current hoop count is zero
            if (currCount == 0)
            {
                result.GetComponent<TextMeshPro>().text = "Grab the portal cube!";

                // If portal cube is grabbed, the player wins this wave
                if (inputTracker.grabbed)
                {
                    result.GetComponent<TextMeshPro>().text = "You won!";

                    // Reset Game Conditions
                    Destroy(randPortalCube);
                    StartCoroutine(sleep(5));
                    GenerateHoops();
                }
            }
        }
    }

    IEnumerator sleep(int n)
    {
        yield return new WaitForSeconds(n);
    }
}
