using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Let's us interact with scenes
using UnityEngine.SceneManagement;

public class ReloadManager : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//Reloads the game scene with the press of the 'R' key
		if (Input.GetKey(KeyCode.R)) {
			SceneManager.LoadScene ("Scene");
		}
	}
}
