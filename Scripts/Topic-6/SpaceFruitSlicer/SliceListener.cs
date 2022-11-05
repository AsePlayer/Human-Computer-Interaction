using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code from https://youtu.be/iRW2CyQysdw
public class SliceListener : MonoBehaviour
{
    public Slicer slicer;
    private void OnTriggerEnter(Collider other)
    {
        slicer.isTouched = true;
    }
}
