using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

<<<<<<< HEAD
	public enum Maps{ expire, town, cs }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
=======
    [SerializeField]
    private SceneLoader sceneLoader;
>>>>>>> e38d2e7943fb1fb98c39ab18c5db4fdba01dd379

	public void loadEinfach(){

		GameSettings.Difficulty = GameSettings.GameDifficulty.Easy;
<<<<<<< HEAD

=======
        sceneLoader.LoadLevel("Level/country side");
>>>>>>> e38d2e7943fb1fb98c39ab18c5db4fdba01dd379

	}

	public void loadMittel(){
		GameSettings.Difficulty = GameSettings.GameDifficulty.Medium;
<<<<<<< HEAD

=======
        sceneLoader.LoadLevel("Level/town");
>>>>>>> e38d2e7943fb1fb98c39ab18c5db4fdba01dd379

	}

	public void loadSchwer(){
		GameSettings.Difficulty = GameSettings.GameDifficulty.Hard;
<<<<<<< HEAD
=======
        sceneLoader.LoadLevel("Level/town");
>>>>>>> e38d2e7943fb1fb98c39ab18c5db4fdba01dd379

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
