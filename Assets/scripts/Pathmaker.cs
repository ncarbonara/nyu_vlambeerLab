using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MAZE PROC GEN LAB
// all students: complete steps 1-6, as listed in this file
// optional: if you have extra time, complete the "extra tasks" to do at the very bottom

// STEP 1: ======================================================================================
// put this script on a Sphere... it will move around, and drop a path of floor tiles behind it

public class Pathmaker : MonoBehaviour
{

	// STEP 2: ============================================================================================
	// translate the pseudocode below

	//	DECLARE CLASS MEMBER VARIABLES:
	//	Declare a private integer called counter that starts at 0; 		// counter var will track how many floor tiles I've instantiated
	//	Declare a public Transform called floorPrefab, assign the prefab in inspector;
	//	Declare a public Transform called pathmakerSpherePrefab, assign the prefab in inspector; 		// you'll have to make a "pathmakerSphere" prefab later


	//Counts the number of total tiles in the scene across all instances of the pathmaker sphere
	public static int counter = 0;

	//The floor tile prefab
	public GameObject floorPrefab;

	//The prefab for the object that creates additional floor tiles
	public GameObject pathmakerSpherePrefab;

	//An RGB value for the color paths can have
	Vector3 pathColor;

	void Start ()
	{

		//Randomizes the path color at the start
		pathColor = new Vector3 (Random.Range (0, 256), Random.Range (0, 256), Random.Range (0, 256));
		//pathColor = Random.ColorHSV();
	}

	void Update ()
	{
//			If counter is less than 50, then:
//			Generate a random number from 0.0f to 1.0f;
//			If random number is less than 0.25f, then rotate myself 90 degrees;
//				... Else if number is 0.25f-0.5f, then rotate myself -90 degrees;
//				... Else if number is 0.99f-1.0f, then instantiate a pathmakerSpherePrefab clone at my current position;
//			// end elseIf

//			Instantiate a floorPrefab clone at current position;
//			Move forward ("forward" in local space, relative to the direction I'm facing) by 5 units;
//			Increment counter;
//	Else:
//			Destroy my game object; 		// self destruct if I've made enough tiles already

		if (counter < 500) {

			//Creates a random value to help determine what the pathmaker should do next
			float randVal = Random.Range (0f, 1f);

			//Turns the pathmaker sphere in one direction
			if (randVal <= .25f) {
				transform.Rotate (new Vector3 (0, 45, 0));

			//Turns it in the other direction
			} else if (randVal > .25f
			           && randVal <= .5f) {
				transform.Rotate (new Vector3 (0, -45, 0));

			//Creates a new pathmaker sphere 
			} else if (randVal > .9f
			           && randVal <= 1f) {

				GameObject pathmakerSphereClone = (GameObject)Instantiate (pathmakerSpherePrefab, transform.position, Quaternion.Euler (0f, 0f, 0f));

				//Creates a random RGB value to be the color associated with this path
				//pathColor = new Vector3 (Random.Range (0, 256), Random.Range (0, 256), Random.Range (0, 256));
			}

			//Determines how long the next hallway should be
			int hallLengthInTiles = Random.Range (5, 7);
			int tilesCurrentlyInHall = 0;

			//Starts a loop wherein a series of tiles, a.k.a. a "hall," are produced in a straight line 
			while (tilesCurrentlyInHall < hallLengthInTiles
				&& counter < 500) {
					
					//Creates a new floor tile
					GameObject floorClone = (GameObject)Instantiate (floorPrefab, transform.position, Quaternion.Euler (0f, 0f, 0f));

					//Gives it a groovy color
					floorClone.GetComponent<MeshRenderer> ().material.color = new Color (pathColor.x, pathColor.y, pathColor.z, 1);

					//Moves the pathmaker sphere forward
					transform.Translate (transform.forward * 5f);

					//Updates the number of tiles currently in the given hall
					tilesCurrentlyInHall++;

					counter++;
					Debug.Log (counter);
			}

		//Tells the pathmaker sphere to self-destruct, ensuring that it doesn't create any more paths
		} else {
			GameObject.Destroy (this.gameObject);
		}
	}

}
 // end of class scope

// MORE STEPS BELOW!!!........




// STEP 3: =====================================================================================
// implement, test, and stabilize the system

//	IMPLEMENT AND TEST:
//	- save your scene!!! the code could potentially be infinite / exponential, and crash Unity
//	- put Pathmaker.cs on a sphere, configure all the prefabs in the Inspector, and test it to make sure it works
//	STABILIZE:
//	- code it so that all the Pathmakers can only spawn a grand total of 500 tiles in the entire world; how would you do that?
//	- (hint: declare a "public static int" and have each Pathmaker check this "globalTileCount", somewhere in your code? if there are already enough tiles, then maybe the Pathmaker could Destroy my game object



// STEP 4: ======================================================================================
// tune your values...

// a. how long should a pathmaker live? etc.
// b. how would you tune the probabilities to generate lots of long hallways? does it work?
// c. tweak all the probabilities that you want... what % chance is there for a pathmaker to make a pathmaker? is that too high or too low?



// STEP 5: ===================================================================================
// maybe randomize it even more?

// - randomize 2 more variables in Pathmaker.cs for each different Pathmaker... you would do this in Start()
// - maybe randomize each pathmaker's lifetime? maybe randomize the probability it will turn right? etc. if there's any number in your code, you can randomize it if you move it into a variable



// STEP 6:  =====================================================================================
// art pass, usability pass

// - move the game camera to a position high in the world, and then point it down, so we can see your world get generated
// - CHANGE THE DEFAULT UNITY COLORS, PLEASE, I'M BEGGING YOU
// - add more detail to your original floorTile placeholder -- and let it randomly pick one of 3 different floorTile models, etc. so for example, it could randomly pick a "normal" floor tile, or a cactus, or a rock, or a skull
//		- MODEL 3 DIFFERENT TILES IN MAYA! DON'T STOP USING MAYA OR YOU'LL FORGET IT ALL
//		- add a simple in-game restart button; let us press [R] to reload the scene and see a new level generation
// - with Text UI, name your proc generation system ("AwesomeGen", "RobertGen", etc.) and display Text UI that tells us we can press [R]



// OPTIONAL EXTRA TASKS TO DO, IF YOU WANT: ===================================================

// DYNAMIC CAMERA:
// position the camera to center itself based on your generated world...
// 1. keep a list of all your spawned tiles
// 2. then calculate the average position of all of them (use a for() loop to go through the whole list)
// 3. then move your camera to that averaged center and make sure fieldOfView is wide enough?

// BETTER UI:
// learn how to use UI Sliders (https://unity3d.com/learn/tutorials/topics/user-interface-ui/ui-slider)
// let us tweak various parameters and settings of our tech demo
// let us click a UI Button to reload the scene, so we don't even need the keyboard anymore!

// WALL GENERATION
// add a "wall pass" to your proc gen after it generates all the floors
// 1. raycast downwards around each floor tile (that'd be 8 raycasts per floor tile, in a square "ring" around each tile?)
// 2. if the raycast "fails" that means there's empty void there, so then instantiate a Wall tile prefab
// 3. ... repeat until walls surround your entire floorplan
// (technically, you will end up raycasting the same spot over and over... but the "proper" way to do this would involve keeping more lists and arrays to track all this data)