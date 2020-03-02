using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlowerRotator : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            animator.SetFloat("Rotation", gameObject.GetComponentInParent<Transform>().rotation.eulerAngles.y);
        //Debug.Log(gameObject.GetComponentInParent<Transform>().rotation.eulerAngles.y);
        
    }


}
