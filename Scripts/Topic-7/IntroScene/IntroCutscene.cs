using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroCutscene : MonoBehaviour
{
    public Camera SpeakerCamera;
    public GameObject RocketCamera, GroundCamera, WorldCamera;
    public GameObject introRocket, worldRocket;
    public Material spaceSkybox;
    public Text titleText;

    public AudioSource rocketBuildup;
    public AudioSource rocketBlastoff;

    // Change Field of View Lerp Variables
    float startValue = 50;
    float endValue = 7;
    private bool changeLerp = false;
    private float valueToLerp, timeElapsed;
    private float lerpDuration = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        RocketCamera.SetActive(true);
        SpeakerCamera.enabled = true;
        GroundCamera.SetActive(false);
        WorldCamera.SetActive(false);
        this.GetComponent<IntroOrbitSimulator>().enabled = false; //disable WorldRocket motion

        // Start Scene
        StartCoroutine(StartScene());
    }

    // Update is called once per frame
    IEnumerator StartScene()
    {
        //Play sounds delayed
        rocketBuildup.PlayDelayed(0.5f);
        rocketBlastoff.PlayDelayed(4.75f);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        // Launch Rocket
        introRocket.AddComponent<rocketPath>();

        // Wait 6 seconds; then switch to ground view
        yield return new WaitForSeconds(6);
        RocketCamera.SetActive(false);
        GroundCamera.SetActive(true);

        // Wait 1 second, then lerp ground camera field of view
        yield return new WaitForSeconds(1);
        changeLerp = true;

        // Wait 13 seconds, then switch view to world view
        yield return new WaitForSeconds(13);
        GroundCamera.SetActive(false);
        WorldCamera.SetActive(true);
        RenderSettings.skybox = spaceSkybox;
        this.GetComponent<IntroOrbitSimulator>().enabled = true; //Enable WorldRocket motion
        rocketBlastoff.Stop(); // Stops rocket sound when you are in space.

        // Wait 9 seconds, then rotate camera angle
        yield return new WaitForSeconds(9);
        SpeakerCamera.enabled = false;
        StartCoroutine(LerpRotation(Quaternion.EulerAngles(WorldCamera.transform.rotation.x+63f, -165f, WorldCamera.transform.rotation.z-6f), 3));

        // Wait 1 second, then display title UI
        yield return new WaitForSeconds(1);
        titleText.text = "CST-320 proudly presents...";

        yield return new WaitForSeconds(4);
        titleText.text = "Space Trooper";

        // Wait 12 seconds, then load main menu scene
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene("SpaceHallwayLoadingScreen");

    }

    IEnumerator LerpRotation(Quaternion endValue, float duration)
    {
        float time = 0;
        Quaternion startValue = WorldCamera.transform.rotation;

        while (time < duration)
        {
            WorldCamera.transform.rotation = Quaternion.Slerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
    }

    void Update()
    {
        if (changeLerp)
        {
            if (timeElapsed < lerpDuration)
            {
                valueToLerp = Mathf.Lerp(startValue, endValue, timeElapsed / lerpDuration);
                timeElapsed += Time.deltaTime;
                GroundCamera.transform.GetChild(0).GetChild(1).GetComponent<Camera>().fieldOfView = valueToLerp;
            }
        }
    }
}
