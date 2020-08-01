using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBarManager : MonoBehaviour
{
    

    private BossHealthManager healthMan;

    public Slider healthBar;

    public Text hpText;

    // Start is called before the first frame update
    void Start()
    {
        //healthMan = FindObjectOfType<EnemyHealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        healthMan = FindObjectOfType<BossHealthManager>();
        healthBar.maxValue = healthMan.maxHealth;
        healthBar.value = healthMan.currentHealth;

        hpText.text = "HP: " + healthMan.currentHealth + "/" + healthMan.maxHealth;
    }
}
