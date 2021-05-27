using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TruckMover : MonoBehaviour
{
    public static TruckMover player;
    public Camera cam;  //Drag the camera object here
    public float rotationSpeed = 8;  //This will determine max rotation speed, you can adjust in the inspector
    public float mainMoveSpeed = 10;
    public float moveSpeed = 5; // speed of the player
    public float maxAngle = 30;
    public bool stop = true;
    [SerializeField] float boundaryR = 4f;
    [SerializeField] float boundaryL = -4f;
    public bool control = true;
    //float posX = 0;
    //float rotationY=0;

    Vector3 mouseTouchPos;
    
    private void Start()
    {
        player = this;
    }
    // Update is called once per frame
    void Update()
    {
        Mover();
        if (Input.GetMouseButton(0))
        {
            RotateWithMouse();
        }

    }
    
    float ClampAngle(float angle, float from, float to)
    {
        // accepts e.g. -80, 80
        if (angle < 0f) angle = 360 + angle;
        if (angle > 180f) return Mathf.Max(angle, 360 + from);
        return Mathf.Min(angle, to);
    }
    void RotateWithMouse()
    {
        if (!Input.GetMouseButton(0)) return; // RMB down


        float mx = Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed;
        //float my = Input.GetAxis("Mouse Y") * Time.deltaTime * rotationSpeed;

        Vector3 rot = transform.rotation.eulerAngles + new Vector3(0, mx, 0f); //use local if your char is not always oriented Vector3.up
        rot.y = ClampAngle(rot.y, -maxAngle, maxAngle);
        
        transform.eulerAngles = rot;
        GameObject go= GameObject.FindWithTag("truckBody");
        if (go)
        {
            Vector3 rotGo = go.transform.rotation.eulerAngles + new Vector3(0, 0, mx * 5.0f);
            rotGo.z = ClampAngle(rotGo.z, -4, 4);
            go.transform.eulerAngles = rotGo;
        }
    }

    void Mover()
    {
        // if (transform.position.x < boundaryR && transform.position.x > boundaryL)
        //     moveSpeed = 7.0f;
        // else
        // {
        //     moveSpeed = 3.0f;
        // }
        if (control)
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, boundaryL, boundaryR), transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = Vector3.Slerp(transform.position, new Vector3(3.5f, 1.18f, 340), Time.deltaTime);
            CarFollowController.cfc.enabled = false;
           
            moveSpeed = 0;
            mainMoveSpeed = 0;
        }
            
       
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            if(!CarFollowController.cfc.followCars.Contains(other.transform.root.GetComponent<RescueCarController>()))
            {
                CarFollowController.cfc.AddFollowCarList(other.transform.root.GetComponent<RescueCarController>());
            }

            
            Destroy(other.gameObject);
            


        }
    }
    
}
