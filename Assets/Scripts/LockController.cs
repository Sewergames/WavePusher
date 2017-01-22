using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockController : MonoBehaviour {
    public List<string> levelsCompleted;

	void Awake ()
    {
        DontDestroyOnLoad(this);
        SceneManager.LoadScene("MainMenu");
    }
	
	void Update () {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            GameObject locksParent = GameObject.Find("Locks");

            for (int i = 0; i < locksParent.transform.childCount; i++)
            {
                if (i < levelsCompleted.Count)
                {
                    GameObject levelLock = locksParent.transform.GetChild(i).gameObject;
                    levelLock.SetActive(false);
                }
            }
        }
    }
}
