using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroCutscene : MonoBehaviour
{
    public Camera SpeakerCamera, RocketCamera, GroundCamera, WorldCamera;
    public GameObject introRocket, worldRocket;
    public Material spaceSkybox;
    public Text titleText;

    // Change Field of View Lerp Variables
    float startValue = 50;
    float endValue = 10;
    private bool changeLerp = false;
    private float valueToLerp, timeElapsed;
    private float lerpDuration = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        SpeakerCamera.enabled = true;
        RocketCamera.enabled = true;
        GroundCamera.enabled = false;
        WorldCamera.enabled = false;
        this.GetComponent<IntroOrbitSimulator>().enabled = false; //disable WorldRocket motion

        // Start Scene
        StartCoroutine(StartScene());
    }

    // Update is called once per frame
    IEnumerator StartScene()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        // Launch Rocket
        introRocket.AddComponent<rocketPath>();

        // Wait 6 seconds; then switch to ground view
        yield return new WaitForSeconds(6);
        RocketCamera.enabled = false;
        GroundCamera.enabled = true;

        // Wait 1 second, then lerp ground camera field of view
        yield return new WaitForSeconds(1);
        changeLerp = true;

        // Wait 13 seconds, then switch view to world view
        yield return new WaitForSeconds(13);
        GroundCamera.enabled = false;
        WorldCamera.enabled = true;
        RenderSettings.skybox = spaceSkybox;
        this.GetComponent<IntroOrbitSimulator>().enabled = true; //Enable WorldRocket motion

        // Wait 9 seconds, then rotate camera angle
        yield return new WaitForSeconds(9);
        StartCoroutine(LerpRotation(Quaternion.Euler(new Vector3(WorldCamera.transform.rotation.x, WorldCamera.transform.rotation.y, WorldCamera.transform.rotation.z)), 3));

        // Wait 1 second, then display title UI
        yield return new WaitForSeconds(1);
        titleText.text = "CST-320 proudly presents";

        yield return new WaitForSeconds(4);
        titleText.text = "Space Trooper";

        // Wait 12 seconds, then load main menu scene
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene("MainMenuLoadingScreen");

    }

    IEnumerator LerpRotation(Quaternion endValue, float duration)
    {
        float time = 0;
        Quaternion startValue = WorldCamera.transform.rotation;

        while (time < duration)
        {
            WorldCamera.transform.rotation = Quaternion.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        WorldCamera.transform.rotation = endValue;
    }

    void Update()
    {
        if (changeLerp)
        {
            if (timeElapsed < lerpDuration)
            {
                valueToLerp = Mathf.Lerp(startValue, endValue, timeElapsed / lerpDuration);
                timeElapsed += Time.deltaTime;
                GroundCamera.fieldOfView = valueToLerp;
            }
        }
    }
}
