using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBoss : MonoBehaviour
{
    public int damageToGive = 2;
    public CameraShake cameraShake;
    // Start is called before the first frame update






    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            BossHealthManager bHealthMan;
            bHealthMan = other.gameObject.GetComponent<BossHealthManager>();

            bHealthMan.HurtEnemy(damageToGive);

            ScreenShakeController.instance.StartShake(.035f, .08f);



        }


    }
}
