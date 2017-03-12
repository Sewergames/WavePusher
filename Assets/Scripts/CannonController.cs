using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject wave;

    public float position;
    public float amplitude;
    public float frequency;

    public int lineResolution;
    public int colliderResolution;
    public int waveCount;

    public float velocity;
    public float rotationSpeed;

    private LineRenderer lineRen;
    private EdgeCollider2D edgeColl;

	void Start () {
        lineRen = wave.GetComponent<LineRenderer>();
        edgeColl = wave.GetComponent<EdgeCollider2D>();
    }
	
	void FixedUpdate () {
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(wave.transform.parent.position);
        
        float rotDiff = CalcShortestRot(
            wave.transform.parent.rotation.eulerAngles.z,
            Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);

        wave.transform.parent.GetComponent<Rigidbody2D> ().angularVelocity = rotDiff * rotationSpeed;
        transform.rotation = wave.transform.parent.rotation;

        position -= velocity * (float)Math.PI * Time.deltaTime;

        RegenWave();
    }

    public void RegenWave()
    {
        List<Vector3> positions = new List<Vector3>();
        
        GenSemiWave(positions, 0.0f, transform.position, lineResolution);

        Vector3[] positionsArr = positions.ToArray();

        lineRen.numPositions = positionsArr.Length;
        lineRen.SetPositions(positionsArr);

        List<Vector3> collPositions = new List<Vector3>();

        GenSemiWave(collPositions, 0.0f, transform.position, colliderResolution);

        List<Vector2> collPositions2D = new List<Vector2>();

        for (int i = 0; i < collPositions.Count; i++)
            collPositions2D.Add(collPositions[i]);

        edgeColl.points = collPositions2D.ToArray();
    }


    float GenSemiWave(List<Vector3> positions, float rotation, Vector2 start, int resolution)
    {
        int lineCount = waveCount * resolution;
        float lineLength = 1 / frequency / resolution;
        
        for (int i = 0; i <= lineCount; i++)
        {
            Vector3 pos = new Vector3(
                i * lineLength,
                (float)Math.Sin((float)i / (float)resolution * Math.PI * 2.0f + position) * amplitude,
                -1.0f);

            pos = Quaternion.Euler(0, 0, rotation) * pos;
            pos.x += start.x;
            pos.y += start.y;

            Vector3 vec1 = Camera.main.WorldToViewportPoint(pos);
            if (vec1.x >= -0.1f && vec1.y >= -0.1f && vec1.x <= 1.1f && vec1.y <= 1.1f)
                positions.Add(pos);

            /*
            for (int j = 0; j < mirrors.transform.childCount; j++)
            {
                GameObject mirror = mirrors.transform.GetChild(j).gameObject;
                BoxCollider2D col = mirror.GetComponent<BoxCollider2D>();

                if (col.OverlapPoint(pos) && reflectedMirror != mirror)
                {
                    Vector3 straightPos;
                    Vector3 direction = Quaternion.Euler(0.0f, 0.0f, rot) * Vector3.right;
                    RaycastHit2D hit = Physics2D.Raycast(start + direction * 0.1f, direction);

                    if (hit.collider != null)
                    {
                        straightPos = hit.point;
                        Vector3 normal = Quaternion.Euler(0.0f, 0.0f, mirror.transform.eulerAngles.z + 90.0f) * Vector3.down;

                        Vector3 reflection = Vector3.Reflect((straightPos - start).normalized, normal.normalized);

                        float angle = Quaternion.FromToRotation(Vector3.right, reflection.normalized).eulerAngles.z;

                        if (bounceCount <= maxBounces)
                            GenSemiWave(straightPos, angle, lineLength, mirror, position);

                        i = lineCount;
                    }

                    break;
                }
            }

            for (int j = 0; j < walls.transform.childCount; j++)
            {
                GameObject wall = walls.transform.GetChild(j).gameObject;
                BoxCollider2D col = wall.GetComponent<BoxCollider2D>();

                if (col.OverlapPoint(pos))
                {
                    i = lineCount;
                    break;
                }
            }
            */

        }

        return 0.0f;
    }

    float map(float s, float a1, float a2, float b1, float b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }

    float CalcShortestRot(float from, float to)
    {
        if (from < 0)
        {
            from += 360;
        }

        if (to < 0)
        {
            to += 360;
        }
        
        if (from == to ||
           from == 0 && to == 360 ||
           from == 360 && to == 0)
        {
            return 0;
        }
        
        float left = (360 - from) + to;
        float right = from - to;

        if (from < to)
        {
            if (to > 0)
            {
                left = to - from;
                right = (360 - to) + from;
            }
            else
            {
                left = (360 - to) + from;
                right = to - from;
            }
        }
        
        return ((left <= right) ? left : (right * -1));
    }
}
