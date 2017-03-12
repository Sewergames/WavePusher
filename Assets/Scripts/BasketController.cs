using System;
using System.Reflection;
using UnityEngine;

public class BasketController : MonoBehaviour {
    public string behaviourName;
    public GameObject cannonContr;
    public string[] behavArgs;

    private BasketBehaviour behaviour;

	void Start () {
        behaviour = Assembly.GetExecutingAssembly().CreateInstance(behaviourName) as BasketBehaviour;
    }
	
	void Update () {
	}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Apple")
            behaviour.Behave(cannonContr.GetComponent<CannonController> (), behavArgs);
    }
}
