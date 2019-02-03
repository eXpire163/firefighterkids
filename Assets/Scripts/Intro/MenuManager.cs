using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void loadEinfach(){

		GameSettings.Difficulty = GameSettings.GameDifficulty.Easy;

		SceneManager.LoadScene("Level/country side", LoadSceneMode.Single);

	}

	public void loadMittel(){
		GameSettings.Difficulty = GameSettings.GameDifficulty.Medium;
		SceneManager.LoadScene("Level/town", LoadSceneMode.Single);

	}

	public void loadSchwer(){
		GameSettings.Difficulty = GameSettings.GameDifficulty.Hard;
		SceneManager.LoadScene("Level/town", LoadSceneMode.Single);

	}

}
