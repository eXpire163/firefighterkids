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

		SceneManager.LoadScene("Level/base", LoadSceneMode.Single);

	}

	public void loadMittel(){
		GameSettings.Difficulty = GameSettings.GameDifficulty.Medium;
		SceneManager.LoadScene("Level/base", LoadSceneMode.Single);

	}

	public void loadSchwer(){
		GameSettings.Difficulty = GameSettings.GameDifficulty.Hard;
		SceneManager.LoadScene("Level/base", LoadSceneMode.Single);

	}

}
