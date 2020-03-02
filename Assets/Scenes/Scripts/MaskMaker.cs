using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskMaker : MonoBehaviour
{
    public SpriteMask plowIt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(plowIt, transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
    }
}
