using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogoBouncer : MonoBehaviour
{
    public Image logo;
    Rigidbody rb;
    float currScaleX, currScaleY;
    Vector3 scaleChange;

    bool beyondX, beyondY;

    // Start is called before the first frame update
    void Start()
    {
        rb = logo.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(200f,200f,0f);
        currScaleX = 1f;
        currScaleY = 1f;
        beyondX = false;
        beyondY = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Flip direction if canvas has reached edge of the screen
        if (logo.rectTransform.position.x > (516f + 721.5f) && (beyondX == false) || logo.rectTransform.position.x < (-516f + 721.5f) && (beyondX == false))
        {
            beyondX = true;
            currScaleX *= -1f;
            rb.velocity = new Vector3(rb.velocity.x * -1f, rb.velocity.y, 0f);
            scaleChange = new Vector3(currScaleX, currScaleY, 1f);
            logo.transform.localScale = scaleChange;
        } else if (logo.rectTransform.position.x < (516f + 721.5f) && logo.rectTransform.position.x > (-516f + 721.5f))
        {
            beyondX = false;
        }

        if (logo.rectTransform.position.y > (235f + 337f) && (beyondY == false) || logo.rectTransform.position.y < (-235f + 337f) && (beyondY == false))
        {
            beyondY = true;
            currScaleY *= -1f;
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y * -1f, 0f);
            scaleChange = new Vector3(currScaleX, currScaleY, 1f);
            logo.transform.localScale = scaleChange;
        } else if (logo.rectTransform.position.y < (235f + 337f) && logo.rectTransform.position.y > (-235f + 337f))
        {
            beyondY = false;
        }
    }
}
