using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject objGo;
    public List<GameObject> winterBall = new List<GameObject>();
    public int counter = 0;
    public float distance = 0.0f;
    public GameObject car;

    void Awake()
    {
        for (int i = 0; i < counter; i++)
        {
            winterBall.Add(Instantiate(objGo));
           
          // winterBall[i].transform.parent = this.transform;
            winterBall[i].transform.position = new Vector3(Random.Range(-5f, 5f), transform.position.y, transform.position.z+ (i*20) );
            winterBall[i].SetActive(false);

        }
    }
    void Start()
    {
        //for (int i = 0; i < counter; i++)
        //{
        //   
        //}
    }

    // Update is called once per frame
    private int index = 0;
    void Update()
    {
        if (index<counter)
        {
            if (Vector3.Distance(car.transform.position, winterBall[index].transform.position) <= distance)
            {
                winterBall[index].SetActive(true);
                index++;
            }
        }
       
    }
}
