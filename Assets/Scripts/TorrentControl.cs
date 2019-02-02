using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorrentControl : MonoBehaviour {

	public GameObject basePlate;
	public Transform gunPoint;
	public GameObject gun;

	public ParticleSystem partialSystem;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Space)) {

			ParticleSystem.EmissionModule em =  partialSystem.emission;
		
			em.enabled = !em.enabled;
		
		}

		if(Input.GetKey(KeyCode.J)){

			basePlate.transform.Rotate (new Vector3 (0,-1,0));

		}
		if(Input.GetKey(KeyCode.L)){

			basePlate.transform.Rotate (new Vector3 (0,1,0));

		}
		if(Input.GetKey(KeyCode.I)){

			gun.transform.RotateAround (gunPoint.transform.position, Vector3.forward, 0.5f);

		}
		if(Input.GetKey(KeyCode.K)){

			gun.transform.RotateAround (gunPoint.transform.position, Vector3.forward, -0.5f);

		}


		//
	}
}
