using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAudio : MonoBehaviour
{
    public GameObject AudioManager;
    // Start is called before the first frame update
    void Start()
    {
        AudioManager = GameObject.Find("Audio Manager");
        Destroy(AudioManager);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
