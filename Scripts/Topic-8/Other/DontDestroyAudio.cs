using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyAudio : MonoBehaviour
{
    private void Awake()
    {
        //Keeps audio playing in-between scenes
        DontDestroyOnLoad(transform.gameObject);
    }
}
