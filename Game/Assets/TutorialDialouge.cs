using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Specialized;
using UnityEngine.SceneManagement;

public class TutorialDialouge : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public Image MC;
    public Image Enemy;

    public GameObject continueButton;

    public Animator textDisplayAnim;

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
        }
        if (index == 1)
        {
            Enemy.enabled = false;
            MC.enabled = true;
        }
        if (index == 3)
        {
            SceneManager.LoadScene(sceneIndex);
            currentHealth = maxHealth;
        }
    }

    public void NextSentence()
    {
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
