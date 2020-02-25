using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PileMaker : MonoBehaviour
{
    public GameObject pilePrefab;
    public GameObject group;
    public GameObject[] PileList;

    

    int index = 0;

  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Instantiate(pilePrefab, transform.position, Quaternion.identity);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Snow"))
        {
            if (index > PileList.Length-1)
                index = 0;

            Debug.Log("***SnowStay***");
            //Instantiate(pilePrefab, transform.position, Quaternion.Euler(new Vector3(Random.Range(-90,90), Random.Range(-90, 90), Random.Range(-90, 90))));
            PlacePile();
            index++;
        }
    }
    
    void PlacePile()
    {
        PileList[index].transform.position = transform.position;
        PileList[index].transform.rotation = Quaternion.Euler(new Vector3(Random.Range(-90, 90), Random.Range(-90, 90), Random.Range(-90, 90)));
    }
}
