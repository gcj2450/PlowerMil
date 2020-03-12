using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskMaker : MonoBehaviour
{
    public GameObject group;
    public int spriteAmount = 50;
    //public List<SpriteMask> spritePrefab = new List<SpriteMask>();
    public List<SpriteMask> spriteList = new List<SpriteMask>();
    public SpriteMask plowIt;
    public  bool winterPathTrigger;
    private float lastGeneratePosZ = float.MinValue;
    public float deltaValue = 1;
    public int index = 0;


    void Awake()
    {
        for (int i = 0; i < spriteAmount; i++)
        {
            spriteList.Add(Instantiate(plowIt, transform.position, Quaternion.identity));
            spriteList[i].gameObject.name = "PlowMask" + i;
            spriteList[i].gameObject.transform.parent = group.transform;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (winterPathTrigger)
        {

            if (transform.position.z - deltaValue > lastGeneratePosZ)
            {
                lastGeneratePosZ = transform.position.z;
                WinterPathShadow();
            }

        }
    }

    void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Snow")
        {
            winterPathTrigger = true;
        }
    }

    void WinterPathShadow()
    {
        Instantiate(plowIt, transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));

        if (index >= spriteList.Count - 1)
            index = 0;
        else
        {
            index++;
            spriteList[index].transform.position = transform.position;
            spriteList[index].transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
        }
    }
}
