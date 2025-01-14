﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RescueCarController : MonoBehaviour
{
    public static RescueCarController rcc;
    public bool follow = false;
    public int followID;
    public Transform player;
    public GameObject obstacle;
    public Collider coll;
    public Transform rescueCarWayPointSelf;// new
    
    //public GameObject[] wayPointPosList;

    private NavMeshAgent agent;
    public Vector3 wayPointPos;
    private Ray ray;
    private Vector3 localForward;

    [SerializeField]public Transform wayPoint;
    [SerializeField]public float speed = 0.5f;
    [SerializeField] private float minDistance = 7f;

    void Start()
    {
        rcc = this;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        coll = GetComponent<Collider>();
        //agent = GetComponent<NavMeshAgent>();
        //At the start of the game, car will find the player.
        //wayPoint = GameObject.FindGameObjectWithTag("Player").transform;
        localForward = transform.worldToLocalMatrix.MultiplyVector(transform.forward);
        
    }

 

    void Update()
    {
      //  wayPoint = FindClosestWP().transform;
        if (wayPoint != null)
        {
            
            wayPointPos = new Vector3(wayPoint.position.x, transform.position.y, wayPoint.position.z);
            if (obstacle==null)
            {
                MoveCar();
                CarRotate();
                follow = true;
            }
            
        }

 
    }


    void MoveCar()
    {
        if (Vector3.Distance(transform.position, wayPoint.transform.position) < minDistance)
        {
            speed -= 0.3f;
            Debug.Log("yaklaşıyor");
        }
        else
        {
            for(int i =0;i<CarFollowController.cfc.followCars.Count;i++)
            {
                CarFollowController.cfc.followCars[i].speed = CarFollowController.cfc.currentSpeed;
            }
        }

        wayPointPos = new Vector3(wayPoint.transform.position.x, transform.position.y, wayPoint.transform.position.z);
        //Car following player
        transform.position = Vector3.Slerp(transform.position, wayPointPos, speed * Time.deltaTime);
        
        if (!CarFollowController.cfc.followCars.Contains(this))
        {
            if (follow)
            {
                //CarFollowController.cfc.AddFollowCarList(this);
            }
           
        }
       

    }

    void CarRotate()
    {
        transform.LookAt(wayPointPos,Vector3.up);
    }

    GameObject FindClosestWP()
    {
        GameObject closestWPTemp = null;
        GameObject[] wayPointPosListTemp;
        wayPointPosListTemp = GameObject.FindGameObjectsWithTag("RescueCarTarget");
        float distance = Mathf.Infinity;
        //wayPointPosListTemp.OrderBy(x => x.transform.position.z);
        foreach (var wayPointTemp in wayPointPosListTemp)
        {
            if (wayPointTemp.transform.position.z >= transform.position.z+2)
            {
                var diff = Vector3.Distance(wayPointTemp.transform.position, transform.position);
                if (diff < distance)
                {
                    closestWPTemp = wayPointTemp;
                    distance = diff;
                }
            }

        }
        return closestWPTemp;
    }
}
