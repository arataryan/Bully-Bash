using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public int heartHealth;

    private bool flashActive;
    [SerializeField]
    private float flashLength = 0f;
    private float flashCounter = 0f;
    private SpriteRenderer playerSprite;
    private Heart heart;
    public GameObject hearts;
    private EnemyHealthManager enemHealth;
    public bool isHealth;
    public GameObject healthParticles;

    public int reloadIndex;



    public Canvas gameOver;
    public Animator anim;
    public bool isOver = false;





    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        heart = FindObjectOfType<Heart>();
        enemHealth = GetComponent<EnemyHealthManager>();
        gameOver.enabled = false;
        anim = GetComponent<Animator>();
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (flashActive)
        {
            if (flashCounter > flashLength * .99f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .82f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * .66f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .49f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * .33f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .16f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if (flashCounter > 0)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;



           
        }
    }


    public void HurtPlayer(int damageToGive)
    {
        currentHealth -= damageToGive;
        flashActive = true;
        flashCounter = flashLength;

        StartCoroutine("Invulnerable");
        //currentHealth = currentHealth - damageToGive
        if (currentHealth <= 0)
        {
            //ReloadScene();
            gameObject.SetActive(false);
            
            gameOver.enabled = true;
            anim.SetBool("isOver", true);

        }

    }
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Heart"))
        {
            currentHealth = currentHealth + heartHealth;

            Instantiate(healthParticles, transform.position, Quaternion.identity);


            if (currentHealth > 50)
            {
                currentHealth = 50;
            }
            
            

        }
    }
    public void ReloadScene()
    {
        if(currentHealth <= 0)
        {
            SceneManager.LoadScene(reloadIndex);
        }
    }


    IEnumerator Invulnerable()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);
        yield return new WaitForSeconds(.6f);
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }



}
