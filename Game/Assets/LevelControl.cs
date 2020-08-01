using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    public int index;
    private HealthManager healthMan;
    public int currentHealth;
    public int maxHealth;
    public int reloadIndex;
    // Start is called before the first frame update


    void Start()
    {
        healthMan = FindObjectOfType<HealthManager>();
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(index);
            currentHealth = maxHealth;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
