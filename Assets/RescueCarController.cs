using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.PlayerLoop;

public class RescueCarController : MonoBehaviour
{
    public Transform player;
    public Collider coll;

    private NavMeshAgent agent;
    private Vector3 wayPointPos;
    private Ray ray;
    private Vector3 localForward;

    [SerializeField]private GameObject wayPoint;
    [SerializeField]private float speed = 0.5f;
    [SerializeField] private float minDistance = 3f;

    void Start()
    {
        coll = GetComponent<Collider>();
        agent = GetComponent<NavMeshAgent>();
        //At the start of the game, car will find the player.
        wayPoint = GameObject.FindGameObjectWithTag("Player");
        localForward = transform.worldToLocalMatrix.MultiplyVector(transform.forward);
    }

 

    void Update()
    {
        wayPointPos = new Vector3(wayPoint.transform.position.x, transform.position.y, wayPoint.transform.position.z);

        if (Vector3.Distance(transform.position,wayPointPos)<=minDistance)
        {
            MoveCar();
            CarRotate();
        }

        //ray = new Ray(transform.position, transform.forward);
        //RaycastHit hit;
        //var layerMask = 1 << 8;
        //layerMask = ~layerMask;

        //if (!Physics.Raycast(transform.position, transform.TransformDirection(localForward), out hit, 2.5f, layerMask))
        //{

        //    MoveCar();
        //    CarRotate();
        //}

        //else
        //{
        //    if (hit.collider != null)
        //        Debug.Log("Ray Hit Name: " + hit.collider.name);
        //}
    }


    void MoveCar()
    {
        //ray = new Ray(transform.position, transform.forward);
        //RaycastHit hit;
        //var layerMask = 1 << 8;
        //layerMask = ~layerMask;
        //if (!Physics.Raycast(transform.position, transform.TransformDirection(localForward), out hit, 2.5f, layerMask))
        //{
        //    return;
        //}

        if (Vector3.Distance(transform.position, wayPointPos) < 3)
        {
            return;
        }
        wayPointPos = new Vector3(wayPoint.transform.position.x, transform.position.y, wayPoint.transform.position.z);
        //Car following player
        //transform.position = Vector3.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);
        transform.position = Vector3.Lerp(transform.position, wayPointPos, speed * Time.fixedDeltaTime);
       
    }

    void CarRotate()
    {
        transform.LookAt(wayPointPos,Vector3.up);
    }
}
