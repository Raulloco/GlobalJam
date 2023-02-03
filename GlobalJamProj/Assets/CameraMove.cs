using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float CameraSpeed;
    public float currentx;
    public float currenty;
    public bool following;
    public Vector3 velocity = Vector3.zero;

    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentx, currenty, transform.position.z),ref velocity,CameraSpeed/* *Time.deltaTime */);
    }

    public void MoveCamera(float x, float y) 
    { 
        currentx = x;
        currenty = y;
    }
}
