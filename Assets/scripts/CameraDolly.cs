using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDolly : MonoBehaviour {

	public float cameraMoveSpeed;
	
	// Update is called once per frame
	void Update () {

		//Checks the current camera position
		Vector3 cameraPosition = this.transform.position;

		//Checks to see if the camera is being zoomed in or out
		if (Input.GetKey (KeyCode.E)) {
			cameraPosition.y -= cameraMoveSpeed;
		}

		if (Input.GetKey (KeyCode.Q)) {
			cameraPosition.y += cameraMoveSpeed;
		}

		//Checks to see if the camera is being moved left, right, up, or down
		if (Input.GetKey (KeyCode.A)) {
			cameraPosition.z += cameraMoveSpeed;
		}

		if (Input.GetKey (KeyCode.D)) {
			cameraPosition.z -= cameraMoveSpeed;
		}

		if (Input.GetKey (KeyCode.W)) {
			cameraPosition.x += cameraMoveSpeed;
		}

		if (Input.GetKey (KeyCode.S)) {
			cameraPosition.x -= cameraMoveSpeed;
		}

		//Applies all the translations made in the last frame
		this.transform.position = cameraPosition;
	}
}
