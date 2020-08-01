using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMusicSelecter : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private static BGMusicSelecter instance = null;
    public static BGMusicSelecter Instance
    {
        get { return instance; }
    }

    // Update is called once per frame
    void Awake()
    {
      if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
   
}
