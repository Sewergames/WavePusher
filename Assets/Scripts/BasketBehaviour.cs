using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasketBehaviour : MonoBehaviour {

    abstract public void Behave(CannonController cannonContr, params string[] values);
	
}
