using System;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof (LineRenderer), typeof(EdgeCollider2D))]
public class WaveController : MonoBehaviour {
	private LineRenderer lineRen;
    private EdgeCollider2D coll;
    public float freq = 1.0f;
    public int waveCount = 10;
    public int linesPerWave = 10;
    public float amplitude = 1.0f;
    public float rotation = 0.0f;
    public float position = 0.0f;
    public GameObject cannon;
    public GameObject mirrors;
    public int maxBounces = 2;
    public bool draw = true;
    
    private List<Vector3> positions;
    private int bounceCount = 0;
    
	void Start () {
        lineRen = GetComponent<LineRenderer>();
        coll = GetComponent<EdgeCollider2D>();
    }
	
	void Update () {
        if (draw)
        {
            coll.enabled = true;
            RegenWave();
        }
        else
        {
            lineRen.numPositions = 0;
            coll.enabled = false;
        }
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

        List<Vector2> positions2D = new List<Vector2>(); 

        for (int i = 0; i < positions.Count; i++)
            positions2D.Add(positions[i]);

        coll.points = positions2D.ToArray();
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

            Vector3 vec = Camera.main.WorldToViewportPoint(pos);
            if (vec.x >= -0.1f && vec.y >= -0.1f && vec.x <= 1.1f && vec.y <= 1.1f)
                positions.Add(pos);

            for (int j = 0; j < mirrors.transform.childCount; j++)
            {
                GameObject mirror = mirrors.transform.GetChild(j).gameObject;
                BoxCollider2D col = mirror.GetComponent<BoxCollider2D>();

                if (col.OverlapPoint(pos) && reflectedMirror != mirror)
                {
                    Vector3 normal = Quaternion.Euler(0.0f, 0.0f, mirror.transform.eulerAngles.z + 90.0f) * Vector3.up;

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
