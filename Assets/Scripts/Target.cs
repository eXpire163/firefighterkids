using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour {

	//TODO: add water/wettness to prevent from beeing light up again from nighboar

	public float health = 100;
	public int maxHealth = 100;
	public int firePower = 300;
	public int fireStartPower = 300;

	public float waterPower = 0;
	public int maxWaterPower = 50;

	public float fireHopTime = 45f;
	public float fireHopDistance = 20f;

	public float dryFactor = 0.2f;

	public bool isBurning{
		get {return firePower > 0; }

	}


	public GameObject[] houselist;


	Transform cube;

	ParticleSystem partialSystem;


	[Header("Unity Stuff")]
	public Image healthImage;
	public Image fireImage;
	public Image waterImage;
	public Canvas canvas;

	ParticleSystem.EmissionModule em;


	// Use this for initialization
	void Start () {


		//add new house
		GameObject newHouse = Instantiate (houselist [Random.Range (0, houselist.Length)], this.transform);
		newHouse.transform.SetParent (this.transform);
		newHouse.transform.localScale = Vector3.one * 2;
		newHouse.transform.position += new Vector3(0,-1.63f,0);

		//remove template box
		cube = transform.Find ("Cube");
		Destroy (cube.gameObject);

		//disable fire on start
		partialSystem = transform.Find ("Fire").GetComponent<ParticleSystem> ();
		em =  partialSystem.emission;
		em.enabled = false;
		partialSystem.Stop ();

		//testing option to start manualy
		if (fireStartPower > 10) {
		
			startFire (fireStartPower);
		}

		updateUI ();

	}
	
	// Update is called once per frame
	void Update () {
		//todo on medium or hard remove health

		if (waterPower > 0) {
			waterPower -= Time.deltaTime * dryFactor;

		}

		updateUI ();

	}


	public void addWater(int waterHitPower = 1){
		
		firePower-=waterHitPower;


		updateUI ();

		if (firePower <= 0) {

			waterPower += waterHitPower;


			if (partialSystem.isEmitting) // only on the first after fire got below 0
				ScoreSystem.firesKilled++;

			partialSystem.Stop ();
			ParticleSystem.EmissionModule em=  partialSystem.emission;
			em.enabled = false;
			CancelInvoke ();

		}
	}


	void updateUI(){

		fireImage.fillAmount = Mathf.InverseLerp (0, fireStartPower, firePower);
		healthImage.fillAmount = Mathf.InverseLerp (0, maxHealth, health);
		waterImage.fillAmount = Mathf.InverseLerp (0, maxWaterPower, waterPower);



		if (firePower <= 0 && waterPower <=0) {
			canvas.enabled = false;
		}

			
	}

	public void startFire(int power=50){
  	
		if (waterPower > 0) {
			waterPower -= 15;
					
		} else {
			waterPower = 0;
			firePower = power;
			fireStartPower = power;

			em.enabled = true;
			partialSystem.Play ();
	
			canvas.enabled = true;

			if (GameSettings.Difficulty >= GameSettings.GameDifficulty.Medium) {
				InvokeRepeating ("AddFireNearby", fireHopTime, fireHopTime);
			}

		}



	}

	public void AddFireNearby(){
	
	
		GameObject[] targets = GameObject.FindGameObjectsWithTag ("Target");

		foreach (GameObject go in targets) {
			Target target = go.GetComponent<Target> ();
			if(Vector3.Distance(target.transform.position, this.transform.position) < fireHopDistance){

				if (!target.isBurning) {
					target.startFire ();
					break;
				}
			}
		
		}


	
	}



}
