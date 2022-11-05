using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterNewScene : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("]"))
            ChangeScene("bowlingBall"); 
    }

    void ChangeScene(string Scene)
    {
        SceneManager.LoadScene(Scene);
    }

    void Exit()
    {
        Application.Quit();
    }
}
