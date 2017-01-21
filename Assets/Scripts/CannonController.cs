using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour {
    public GameObject wave;
    public float positionSpeed;
    public float rotSpeed;
    public float amplitudeSpeed;
    public float freqSpeed;

    private WaveController waveContr;

	void Start () {
        waveContr = wave.GetComponent<WaveController>();

    }
	
	void Update () {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z -= Camera.main.transform.position.z;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 vec = mousePos - transform.position;
        

       // waveContr.rotation = transform.rotation.eulerAngles.z + 90.0f;

        waveContr.position += Input.GetAxis("Position") * positionSpeed;
        waveContr.rotation += Input.GetAxis("Rotation") * rotSpeed;
        waveContr.amplitude += Input.GetAxis("Amplitude") * amplitudeSpeed;
        waveContr.freq += Input.GetAxis("Frequency") * freqSpeed;

        transform.rotation = Quaternion.Euler(0.0f, 0.0f, waveContr.rotation - 90.0f);

        if (Input.GetAxisRaw("Show") >= 0.0f)
        {
            waveContr.draw = true;
        }
        else
        {
            waveContr.draw = false;
        }
    }
}
