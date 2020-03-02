using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskController : MonoBehaviour
{
    public Transform playerTruck;
    // Start is called before the first frame update
    void Start()
    {
        playerTruck = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceZ = playerTruck.position.z-transform.position.z;
        if (Mathf.Abs(distanceZ) > 10)
            Destroy(gameObject);
    }
}
