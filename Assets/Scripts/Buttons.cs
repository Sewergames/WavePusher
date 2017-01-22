using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour {
    public GameObject pauseMenu;

    

	void Start ()
    { 

	}
	
	void Update ()
    { 
        
	}

    public void MainMenu()
    {       
            SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void exit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
       
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
