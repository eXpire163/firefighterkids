using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkLights : MonoBehaviour {

	public Light[] lights;
	bool activeSide = true;

	public bool active = true;

	void Start(){
		InvokeRepeating ("Blink", 0, 0.4f);

	}

	void Update(){
	
		if (Input.GetKeyDown (KeyCode.F)) {
		
			active = !active;
		
		}
	
	}

	void Blink()
	{
		if (active) {
			activeSide = !activeSide;
			for (int i = 0; i < lights.Length; i++) {
				if (i % 2==0) {
					lights [i].enabled = activeSide;
				} else {
					lights [i].enabled = !activeSide;
				}
			}
		} else {
			for (int i = 0; i < lights.Length; i++) {
				
				lights [i].enabled = false;

			}
		
		}


	}
}
