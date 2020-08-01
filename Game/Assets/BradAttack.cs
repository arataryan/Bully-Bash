using System.Collections;
using System.Collections.Generic;

using System.Security.Cryptography;
using UnityEngine;

public class BradAttack : MonoBehaviour
{
    private EnemyHealthManager healthMan;
    private Animator myAnim;
    private Transform player;
    public float rangeTimer1;
    public float rangeTimer2;
    public float meleeTimer;
    public float distance;
    public float speed;
   
    public GameObject projectile1;
    public GameObject projectile2;
    public GameObject projectile3;
    public GameObject projectile4;

    public Transform BradFace1;
    public Transform BradFace2;
    public Transform BradFace3;
    public Transform BradFace4;

    public Transform BradFace5;
    public Transform BradFace6;
    public Transform BradFace7;

    private Vector2 testing;


    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        healthMan = GetComponent<EnemyHealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        myAnim.SetBool("isMoving", true);
        myAnim.SetFloat("moveX", (player.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (player.position.y - transform.position.y));
        myAnim.SetBool("isAttacking", false);
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        rangeTimer1 = rangeTimer1 - Time.deltaTime;
        rangeTimer2 = rangeTimer2 - Time.deltaTime;

        
        if (rangeTimer1 <= 0)
        {
            Debug.Log("Ranged Attack");
            //do animation
            Instantiate(projectile1, BradFace1.position, Quaternion.identity);
            Instantiate(projectile2, BradFace2.position, Quaternion.identity);
            Instantiate(projectile3, BradFace3.position, Quaternion.identity);
            Instantiate(projectile4, BradFace4.position, Quaternion.identity);
            rangeTimer1 = 4;

        }

        Invoke("SecondVolley", 2f);
        
       
        if (Vector3.Distance(transform.position, player.position) < distance)
        {

            Debug.Log("MeleeAttack");
            //do animation
            myAnim.SetBool("isAttacking", true);

        }

        if(healthMan.currentHealth <= 20)
        {
            speed = 3.5f;
        }
      
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "MyWeapon")
        {
            testing = new Vector2(2f, 2f);
            Vector2 difference = transform.position - other.transform.position;
            transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
        }
    }

    private void SecondVolley()
    {
        
        if (rangeTimer2 <= 0)
        {
           

            Debug.Log("Ranged Attack");
            //do animation
            Instantiate(projectile1, BradFace5.position, Quaternion.identity);
            Instantiate(projectile2, BradFace6.position, Quaternion.identity);
            Instantiate(projectile3, BradFace7.position, Quaternion.identity);

            rangeTimer2 = 4;

        }
        

    }

}
