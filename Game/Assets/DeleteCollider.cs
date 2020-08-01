using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteCollider : MonoBehaviour
{
   
    public WaveSpawner waveSpawner;
    
    public bool isDone;



    // Start is called before the first frame update
   public void Start()
    {
        isDone = false;
        waveSpawner = GetComponent<WaveSpawner>();
    }

    // Update is called once per frame
    public void Done()
    {
        if (isDone = true)
        {
            gameObject.SetActive(false);
        }
    }
}
