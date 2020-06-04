using UnityEngine;
using UnityEngine.AI;

public class RescueCarController : MonoBehaviour
{
    public Transform player;
    public Collider coll;
    //public GameObject[] wayPointPosList;

    private NavMeshAgent agent;
    private Vector3 wayPointPos;
    private Ray ray;
    private Vector3 localForward;

    [SerializeField]private GameObject wayPoint;
    [SerializeField]private float speed = 0.5f;
    [SerializeField] private float minDistance = 3f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        coll = GetComponent<Collider>();
        //agent = GetComponent<NavMeshAgent>();
        //At the start of the game, car will find the player.
        Debug.Log(GameObject.FindGameObjectWithTag("Player").name);
        wayPoint = GameObject.FindGameObjectWithTag("Player");
        localForward = transform.worldToLocalMatrix.MultiplyVector(transform.forward);
    }

 

    void Update()
    {
        wayPoint = FindClosestWP();
        if (wayPoint != null)
        {
            wayPointPos = new Vector3(wayPoint.transform.position.x, transform.position.y, wayPoint.transform.position.z);
            MoveCar();
            CarRotate();
        }
            

        //if (Vector3.Distance(transform.position,wayPointPos)<=minDistance)
        //{
        //    MoveCar();
        //    CarRotate();
        //}


    }


    void MoveCar()
    {
        //if (Vector3.Distance(transform.position, wayPointPos) < 3)
        //{
        //    return;
        //}
        wayPointPos = new Vector3(wayPoint.transform.position.x, transform.position.y, wayPoint.transform.position.z);
        //Car following player
        transform.position = Vector3.Lerp(transform.position, wayPointPos, speed * Time.fixedDeltaTime);
       
    }

    void CarRotate()
    {
        transform.LookAt(wayPointPos,Vector3.up);
    }

    GameObject FindClosestWP()
    {
        GameObject closestWPTemp = null;
        GameObject[] wayPointPosListTemp;
        wayPointPosListTemp = GameObject.FindGameObjectsWithTag("RescueCarTarget");
        float distance = Mathf.Infinity;
        //wayPointPosListTemp.OrderBy(x => x.transform.position.z);
        foreach (var wayPointTemp in wayPointPosListTemp)
        {
            if (wayPointTemp.transform.position.z >= transform.position.z+2)
            {
                var diff = Vector3.Distance(wayPointTemp.transform.position, transform.position);
                if (diff < distance)
                {
                    closestWPTemp = wayPointTemp;
                    distance = diff;
                }
            }

        }
        return closestWPTemp;
    }
}
