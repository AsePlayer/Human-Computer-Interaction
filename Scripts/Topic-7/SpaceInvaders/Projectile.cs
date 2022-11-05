using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 goTowards;
    

    // Start is called before the first frame update
    void Start()
    {
        goTowards = new Vector3(transform.position.x, transform.position.y, transform.position.z + 20f);
        StartCoroutine(youLivedTooLong());
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().AddForce(goTowards);
    }

    public void setGoTowards(Vector3 goTowards)
    {
        goTowards = this.goTowards;
    }

    IEnumerator youLivedTooLong()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }


}
