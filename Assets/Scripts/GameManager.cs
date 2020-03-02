using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GameOver()
    {
        /* This is the end of the level*/
        Time.timeScale = 0;
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(2);
        GameOver();
    }
}
