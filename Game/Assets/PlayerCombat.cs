using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private float attackTime = 3f;
    private float attackCounter = 3f;
    public Animator animator;
    private bool isAttacking;
    //public Rigidbody2D rb;
    private float speed;
    public AudioSource hitSound;
    
    
    // Update is called once per frame
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        hitSound = GetComponent<AudioSource>();
    }
    void Update()
    {
        //rb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
            hitSound.Play();
            
            attackCounter = attackTime;
        }

        
           
        
    }

    void Attack()
    {
        animator.SetBool("isAttacking", true);
        animator.SetTrigger("Attack");
    }
}
