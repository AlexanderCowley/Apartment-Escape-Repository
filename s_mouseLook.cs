using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_mouseLook : MonoBehaviour {
    //This script is used to rotate the camera on the y-axis using the mouse
    [HeaderAttribute("Y-Axis Camera Speed")]
    public float Sensitivity = 30;
    private float mouseYRotate;
    Quaternion rot;
    Rigidbody rBody;
    // Use this for initialization
    void Start ()
    {
        rBody = GetComponentInParent<Rigidbody>(); //Accesses rigidbody
	}

    private void FixedUpdate()
    {  //Calculates mouse movement on the y-axis based on time before the next frame
       mouseYRotate += -Sensitivity * Time.deltaTime * Input.GetAxis("Mouse Y"); 
       //Limits y-axis rotation to from -90 to 90 units
       mouseYRotate = Mathf.Clamp(mouseYRotate, -90f, 90f);
        //Smooths rotation
       transform.localEulerAngles = new Vector3(mouseYRotate, 0, 0);
    }
}
