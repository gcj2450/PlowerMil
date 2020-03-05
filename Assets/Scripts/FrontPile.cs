using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontPile : MonoBehaviour
{
    MeshRenderer[] rendList;
    void Awake()
    {
        rendList = GetComponentsInChildren<MeshRenderer>();
        foreach (var item in rendList)
        {
            item.enabled = false;
        }
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Snow"))
        {
            Debug.Log("***SnowFrontHitted***");
            foreach (var item in rendList)
            {
                item.enabled = true;
            }
        }
    }
}
