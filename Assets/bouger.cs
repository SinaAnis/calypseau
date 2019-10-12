using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouger : MonoBehaviour
{

    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        animator.Play("idle");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Z))
        {
            transform.Translate(0, 0, 0.05f);
            animator.Play("walk");
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -2, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -0.05f);
            animator.Play("walk");
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 2, 0);
        } 
    }
}
