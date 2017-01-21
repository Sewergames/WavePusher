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
    public float rotation = 0.0f;
    public float position = 0.0f;
    public GameObject cannon;
    public GameObject mirrors;
    public int maxBounces = 2;
    
    private List<Vector3> positions;
    private int bounceCount = 0;

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
        bounceCount = 0;
        positions = new List<Vector3>();

        float lineLength = 1 / freq / linesPerWave;
        GenSemiWave(cannon.transform.position, rotation, lineLength, null, position);
        
        Vector3[] positionsArr = positions.ToArray();

        lineRen.numPositions = positionsArr.Length;
        lineRen.SetPositions(positionsArr);
    }

    float GenSemiWave(Vector3 start, float rot, float lineLength, GameObject reflectedMirror, float sinPos)
    {
        bounceCount++;
        int lineCount = waveCount * linesPerWave;
        
        for (int i = 0; i < lineCount; i++)
        {
            Vector3 pos = new Vector3(
                i * lineLength,
                (float) Math.Sin((float) i / (float) linesPerWave * Math.PI * 2.0f + sinPos) * amplitude,
                0.0f);

            pos = Quaternion.Euler(0, 0, rot) * pos;
            pos.x += start.x;
            pos.y += start.y;

            positions.Add(pos);
            
            for (int j = 0; j < mirrors.transform.childCount; j++)
            {
                GameObject mirror = mirrors.transform.GetChild(j).gameObject;
                BoxCollider2D col = mirror.GetComponent<BoxCollider2D>();

                if (col.OverlapPoint(pos) && reflectedMirror != mirror)
                {
                    Vector3 normal = Quaternion.Euler(0.0f, 0.0f, mirror.transform.eulerAngles.z + 90.0f) * Vector3.up;

                    Vector3 vec = Quaternion.Euler(0.0f, 0.0f, rot) * Vector3.right;

                    Vector3 reflection = Vector3.Reflect(vec, normal);

                    float rot2 = (float)(Math.Atan2(1.0f, 0.0f) - Math.Atan2(reflection.x, reflection.y)) * Mathf.Rad2Deg;

                    if (bounceCount <= maxBounces)
                        GenSemiWave(pos, rot2, lineLength, mirror, position);

                    i = lineCount;

                    break;
                }
            }

        }

        return 0.0f;
    }
}
