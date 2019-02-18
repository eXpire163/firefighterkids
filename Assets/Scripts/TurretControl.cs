using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControl : MonoBehaviour {

	public GameObject basePlate;
	public Transform gunPoint;
	public GameObject gun;

	public ParticleSystem partialSystem;


    //read imputs
    bool waterToggle = false;
    float turretHorizontal = 0f, turretVertical = 0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        waterToggle = Input.GetButtonDown("Jump");
        turretHorizontal = Input.GetAxis("TurretHorizontal");
        turretVertical = Input.GetAxis("TurretVertical");

        if (waterToggle) {

			ParticleSystem.EmissionModule em =  partialSystem.emission;
		
			em.enabled = !em.enabled;
		
		}



        
		basePlate.transform.Rotate (new Vector3 (0,turretHorizontal,0));

		gun.transform.RotateAround (gunPoint.transform.position, Vector3.forward, turretVertical);

		

		//
	}
    
}
