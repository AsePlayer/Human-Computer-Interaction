using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearAfterCollision : MonoBehaviour
{
    bool disappear = false;
    public GameObject collisionGameObject; // User picks the game object that activates this script
    public ParticleSystem collisionParticles; // User picks particle system when collision occurs
    public float scale;
    public float scaleShrinkRate;

    private void OnCollisionEnter(Collision collision)
    {
        // If it collides with the set GameObject, start the disappearing process
        if (collision.gameObject.name == collisionGameObject.name)
        {
            disappear = true;
            collisionParticles.Play();
        }

    }

    void Start()
    {
        collisionParticles = gameObject.AddComponent(typeof(ParticleSystem)) as ParticleSystem;
        collisionParticles.Stop();
    }
    // Update is called once per frame
    void Update()
    {
        if (disappear)
        {
            // Shrink the game object slowly
            scale -= scaleShrinkRate;
            transform.localScale = new Vector3(scale, scale, scale);
        }

        // Once the GameObject reaches a certain size, remove it from the scene
        if (transform.localScale.sqrMagnitude < 0.1)
        {
            Destroy(gameObject);
        }
    }
}
