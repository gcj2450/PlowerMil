using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckMover : MonoBehaviour
{
    public Camera cam;  //Drag the camera object here
    public float rotationSpeed = 8;  //This will determine max rotation speed, you can adjust in the inspector
    public float mainMoveSpeed = 10;
    public float moveSpeed = 5; // speed of the player

    [SerializeField] float boundaryR = 4f;
    [SerializeField] float boundaryL = -4f;
    float posX = 0;
    float rotationY=0;

    Vector3 mouseTouchPos;

    private void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, boundaryL, boundaryR), transform.position.y, transform.position.z);

        //if (Input.GetMouseButton(0))
        //{
        //    //RotateObject();
        //    RotateInFrame();
        //}
        RotateInFrame();
  

    }
    void RotateObject()
    {
        
        float angle = Input.GetAxis("Mouse X") * rotationSpeed ;
        transform.Rotate(Vector3.up, angle*Time.deltaTime, Space.World);
        //transform.eulerAngles.y = Mathf.Clamp(transform.eulerAngles.y, -45, 45);
    }
    float ClampAngle(float angle, float from, float to)
    {
        // accepts e.g. -80, 80
        if (angle < 0f) angle = 360 + angle;
        if (angle > 180f) return Mathf.Max(angle, 360 + from);
        return Mathf.Min(angle, to);
    }
    void RotateInFrame()
    {
        if (!Input.GetMouseButton(0)) return; // RMB down


        float mx = Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed;
        //float my = Input.GetAxis("Mouse Y") * Time.deltaTime * rotationSpeed;

        Vector3 rot = transform.rotation.eulerAngles + new Vector3(0, mx, 0f); //use local if your char is not always oriented Vector3.up
        rot.y = ClampAngle(rot.y, -30f, 30f);

        transform.eulerAngles = rot;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.mass > 100)
        {
            moveSpeed = 0;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
            
        else if (collision.rigidbody.mass > 1)
        {
            moveSpeed = moveSpeed * GetComponent<Rigidbody>().mass / collision.rigidbody.mass;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        moveSpeed = mainMoveSpeed;
        //GetComponent<Rigidbody>().isKinematic = true;
    }
}
