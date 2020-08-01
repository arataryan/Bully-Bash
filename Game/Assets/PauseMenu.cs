using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Canvas pauseMenu;
    private bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.enabled = false;
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.P)))
        {
            pauseMenu.enabled = true;
            Time.timeScale = 0;
            isPaused = true;
           
        }
      
    }


    public void ResumePlay()
    {
        pauseMenu.enabled = false;
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void ReturnMenu()
    {
        //might change later
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
