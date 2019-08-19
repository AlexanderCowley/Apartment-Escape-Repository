using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_PlayerMovement : MonoBehaviour {
    //This script is meant to calculate 3d movement using the player's rigidbody
    [HeaderAttribute("Movement Speed")]
    public float movementSpeed = 20f;
    float xRotateSpeed = 1f;
    [HeaderAttribute("X-Axis Camera Speed")]
    private Rigidbody rBody;
    Vector3 movement;
    Quaternion rot;
    // Use this for initialization
    void Start ()
    {
        //Disables mouse cursor visibility
        Cursor.visible = false;
        //Locks mouse cursor
        Cursor.lockState = CursorLockMode.Locked;
        //Finds player rigidbody
        rBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //Calculates input on the horizontal and vertical axis
        float xAx = Input.GetAxis("Horizontal");
        float yAx = Input.GetAxis("Vertical");
        //Creates a new vector3 for player movement
        movement = new Vector3(xAx, 0, yAx);
        //Calculates mouse movement on the y-axis based on time before the next frame
        float mouseXRot = Input.GetAxis("Mouse X") * movementSpeed * Time.deltaTime;
        //Translates mouseXRot into rotation instructions
        rot = Quaternion.Euler(0, mouseXRot, 0);
        MovePlayer(movement);
        RotatePlayerX(rot);
    }
    //Moves the rigidbody based on the transform.position, vector3 movement and TransformDirection
    void MovePlayer(Vector3 pos)
    {
        rBody.MovePosition(transform.position + transform.TransformDirection(pos * movementSpeed * Time.deltaTime));
    }
    //Rotates the rigidbody on the x-axis
    void RotatePlayerX(Quaternion rotP)
    {
        rBody.MoveRotation(Quaternion.Euler(rBody.rotation.eulerAngles + new Vector3(0, xRotateSpeed * Input.GetAxis("Mouse X"), 0)));
    }
}
