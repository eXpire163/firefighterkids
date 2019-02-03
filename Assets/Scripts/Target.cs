using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour {

	//TODO: add water/wettness to prevent from beeing light up again from nighboar

	public int health = 100;
	public int maxHealth = 100;
	public int firePower = 300;
	public int fireStartPower = 300;

	public float fireHopTime = 45f;
	public float fireHopDistance = 20f;

	public bool isBurning{
		get {return firePower > 0; }

	}


	public GameObject[] houselist;


	Transform cube;

	ParticleSystem partialSystem;


	[Header("Unity Stuff")]
	public Image healthImage;
	public Image fireImage;
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

	}
	
	// Update is called once per frame
	void Update () {
		//todo on medium or hard remove health
	}


	public void addWater(){
		
		firePower--;

		updateUI ();
		if (firePower <= 0) {
			partialSystem.Stop ();
			ParticleSystem.EmissionModule em=  partialSystem.emission;
			em.enabled = false;
			canvas.enabled = false;
			CancelInvoke ();
		}
	}


	void updateUI(){

		fireImage.fillAmount = Mathf.InverseLerp (0, fireStartPower, firePower);
			
	}

	public void startFire(int power=50){
  	
		firePower = power;
		fireStartPower = power;

		em.enabled = true;
		partialSystem.Play ();
	
		canvas.enabled = true;

		if (GameSettings.Difficulty >= GameSettings.GameDifficulty.Medium) {
			InvokeRepeating ("AddFireNearby", fireHopTime, fireHopTime);
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
