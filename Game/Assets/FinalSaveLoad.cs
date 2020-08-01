using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSaveLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("SceneSaved", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
