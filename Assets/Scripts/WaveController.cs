using System;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof (LineRenderer))]
public class WaveController : MonoBehaviour {
	private LineRenderer lineRen;
    public float freq = 1.0f;
    public int waveCount = 10;
    public int linesPerWave = 10;
    public float amplitude = 1.0f;
    public GameObject cannon;

	// Use this for initialization
	void Start () {
		lineRen = GetComponent<LineRenderer> ();
        RegenWave();

    }
	
	// Update is called once per frame
	void Update () {
        RegenWave();
    }

    void RegenWave()
    {
        int lineCount = waveCount * linesPerWave;
        lineRen.numPositions = lineCount;

        List<Vector3> positions = new List<Vector3>();

        float lineLength = 1 / freq / linesPerWave;

        for (int i = 0; i < lineCount; i++)
        {
            Vector3 position = new Vector3(cannon.transform.position.x + i * lineLength, cannon.transform.position.y + (float) Math.Sin((float) i / (float) linesPerWave * Math.PI * 2.0f) * amplitude, 0.0f);
            positions.Add(position);
        }

        lineRen.SetPositions(positions.ToArray());

    }
}
