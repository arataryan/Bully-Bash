using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ThadShoot : MonoBehaviour
{
    private Animator myAnim;
    private Rigidbody2D rb;
    private Transform player;
    private float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    public GameObject enemy02;
    public Transform building;

    private BossHealthManager healthMan;



    

  

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startTimeBtwShots;

        healthMan = GetComponent<BossHealthManager>();

      
    }

    // Update is called once per frame
    void Update()
    {
        myAnim.SetBool("isMoving", true);
        myAnim.SetFloat("moveX", (player.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (player.position.y - transform.position.y));
        myAnim.SetBool("isAttacking", false);


        if (healthMan.currentHealth >= 17)
        {
            
           
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
               
                Instantiate(enemy02, building.position, Quaternion.identity);

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
        else if (healthMan.currentHealth <= 16 && healthMan.currentHealth >= 0)
        {
            speed = 4.5f;
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (healthMan.currentHealth <= 8 && healthMan.currentHealth >= 0)
        {
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
               
                Instantiate(projectile, transform.position, Quaternion.identity);

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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "MyWeapon")
        {
            Vector2 difference = transform.position - other.transform.position;
            transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
        }
    }
    


}
