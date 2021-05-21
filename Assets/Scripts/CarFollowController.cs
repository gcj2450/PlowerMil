using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFollowController : MonoBehaviour
{
    public bool control = false;//new

    public static CarFollowController cfc;
    public TruckMover car;
    public float firstSpeedCar;
    public float minFollowDistance = 0;
    float valueSpeed = 0;
    public List<RescueCarController> followCars = new List<RescueCarController>();
    public int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        firstSpeedCar = car.moveSpeed;
        cfc = this;
    }

    // Update is called once per frame
    void Update()
    {  
        if(control)
        {
            CarsUpdateSpeed();
        }
        //if (car.moveSpeed<firstSpeedCar || car.moveSpeed>firstSpeedCar)
        //{
        //    CarsUpdateSpeed();
        //}
    }

    void CarsUpdateSpeed()
    {
        if (i == 0)
        {
            followCars[i].speed = car.moveSpeed / 2;
            i++;
            control = false;
        }
        else
        {
            followCars[i].speed = followCars[i - 1].speed / minFollowDistance;
            i++;
            control = false;
        }
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
            followCars.Add(res);
            followCars[0].player = car.transform;
            followCars[0].speed = car.moveSpeed / 2;
            res.followID = 1;
        }
        else
        {
            int value = followCars.Count;
            res.player = followCars[value - 1].gameObject.transform;
            res.speed = followCars[value - 1].speed/ minFollowDistance;
            followCars.Add(res);
            res.followID = value;

        }

    }

    public void RemoveFollowCarList(RescueCarController rem)
    {
        followCars.Remove(rem);
    }
}
