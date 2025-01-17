﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileMaker : MonoBehaviour
{
    public GameObject group;
    public List<GameObject> pilePrefab = new List<GameObject>();

    public List<GameObject> PileList = new List<GameObject>();
    public bool winterPathtrigger = false;
    
    public int winterAmount = 50;

    public int index = 0;

    [SerializeField] private bool obstacle = false;
    [SerializeField] private float boundarySide = 7;


    void Awake()
    {
        for (int i = 0; i < winterAmount; i++)
        {
            PileList.Add(Instantiate(pilePrefab[Random.Range(0,pilePrefab.Count)], transform.position, Quaternion.identity));
            PileList[i].SetActive(false);
            PileList[i].gameObject.name = "WinterMass" + i;
            PileList[i].gameObject.transform.parent = group.transform;
        }
    }
    // Start is called before the first frame update





    public float lastGeneratePosZ = float.MinValue;
    public float obsLastGeneratePosZ=0.0f;
    public float deltaValue = 1;
    public float obstacleDistanceValue=0.7f;

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.x) > boundarySide)
        {
            obstacle = true;
        }
        else
        {
            obstacle = false;
        }


        if (winterPathtrigger && !obstacle)
        {

            if (transform.position.z - deltaValue > lastGeneratePosZ)
            {
                lastGeneratePosZ = transform.position.z;
                PlacePile();
            }

        }

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Snow") )
        {
            winterPathtrigger = true;

        }

    }
    private void OnTriggerExit(Collider other)
    {
        winterPathtrigger = false;
    }


    void PlacePile()
    {

        if (index >= PileList.Count - 1)
            index = 0;
        else
        {
            index++;
            PileList[index].transform.position = transform.position;
            PileList[index].transform.rotation = Quaternion.Euler(new Vector3(Random.Range(-90, 90), Random.Range(-90, 90), Random.Range(-90, 90)));
            PileList[index].SetActive(true);
        }



    }
}
