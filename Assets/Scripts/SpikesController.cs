using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikesController : MonoBehaviour {

    [SerializeField]
    private GameObject Apple;


	void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Apple")
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
