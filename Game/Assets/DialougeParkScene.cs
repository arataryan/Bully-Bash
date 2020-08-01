using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Specialized;
using UnityEngine.SceneManagement;

public class DialougeParkScene : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public Image MC;
    public Image Enemy;
    public Image Thad;

    public GameObject continueButton;

    public Animator textDisplayAnim;

    private AudioSource click;

    //Scene loading stuff
    public int sceneIndex;
    private HealthManager healthMan;
    public int currentHealth;
    public int maxHealth;
    IEnumerator Type()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Type());

        healthMan = FindObjectOfType<HealthManager>();

        click = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }


        if (index == 0)
        {
            MC.enabled = false;
            Enemy.enabled = true;
            Thad.enabled = false;
        }
        if (index == 1)
        {
            Enemy.enabled = false;
            MC.enabled = true;
            Thad.enabled = false;
        }
        if (index == 2)
        {
            Enemy.enabled = true;
            MC.enabled = false;
            Thad.enabled = false;
        }
        if (index == 3)
        {
            Enemy.enabled = true;
            MC.enabled = false;
            Thad.enabled = false;
        }
        if (index == 4)
        {
            Enemy.enabled = true;
            MC.enabled = false;
            Thad.enabled = false;
        }
        if (index == 5)
        {
            Enemy.enabled = true;
            MC.enabled = false;
            Thad.enabled = false;
        }
        if (index == 6)
        {
            Enemy.enabled = true;
            MC.enabled = false;
            Thad.enabled = false;
        }
        if (index == 7)
        {
            Enemy.enabled = true;
            MC.enabled = false;
            Thad.enabled = false;
        }
        if (index == 8)
        {
            Enemy.enabled = true;
            MC.enabled = false;
            Thad.enabled = false;
        }
        if (index == 9)
        {
            Enemy.enabled = true;
            MC.enabled = false;
            Thad.enabled = false;
        }
        if (index == 10)
        {
            Enemy.enabled = true;
            MC.enabled = false;
            Thad.enabled = false;
        }
        if (index == 11)
        {
            Enemy.enabled = true;
            MC.enabled = false;
            Thad.enabled = false;
        }
        if (index == 12)
        {
            Enemy.enabled = true;
            MC.enabled = false;
            Thad.enabled = false;
        }
        if (index == 13)
        {
            Enemy.enabled = true;
            MC.enabled = false;
            Thad.enabled = false;
        }
        if (index == 14)
        {
            Enemy.enabled = true;
            MC.enabled = false;
            Thad.enabled = false;
        }
        if (index == 15)
        {
            Enemy.enabled = true;
            MC.enabled = false;
            Thad.enabled = false;
        }
        if (index == 16)
        {
            Enemy.enabled = true;
            MC.enabled = false;
            Thad.enabled = false;
        }
        if (index == 17)
        {
            Enemy.enabled = true;
            MC.enabled = false;
            Thad.enabled = false;
        }
        if (index == 18)
        {
            SceneManager.LoadScene(sceneIndex);
            currentHealth = maxHealth;
        }
    }

    public void NextSentence()
    {
        click.Play();
        textDisplayAnim.SetTrigger("Change");
        continueButton.SetActive(false);
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
        }


    }
}