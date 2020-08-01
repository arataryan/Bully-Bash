using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public Image black;
    public Animator anim;
    public int index;

    public int secondsToFadeOut = 5;

    private AudioSource click;
    // Start is called before the first frame update
    void Start()
    {
        click = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Quit()
    {
        click.Play();
        Application.Quit();
    }
    public void Play()
    {
        StartCoroutine(FadingPlay());
        //Will change later and use PlayerPrefs (GetActiveScene().buildIndex)
        //Search Save and load whole scene on unity answers
       

    }
    IEnumerator FadingPlay()
    {
        click.Play();
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

       
        SceneManager.LoadScene(PlayerPrefs.GetInt("SceneSaved"));
    }

    IEnumerator FadingNewGame()
    {
        click.Play();
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


        SceneManager.LoadScene(index);
    }

    public void newGame()
    {
        StartCoroutine("FadingNewGame");
    }
}
