using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SpaceInvaderController : MonoBehaviour
{
    private bool instaTeleport;
    private float cooldown;
    private float shootCooldown;
    private float spawnrateCooldown;

    private int listSize;

    public float speed;
    public float shotSpeed;
    public float spawnrate;

    public int spotInList;
    public List<GameObject> movementLocations = new List<GameObject>();
    public List<Vector3> shootingLocations = new List<Vector3>();
    public List<int> enemiesRemaining = new List<int>();
    public List<AudioClip> hurtNoises = new List<AudioClip>();
    public AudioClip killedEnemy;
    public TextMeshProUGUI enemiesRemainingText;

    public int totalEnemies;
    public int level;


    public int lives;

    public GameObject canonnball;
    public GameObject enemy;
    private Projectile clonenball;

    private Vector3 firePos;
    public Vector3 goTowards;

    public Projectile projectile;

    public Enemy enemyPrefab;

    public Slider reloadSlider;

    public List<SpriteRenderer> hp = new List<SpriteRenderer>();

    private Vector3 hpScale;

    AudioSource shotSound;

    // Start is called before the first frame update
    void Start()
    {
        listSize = movementLocations.Count;
        transform.position = movementLocations[spotInList].transform.position;

        reloadSlider.maxValue = shotSpeed;
        StartCoroutine(startLevel(level));
        totalEnemies = enemiesRemaining[level];

        hpScale = hp[0].transform.localScale;

        shotSound = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesRemaining[level] <= 0)
        {
            enemiesRemainingText.text = "You Won!";
            level++;
            StartCoroutine(startLevel(level));
            totalEnemies = enemiesRemaining[level];
        }
        else
        {
            enemiesRemainingText.text = "Enemies Remaining: " + enemiesRemaining[level];
        }
        // Reduce cooldowns
        if (cooldown < speed) cooldown += Time.deltaTime;
        if (shootCooldown < shotSpeed) shootCooldown += Time.deltaTime;

        if (spawnrateCooldown < spawnrate)
        {
            spawnrateCooldown += Time.deltaTime;
        }
        else
        {

            //Change spawnrate
            spawnrate = spawnrate - spawnrate / 15f * (level + 1);
            spawnEnemy();
            spawnrateCooldown = 0;
            enemiesRemaining[level]--;
            
        }

        reloadSlider.value = shootCooldown;
        // Skips Lerp and instantly changes position. Maybe can use this for a cool powerup with some teleportation effects
        if(instaTeleport)
        {
            transform.position = movementLocations[spotInList].transform.position;
        }
        else
        {
            if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.LTouch) && cooldown >= speed)
            {
                if (requestMovePosition("left"))
                {
                    spotInList--;
                    StartCoroutine(LerpPosition(movementLocations[spotInList].transform.position, speed));
                    cooldown = 0;
                }
                
            }
            if (OVRInput.Get(OVRInput.Button.Two, OVRInput.Controller.LTouch) && cooldown >= speed)
            {
                if (requestMovePosition("right"))
                {
                    spotInList++;
                    StartCoroutine(LerpPosition(movementLocations[spotInList].transform.position, speed));
                    cooldown = 0;
                }
            }
        }
        if (OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch) && shootCooldown >= shotSpeed)
        {
            fire();
            shootCooldown = 0;
        }

        // Reload scene if Player dies.
        if (lives < 1)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
        // Change life display
        if (lives >= 4)
        {
            hp[0].transform.localScale = hpScale;
            hp[1].transform.localScale = hpScale;
            hp[2].transform.localScale = hpScale;
            hp[3].transform.localScale = hpScale;
        }
        if (lives == 3)
        {
            hp[0].transform.localScale = new Vector3(0, 0, 0);
            hp[1].transform.localScale = hpScale;
            hp[2].transform.localScale = hpScale;
            hp[3].transform.localScale = hpScale;
        }
        if (lives == 2)
        {
            hp[0].transform.localScale = new Vector3(0, 0, 0);
            hp[1].transform.localScale = new Vector3(0, 0, 0);
            hp[2].transform.localScale = hpScale;
            hp[3].transform.localScale = hpScale;
        }
        if (lives == 1)
        {
            hp[0].transform.localScale = new Vector3(0, 0, 0);
            hp[1].transform.localScale = new Vector3(0, 0, 0);
            hp[2].transform.localScale = new Vector3(0, 0, 0);
            hp[3].transform.localScale = hpScale;
        }
        if (lives == 0)
        {
            hp[0].transform.localScale = new Vector3(0, 0, 0);
            hp[1].transform.localScale = new Vector3(0, 0, 0);
            hp[2].transform.localScale = new Vector3(0, 0, 0);
            hp[3].transform.localScale = new Vector3(0, 0, 0);
        }
    }

    bool requestMovePosition(string direction)
    {
        // Basically checking if (0 < spotInList < listSize). If so, allow movement request.
        if (spotInList - 1 >= 0 && direction == "left" || spotInList + 1 < listSize && direction == "right")
            return true;
        return false;
    }

    void fire()
    {
        //Fire cannon code goes here. Instantiate GameObject cannonball and apply force probably.
        var newTransform = movementLocations[spotInList].transform.position;
        //Prevents colliding with the player
        firePos = new Vector3(newTransform.x, newTransform.y, newTransform.z + 2f) ;

        clonenball = Instantiate(projectile, firePos, Quaternion.identity);
        clonenball.transform.position = firePos;
        clonenball.transform.Rotate(Random.Range(1, 360), Random.Range(1, 360), Random.Range(1, 360));
        shotSound.Play(0);
    }

    public void takeDamage()
    {
        var random = Random.Range(0, hurtNoises.Count);
        shotSound.PlayOneShot(hurtNoises[random], 0.6f);
        //Take damage code goes here. If lives < 1, game over.
        lives--;
    }

    void spawnEnemy()
    {
        var random = Random.Range(0, movementLocations.Count);
        GameObject enemySpawned = Instantiate(enemy, shootingLocations[random], Quaternion.identity);
        enemySpawned.GetComponent<Enemy>().goTowards = movementLocations[random].transform.position;
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

    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Enemy"))
        {
            //Debug.Log("Shot");
            lives--;
            Destroy(col.gameObject);
            
        }
    }

    IEnumerator startLevel(int level)
    {
        enemiesRemainingText.text = "You Won!";
        yield return new WaitForSeconds(5);
        lives = 4;
        if (level == 1)
        {
            spawnrate = 8;
        }
        if(level == 2)
        {
            spawnrate = 10;
        }
    }

    public void enemyDied()
    {
        shotSound.PlayOneShot(killedEnemy, 0.4f);
    }
}
