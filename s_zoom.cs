using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_zoom : MonoBehaviour
{
    /*This script manipulates the player cameras field of view to 
    zoom in when the right mouse button is held down*/
    public Camera p_Camera;

    // Update is called once per frame
    void Update()
    {
        //Zooms in by clicking right mouse button
        if (Input.GetMouseButtonDown(1))
        {
            p_Camera.fieldOfView = 50;
        }
        // Resets zoom after releasing right mouse button
        if (Input.GetMouseButtonUp(1))
        {
            p_Camera.fieldOfView = 60;
        }
    }
}
