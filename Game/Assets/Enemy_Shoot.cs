using System.Collections;
using System.Collections.Generic;

using System.Security.Cryptography;
using UnityEngine;

public class Enemy_Shoot : MonoBehaviour
{
    private Animator myAnim;
    private Rigidbody2D rb;
    private Transform player;
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        myAnim.SetBool("isMoving", true);
        myAnim.SetFloat("moveX", (player.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (player.position.y - transform.position.y));
        myAnim.SetBool("isAttacking", false);
         
       

       if (Vector3.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
           
        }
        else if (Vector3.Distance(transform.position, player.position) < stoppingDistance && Vector3.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
            myAnim.SetBool("isMoving", false);
        
            
        }
        else if (Vector3.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            
        }


        if (timeBtwShots <= 0)
        {
            myAnim.SetBool("isAttacking", true);
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
            
           
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
           
        }
        if (timeBtwShots <= 1)
        {
            myAnim.SetBool("isAttacking", false);
        }
    }
  
}
