using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThadCombat : MonoBehaviour
{
    private HealthManager healthMan;
    public float waitToHurt = 2f;
    public bool isTouching;
    [SerializeField]
    private int damageToGive = 10;
    private Animator myAnim;
    public AudioSource playerDamage;
    public float currentHealth;


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
        healthMan = GetComponent<HealthManager>();
        myAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isTouching)
        {
            waitToHurt -= Time.deltaTime;
            if (waitToHurt <= 0)
            {
                healthMan.HurtPlayer(damageToGive);
                waitToHurt = 2f;
            }
        }



        if (currentHealth <= 30)
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

                Instantiate(projectile, transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
                myAnim.SetBool("isAttacking", true);

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
        else if (currentHealth <= 14)
        {
            speed = 10f;
        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {

            //Destroy(other.gameObject);
            //other.gameObject.SetActive(false);

            other.gameObject.GetComponent<HealthManager>().HurtPlayer(damageToGive);


            // reloading = true;
            ScreenShakeController.instance.StartShake(.15f, .1f);


            myAnim.SetBool("isAttacking", true);
            playerDamage.Play();

            // StartCoroutine("Invulnerable");
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            isTouching = true;
            ScreenShakeController.instance.StartShake(.05f, .05f);
            myAnim.SetBool("isAttacking", true);
            // Physics2D.IgnoreLayerCollision(10, 11, true);
        }

    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            isTouching = false;
            myAnim.SetBool("isAttacking", false);

        }
    }

    IEnumerator Invulnerable()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);
        yield return new WaitForSeconds(1f);
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }
}
