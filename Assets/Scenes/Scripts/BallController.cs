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

    void Awake()
    {
        for (int i = 0; i < counter; i++)
        {
            winterBall.Add(Instantiate(objGo));
          // winterBall[i].transform.parent = this.transform;
            winterBall[i].transform.position = new Vector3(Random.Range(-5f, 5f), objGo.transform.position.y, objGo.transform.position.z+ (i*20) );
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
    void Update()
    {
        
    }
}
