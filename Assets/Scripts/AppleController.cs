using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleController : MonoBehaviour {
    public GameObject GameOverScreen;

    void Update()
    {
        Vector3 vec = Camera.main.WorldToViewportPoint(transform.position);

        if (vec.y <= -0.1f)
        {
            GameOverScreen.SetActive(true);
        }
    }
}