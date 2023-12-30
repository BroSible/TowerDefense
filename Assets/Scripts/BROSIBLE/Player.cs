using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public PlayerController controller;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    public bool jump = false;
    public bool run = false;
    public Animator animator;

    
    
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if(Input.GetKey("a") || Input.GetKey("d"))
        {
            run = true;
        }

        else
        {
            run = false;
        }

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.Play("Princess jump");
        }
    }

    void FixedUpdate()
    {
       controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
       jump = false;

       if(run)
       {
            animator.Play("Princess run");
       }

       else
       {
            if(Input.GetButton("Fire1"))
            {
                animator.Play("Princess ability");
            }

            else if(jump)
            {
                animator.Play("Princess jump");
            }

            else if(!jump && !run)
            {
                animator.Play("Princess Idle");
            }

            controller.Move(0, false);
       }
    }
}


