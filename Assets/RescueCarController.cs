using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RescueCarController : MonoBehaviour
{
    //public Transform target;
    public Collider coll;

    private NavMeshAgent agent;
    private GameObject wayPoint;
    private Vector3 wayPointPos;
    private Ray ray;
    //This will be the car speed. Adjust as necessary.
    [SerializeField]private float speed = 6.0f;
    void Start()
    {
        coll = GetComponent<Collider>();
        agent = GetComponent<NavMeshAgent>();
        //At the start of the game, car will find the player.
        wayPoint = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {

        ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Debug.Log(coll.Raycast(ray, out hit, 100f));
        if (!Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
            Debug.Log("Ray Hitted");
            MoveCar();
        }
        //NavMeshHit hit;
        //if(!agent.Raycast(wayPoint.transform.position, out hit))
        //    MoveCar();
    }

    void MoveCar()
    {
        wayPointPos = new Vector3(wayPoint.transform.position.x, transform.position.y, wayPoint.transform.position.z);
        //Car following player
        transform.position = Vector3.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);
    }
}
