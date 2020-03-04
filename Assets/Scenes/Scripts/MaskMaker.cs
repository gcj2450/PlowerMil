using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskMaker : MonoBehaviour
{
    public SpriteMask plowIt;
    public  bool winterPathtrigger;
    private float lastGeneratePosZ = float.MinValue;
    public float deltaValue = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (winterPathtrigger)
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
            winterPathtrigger = true;
        }
    }

    void WinterPathShadow()
    {
        Instantiate(plowIt, transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
    }
}
