using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class LevelControlFade : MonoBehaviour
{
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
            
            //StartCoroutine(findAudioAndFadeOut());
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
        AudioSource audioMusic = GameObject.Find("CombatAudio").GetComponent<AudioSource>();
        while (audioMusic.volume > 0.01f)
        {
            audioMusic.volume -= Time.deltaTime / secondsToFadeOut;
            yield return null;
        }
        audioMusic.volume = 0;

        // Stop Music
        audioMusic.Stop();
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene(index);
        currentHealth = maxHealth;


    }
   /* IEnumerator findAudioAndFadeOut()
    {
        // Find Audio Music in scene
        AudioSource audioMusic = GameObject.Find("CombatAudio").GetComponent<AudioSource>();

        // Check Music Volume and Fade Out
        while (audioMusic.volume > 0.01f)
        {
            audioMusic.volume -= Time.deltaTime / secondsToFadeOut;
            yield return null;
        }

        // Make sure volume is set to 0
        audioMusic.volume = 0;

        // Stop Music
        audioMusic.Stop();

        // Destroy
        Destroy(this);
    
    }
    */
}






