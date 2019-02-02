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

		SceneManager.LoadScene("Level/base", LoadSceneMode.Single);

	}

	public void loadMittel(){

		SceneManager.LoadScene("Level/base", LoadSceneMode.Single);

	}

	public void loadSchwer(){

		SceneManager.LoadScene("Level/base", LoadSceneMode.Single);

	}

}
