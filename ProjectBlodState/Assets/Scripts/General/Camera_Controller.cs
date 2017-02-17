using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    public Camera cam;

    private float distance;
    public float sensitivityDistance = 50;
    public float damping;
    public float minFOV;
    public float maxFOV;

    public float rotateSpeed;
    public float moveSpeed;
    private float moveDistance;
    private float dist;

    private void RotateHorizontal(char type)
    {
        float dir = 1;
        if(type == 'R')
        {
            dir = -1;
        }
        transform.Rotate(0, dir * rotateSpeed, 0);
    }

    private void Start()
    {
        distance = cam.fieldOfView;
    }

    private void FixedUpdate()
    {
        //zoom in and out
        distance -= Input.GetAxis("Mouse ScrollWheel") * sensitivityDistance;
        distance = Mathf.Clamp(distance, minFOV, maxFOV);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, distance, Time.deltaTime * damping);

        if (Input.GetKey(KeyCode.Q))
        {
            //rotate left
            RotateHorizontal('L');
        }
        else if (Input.GetKey(KeyCode.E))
        {
            //rotate right
            RotateHorizontal('R');
        }

        if (Input.GetKey(KeyCode.W))
        {
            //move forward
            transform.Translate(Vector3.forward * moveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //move back
            transform.Translate(Vector3.back * moveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //move Left
            transform.Translate(Vector3.left * moveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //move Right
            transform.Translate(Vector3.right * moveSpeed);
        }
    }
	
}
