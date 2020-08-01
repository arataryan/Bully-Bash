using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Heart : MonoBehaviour
{
   public int heartHealth;
    private HealthManager healthMan;
    private int currentHealth;
    private int maxHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        healthMan = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
   void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            Destroy(gameObject);

           
        }
        if (other.CompareTag("MyWeapon"))
        {
            Destroy(gameObject);
        }
    }
    
}
