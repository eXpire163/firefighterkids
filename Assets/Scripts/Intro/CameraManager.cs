using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraManager : MonoBehaviour {


	public GameObject camera1;
	public GameObject camera2;
	public GameObject camera3;

	public Transform end1;
	public Transform end2;
	public Transform end3;

	public GameObject truck;
	public Transform truckpos;


	// Use this for initialization
	void Start () {



		
		StartCoroutine (Step1() );

		Target target = GameObject.Find ("IntroTarget").GetComponent<Target> ();
		target.startFire (200);

	}

	private IEnumerator Step1(){
		
	
		yield return StartCoroutine( MoveOverSeconds (camera1, end1.position, 5f));



		yield return StartCoroutine (MoveOverSeconds (camera2, end2.position, 5f));

		truck.transform.position = truckpos.position;

		yield return StartCoroutine (MoveOverSeconds (camera3, end3.position, 5f));

		SceneManager.LoadScene("Level/nonPlay/menu", LoadSceneMode.Single);
	}
	



	private IEnumerator MoveOverSpeed (GameObject objectToMove, Vector3 end, float speed){
		objectToMove.GetComponent<Camera> ().enabled = true;
		// speed should be 1 unit per second
		while (objectToMove.transform.position != end)
		{
			objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, end, speed * Time.deltaTime);
			yield return new WaitForEndOfFrame ();
		}
		objectToMove.GetComponent<Camera> ().enabled = false;
	}
	private IEnumerator MoveOverSeconds (GameObject objectToMove, Vector3 end, float seconds)
	{

		objectToMove.GetComponent<Camera> ().enabled = true;
		float elapsedTime = 0;
		Vector3 startingPos = objectToMove.transform.position;
		while (elapsedTime < seconds)
		{
			objectToMove.transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
			elapsedTime += Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
		objectToMove.transform.position = end;

		objectToMove.GetComponent<Camera> ().enabled = false;
	}




}
