using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour {
    public GameObject wave;
    public GameObject head;
    public GameObject headLeft;
    public GameObject headRight;

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

        float posDelta = Input.GetAxis("Position") * positionSpeed;
        float rotDelta = Input.GetAxis("Rotation") * rotSpeed;
        float ampDelta = Input.GetAxis("Amplitude") * amplitudeSpeed;
        float freqDelta = Input.GetAxis("Frequency") * freqSpeed;

        waveContr.position += posDelta;
        waveContr.rotation += rotDelta;
        waveContr.amplitude += ampDelta;
        waveContr.freq += freqDelta;

        waveContr.amplitude = Mathf.Min(Mathf.Max(waveContr.amplitude, ampMin), ampMax);
        waveContr.freq = Mathf.Min(Mathf.Max(waveContr.freq, freqMin), freqMax);

        Color col = Color.HSVToRGB(map(waveContr.freq, freqMin, freqMax, 1.0f, 0.0f), 1.0f, 1.0f);
        wave.gameObject.GetComponent<LineRenderer>().material.color = col;

        transform.rotation = Quaternion.Euler(0.0f, 0.0f, waveContr.rotation - 90.0f);

        float temp = waveContr.amplitude * 2.2f;

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

    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }
}
