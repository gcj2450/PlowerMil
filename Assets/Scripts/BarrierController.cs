using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject objGo;
    public List<GameObject> winterBall = new List<GameObject>();
    public int ballAmaount = 0;

    void Awake()
    {

        for (int i = 0; i < ballAmaount; i++)
        {
            //winterBall.Add(Instantiate(objGo,objGo.transform));
            //winterBall[i].transform.position= 
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
