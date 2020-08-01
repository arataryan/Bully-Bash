using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    private bool isAttacking;

    Vector2 movement;

    // Update is called once per frame

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

        if (movement != Vector2.zero)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
        }
        
        animator.SetFloat("Speed", movement.sqrMagnitude);

        rb.MovePosition(rb.position + movement * movementSpeed * Time.deltaTime);


    }

    
    

}
