using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    [SerializeField]
    private SceneLoader sceneLoader;

	public void loadEinfach(){

		GameSettings.Difficulty = GameSettings.GameDifficulty.Easy;
        sceneLoader.LoadLevel("Level/country side");

	}

	public void loadMittel(){
		GameSettings.Difficulty = GameSettings.GameDifficulty.Medium;
        sceneLoader.LoadLevel("Level/town");

	}

	public void loadSchwer(){
		GameSettings.Difficulty = GameSettings.GameDifficulty.Hard;
        sceneLoader.LoadLevel("Level/town");

	}

}
