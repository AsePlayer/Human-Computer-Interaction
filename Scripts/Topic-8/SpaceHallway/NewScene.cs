using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewScene : MonoBehaviour
{
    public GameObject door; 
    public string name; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Enter Scene");
            ChangeScene(name); 
        }
    }

    public void ChangeScene(string sceneName)
	{
		SceneManager.LoadScene (name);
	}
	public void Exit()
	{
		Application.Quit ();
	}
}
