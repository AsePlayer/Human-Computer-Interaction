using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayPaint : MonoBehaviour
{
    public ParticleSystem sprayPaint;
    public ParticleSystem sprayEffect;
    private ParticleSystem actualEffect;
    private float t = 0f;
    private float lerpTime = 500f;
    private Color startColor;
    private Color newColor = new Color(164f, 164f, 164f);
    private bool isEffect;

    // Start is called before the first frame update
    void Start()
    {
        startColor = GetComponent<Renderer>().material.color;
        actualEffect = Instantiate(sprayEffect, new Vector3(transform.position.x-0.75f, transform.position.y, transform.position.z), new Quaternion(-1f, transform.rotation.y, transform.rotation.z, 1f));
        var emission = actualEffect.emission;
        emission.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnParticleCollision(GameObject other)
    {
        if (other = sprayPaint.gameObject)
        {
            GetComponent<Renderer>().material.color = paint();
            StartCoroutine(Emit());
        }
    }

    Color paint()
    {
        // Lerp to different color
        Color current = GetComponent<Renderer>().material.color;
        if (t < lerpTime)
        {
            float newTime = (t / lerpTime);
            Debug.Log(newTime.ToString());
            current = Color.Lerp(startColor, newColor, newTime);
            t += Time.deltaTime;
            return current;
        }
        return current;
    }

    IEnumerator Emit()
    {
        var emission = actualEffect.emission;
        emission.enabled = true;
        yield return new WaitForSeconds(.1f);
        emission.enabled = false;
    }
}
