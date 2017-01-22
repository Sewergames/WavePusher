using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour {
    public float click = 0;
    

	void Start ()
    {

	}
	
	void Update ()
    { 
        Restart();
	}

    public void MainMenu(string MainMenu)
    {
        
        
            Application.LoadLevel("Main Menu");
        
    }

    void exit()
    {

    }

    public void Restart()
    {
            Application.LoadLevel(Application.loadedLevel);
    }
}
