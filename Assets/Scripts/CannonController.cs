using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour {
    public GameObject wave;
    public float speed;

    private WaveController waveContr;

	void Start () {
        waveContr = wave.GetComponent<WaveController>();

    }
	
	void Update () {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z -= Camera.main.transform.position.z;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 vec = mousePos - transform.position;
        
        transform.rotation = Quaternion.LookRotation(Vector3.forward, vec);

        waveContr.rotation = transform.rotation.eulerAngles.z + 90.0f;

        waveContr.position += Input.GetAxis("Horizontal") * -speed;

        if (!Input.GetMouseButton(0))
        {
            waveContr.draw = true;
        }
        else
        {
            waveContr.draw = false;
        }
    }
}
