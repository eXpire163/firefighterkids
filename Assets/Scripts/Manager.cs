using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

	public enum GameDifficulty{Easy = 0, Medium = 1, Hard = 2};

	public static GameDifficulty Difficulty = GameDifficulty.Easy;

	List<Target> fire;
	GameObject[] targets;

	// Use this for initialization
	void Start () {
		
		fire = new List<Target> ();


		targets = GameObject.FindGameObjectsWithTag ("Target");





	}
	
	// Update is called once per frame
	void LateUpdate () {

		if (fire.Count == 0) {
			Target newFire = targets [Random.Range (0, targets.Length)].GetComponent<Target> ();
			fire.Add(newFire);
			newFire.startFire (Random.Range (30, 100));
			
		}

		foreach (Target target in fire) {
		
			if (!target.isBurning) {
				fire.Remove (target);			
			}
			break;
		}

	}
}
