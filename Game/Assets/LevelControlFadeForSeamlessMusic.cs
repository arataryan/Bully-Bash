using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelControlFadeForSeamlessMusic : MonoBehaviour
{
    // Start is called before the first frame update
    public int index;
    private HealthManager healthMan;
    public int currentHealth;
    public int maxHealth;
    public int reloadIndex;

    public Image black;
    public Animator anim;

    public int secondsToFadeOut = 5;
    // Start is called before the first frame update


    void Start()
    {
        healthMan = FindObjectOfType<HealthManager>();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            
            StartCoroutine(Fading());
        }
    }

    // Update is called once per frame
    void Update()
    {


    }

    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
    
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(index);
        currentHealth = maxHealth;


    }
}
