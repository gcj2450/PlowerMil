using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMover : MonoBehaviour
{
    public Camera cam;  //Drag the camera object here
    public float rotationSpeed = 8;  //This will determine max rotation speed, you can adjust in the inspector
    public float moveSpeed = 10; // speed of the player

    float posX = 0;
    float rotationY=0;
    Vector3 mouseTouchPos;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -3, 3), transform.position.y, transform.position.z);

        if(Input.GetMouseButton(0))
            RotateObject();
    }
    void RotateObject()
    {
        //transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, Mathf.Clamp(transform.rotation.y, -45, 45), transform.rotation.z));
        float angle = Input.GetAxis("Mouse X") * rotationSpeed ;
        transform.Rotate(Vector3.up, angle*Time.deltaTime, Space.World);        
    }

}
