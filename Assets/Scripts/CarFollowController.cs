using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFollowController : MonoBehaviour
{
    

    public static CarFollowController cfc;
    public TruckMover car;
    public float firstSpeedCar;
    public float minFollowDistance = 0;
    float valueSpeed = 0;
    public List<RescueCarController> followCars = new List<RescueCarController>();
    public int i = 0;

    public float currentSpeed;
    private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        firstSpeedCar = car.moveSpeed;
        currentSpeed = car.moveSpeed / 3;
        cfc = this;
    }

    // Update is called once per frame
    void Update()
    {  
        //if(control)
        //{
        //    CarsUpdateSpeed();
        //}
        //if (car.moveSpeed<firstSpeedCar || car.moveSpeed>firstSpeedCar)
        //{
        //    CarsUpdateSpeed();
        //}
    }

    void CarsUpdateSpeed()
    {
   
        for (int j = 0; j < followCars.Count; j++)
        {
            followCars[j].speed = currentSpeed;

        }
        
       

        //if (i == 0)
        //{
        //    Debug.Log("hosgeldin");
            
        //    followCars[0].speed = car.moveSpeed / 2;
        //    i++;
            
        //}
        //else
        //{
            
        //    Debug.Log("hosgeldin2");
        //    followCars[i].speed = car.moveSpeed / 2;
        //    i++;
        //    for (int j=followCars.Count-1; j>=0 ;j--)
        //    {
        //        followCars[j-1].speed = followCars[j].speed / 2.5f;
                
                
                
        //    }
            
            
        //}
        //for (int i = 0; i < followCars.Count; i++)
        //{
        //    if (i == 0)
        //    {
        //        followCars[i].speed = car.moveSpeed / 2;
        //    }
        //    else
        //    {
        //         followCars[i].speed = followCars[i - 1].speed / minFollowDistance;
        //    }

        //}


    }
    public void AddFollowCarList(RescueCarController res)
    {

         
        if (followCars.Count==0)
        {
            
            coroutine = Wait(0.5f);
            StartCoroutine(coroutine);
            followCars.Add(res);
            res.wayPoint = GameObject.FindGameObjectWithTag("RescueCarTarget").transform;
            followCars[0].player = car.transform;
            followCars[0].speed = car.moveSpeed / 2;
            res.followID = 1;
        }
        else
        {
            
            coroutine = Wait(1f);
            StartCoroutine(coroutine);
            int value = followCars.Count;
            res.player = followCars[value - 1].gameObject.transform;
            //res.speed = car.moveSpeed / minFollowDistance;
            res.wayPoint = car.transform;
            //res.wayPoint = followCars[followCars.Count - 1].rescueCarWayPointSelf;
            followCars[followCars.Count - 1].wayPoint = res.rescueCarWayPointSelf;
            followCars.Add(res);
            res.followID = value;
            

        }

        
    }

    public void RemoveFollowCarList(RescueCarController rem)
    {
        followCars.Remove(rem);
    }
    private IEnumerator Wait(float waitTime)
    {
        Debug.Log("waitttt");
        
        for (int i=0;i< followCars.Count;i++)
        {
            followCars[i].speed = 0;
            
        }
        yield return new WaitForSeconds(waitTime);
        
        CarsUpdateSpeed();
    }
}
