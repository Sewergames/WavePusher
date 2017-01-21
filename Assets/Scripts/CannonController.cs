using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour {
    public GameObject wave;
    public GameObject head;
    public GameObject headLeft;
    public GameObject headRight;
    public float temp;

    public float positionSpeed;
    public float rotSpeed;
    public float amplitudeSpeed;
    public float freqSpeed;

    public float ampMin;
    public float ampMax;
    public float freqMin;
    public float freqMax;

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

        waveContr.amplitude = Mathf.Min(Mathf.Max(waveContr.amplitude, ampMin), ampMax);
        waveContr.freq = Mathf.Min(Mathf.Max(waveContr.freq, freqMin), freqMax);

        transform.rotation = Quaternion.Euler(0.0f, 0.0f, waveContr.rotation - 90.0f);

        temp = waveContr.amplitude * 2.2f;

        head.transform.localScale = new Vector3(temp, 1.0f, 1.0f);
        headLeft.transform.localPosition = new Vector3(-temp / 2.0f, 0.0f, 0.0f);
        headRight.transform.localPosition = new Vector3(temp / 2.0f, 0.0f, 0.0f);

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
