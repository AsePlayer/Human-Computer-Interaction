using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceInvaderController : MonoBehaviour
{
    private int listSize;
    public float speed;
    private float cooldown;

    private bool instaTeleport;

    public int spotInList;
    public List<GameObject> movementLocations = new List<GameObject>();

    public int lives;

    public GameObject canonnball;

    // Start is called before the first frame update
    void Start()
    {
        listSize = movementLocations.Count;
        transform.position = movementLocations[spotInList].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Reduce cooldown
        if(cooldown < speed)
        {
            cooldown += 0.01f;
        }
        // Skips Lerp and instantly changes position. Maybe can use this for a cool powerup with some teleportation effects
        if(instaTeleport)
        {
            transform.position = movementLocations[spotInList].transform.position;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && cooldown >= speed)
            {
                if (requestMovePosition("left"))
                {
                    spotInList--;
                    StartCoroutine(LerpPosition(movementLocations[spotInList].transform.position, speed));
                }
                cooldown = 0;
            }
            if (Input.GetKeyUp(KeyCode.RightArrow) && cooldown >= speed)
            {
                if (requestMovePosition("right"))
                {
                    spotInList++;
                    StartCoroutine(LerpPosition(movementLocations[spotInList].transform.position, speed));
                }
                cooldown = 0;
            }
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
    }

    void takeDamage()
    {
        //Take damage code goes here. If lives < 1, game over.
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
