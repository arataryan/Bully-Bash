using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayer : MonoBehaviour
{

    private HealthManager healthMan;
    public float waitToHurt = 2f;
    public bool isTouching;
    [SerializeField]
    private int damageToGive = 10;
    private Animator myAnim;
    public AudioSource playerDamage;


    // Start is called before the first frame update
    void Start()
    {
        healthMan = GetComponent<HealthManager>();
        myAnim = GetComponent<Animator>();
        // playerDamage = GetComponent<AudioSource>();
       
        //Physics2D.IgnoreLayerCollision(10, 11, false);
    }

    // Update is called once per frame
    void Update()
    {
       /* if (reloading)
        {
            waitToLoad -= Time.deltaTime;
            if (waitToLoad <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        */

        if (isTouching)
        {
            waitToHurt -= Time.deltaTime;
            if (waitToHurt <= 0)
            {
               healthMan.HurtPlayer(damageToGive);
               waitToHurt = 2f;
            }
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
