using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterJet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnParticleCollision(GameObject other){
	
	
		Target target = other.GetComponent<Target> ();

		if (target == null) {
		
			target = other.GetComponentInParent<Target> ();
		}


		if (target != null) {
		
			target.addWater ();
		//	Debug.Log ("target hit");
		} else {

			//Debug.Log ("hit: " + other.name + " " + other.GetType ());
		}
	}
}
