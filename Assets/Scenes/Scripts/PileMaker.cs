using System.Collections;
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


    void Awake()
    {
        for (int i = 0; i < winterAmount; i++)
        {
            PileList.Add(Instantiate(pilePrefab[Random.Range(0,6)], transform.position, Quaternion.identity));
            PileList[i].gameObject.name = "WinterMass" + i;
            PileList[i].gameObject.transform.parent = group.transform;
        }
    }
    // Start is called before the first frame update





    private float lastGeneratePosZ = float.MinValue;
    public float deltaValue = 1;

    // Update is called once per frame
    void Update()
    {
        if (winterPathtrigger)
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
        if (other.gameObject.CompareTag("Snow"))
        {
            winterPathtrigger = true;

        }
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
        }



    }
}
