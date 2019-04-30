using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {


	public enum Maps{ expire, town, cs }

	

    [SerializeField]
    private SceneLoader sceneLoader;





	public void loadEinfach(){

		GameSettings.Difficulty = GameSettings.GameDifficulty.Easy;

        sceneLoader.LoadLevel("Level/country side");

	}

	public void loadMittel(){
		GameSettings.Difficulty = GameSettings.GameDifficulty.Medium;

        sceneLoader.LoadLevel("Level/country side");

	}

	public void loadSchwer(){
		GameSettings.Difficulty = GameSettings.GameDifficulty.Hard;

        sceneLoader.LoadLevel("Level/town");

      


	}

	public void selectMap(Maps map){
		switch (map) {
		case Maps.cs:
			SceneManager.LoadScene ("Level/country side", LoadSceneMode.Single);	
			break;
		case Maps.town:
			SceneManager.LoadScene ("Level/town", LoadSceneMode.Single);
			break;
		case Maps.expire:
			SceneManager.LoadScene ("Level/nonPlay/test_expire", LoadSceneMode.Single);
			break;
		}
	}

}
