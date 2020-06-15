using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControl : MonoBehaviour
{
     int point = 0;

    private GameObject carGo;
    // Start is called before the first frame update
    void Start()
    {
        carGo = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        point = (int) carGo.transform.position.z;
        UIManager.ui.pointText.text = point.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag=="box")
        {
            
        }

        if (other.gameObject.tag=="barrel")
        {
            
        }

        if (other.gameObject.tag=="bomb")
        {
            
        }
        
    }
}
