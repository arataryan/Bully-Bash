using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
   
    private bool flashActive;
    [SerializeField]
    private float flashLength = 0f;
    private float flashCounter = 0f;
    private SpriteRenderer enemySprite;
    public GameObject bloodParticle;
    public GameObject hitParticle;
    public GameObject heart;
    public GameObject cone_1;
    public GameObject cone_2;
    //public GameObject thing;

    public AudioSource hitSound;

    // Start is called before the first frame update
    void Start()
    {
        enemySprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (flashActive)
        {
            if (flashCounter > flashLength * .99f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .82f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * .66f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .49f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
            }
            else if (flashCounter > flashLength * .33f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            }
            else if (flashCounter > flashLength * .16f)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
            }
            else if (flashCounter > 0)
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 0f);
            }
            else
            {
                enemySprite.color = new Color(enemySprite.color.r, enemySprite.color.g, enemySprite.color.b, 1f);
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }
    }
    public void HurtEnemy(int damageToGive)
    {
        hitSound.Play();
        currentHealth -= damageToGive;
        flashActive = true;
        flashCounter = flashLength;
        Instantiate(hitParticle, transform.position, Quaternion.identity);

        if (currentHealth <= 0)
        {

            StartCoroutine("Die");
        }
    }

    IEnumerator Die()
    {
        hitSound.Play();
        yield return new WaitForSeconds(.07f);
        Instantiate(bloodParticle, transform.position, Quaternion.identity);
        //Instantiate(heart, new Vector3(transform.position.x, transform.position.y, 10), Quaternion.identity);

        Destroy(cone_1);
        Destroy(cone_2);


        Destroy(gameObject);
    }
}
