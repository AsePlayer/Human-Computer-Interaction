using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// LoadLevel Script - Topic 5 CLC - by Andrew Esch (Team 9)
// Statement of Own Work: We certify that this program is our own work and ideas, verifying that no help was provided.
// We are aware that the incorporation of material from other's work without acknowledgement is treated as plagiarism.

public class LightMotionSensor : MonoBehaviour
{
    public AudioClip doorOpen;
    public Light doorLight;
    public float minIntensity = 0.5f;
    public float maxIntensity = 3f;
    public float lerpVal = 1f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Slowly brighten lights on startup
        if (doorLight.intensity < 1f)
        {
            Mathf.Lerp(doorLight.intensity, 1f, lerpVal);
        }
    }
    
    void OnCollisionEnter(Collision c)
    {
        // Play Door Open Sound
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();

        // Activate Light
        doorLight.intensity = Mathf.Lerp(doorLight.intensity, maxIntensity, lerpVal);
    }
}
