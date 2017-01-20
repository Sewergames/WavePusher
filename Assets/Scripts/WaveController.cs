using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof (LineRenderer))]
public class WaveController : MonoBehaviour {
	LineRenderer lineRen;


	// Use this for initialization
	void Start () {
		lineRen = getComponent<LineRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
