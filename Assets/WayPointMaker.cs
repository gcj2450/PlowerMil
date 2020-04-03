using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointMaker : MonoBehaviour
{
    public float minDistance;
    public Transform carPathPoint;
    public Transform[] carPathList;

    private Vector3 beforePos = Vector3.zero;
    private Vector3 lastPos = Vector3.zero;
    private int carPathPointIndex = 0;

    private void Awake()
    {

        minDistance = Mathf.PI * 3.8f /3;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Snow"))
        {
            beforePos = transform.position;
            lastPos = beforePos;
        }

    }

    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Snow"))
        {
            lastPos = transform.position;
            if (Mathf.Abs(Vector3.Distance(lastPos, beforePos)) > minDistance)
                PointMaker();
        }

    }

    void PointMaker()
    {

        //Instantiate(transform, transform.position, Quaternion.identity);
        if (carPathPointIndex < carPathList.Length)
        {
            carPathList[carPathPointIndex].position = transform.position;
            carPathPointIndex++;
        }
        else
        {
            carPathPointIndex = 0;
            return;
        }

        beforePos = transform.position;
    }

}
