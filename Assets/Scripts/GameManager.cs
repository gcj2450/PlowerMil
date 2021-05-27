using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public float waitTimeForGameOver = 2f;

    float waitTimeForGameOverTemp;

    [SerializeField] GameObject fallObstacle;

    private void Awake()
    {
        //fallObstacle = GameObject.Find("FallObstacle");
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float truckVelocity = player.GetComponent<TruckMover>().moveSpeed;
        if (truckVelocity == 0)
            waitTimeForGameOverTemp += Time.deltaTime;
        else
            waitTimeForGameOverTemp = 0;


        if (waitTimeForGameOverTemp > waitTimeForGameOver)
        {
            waitTimeForGameOverTemp = 0;
        }


        if (player.transform.position.z > 335)
        {

            GameOver();
        }
    }

    void GameOver()
    {
        /* This is the end of the level*/
        // Time.timeScale = 0;
        TruckMover.player.control = false;
        Debug.Log("***GameOver***");
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(2);
        GameOver();
    }

    void GameFinisher()
    {
        Instantiate(fallObstacle, new Vector3(player.transform.position.x, player.transform.position.y + 12f, player.transform.position.z), Quaternion.identity);
    }
}
