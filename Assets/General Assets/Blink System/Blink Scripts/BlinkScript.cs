using UnityEngine;
using System.Collections;
//using UnityEditor;

public class BlinkScript : MonoBehaviour {

	private Animator animator;
	bool oculus;

	public int sceneLength;

	private static float warningTime = 5.75f; //seconds the warning message is displayed
	private static int animationTime = 2; //time the blink animation takes
	
	private static Vector3 emptyVector; //self explanator empty vector variable

	public bool eyesOpen = false; //variable to be called from gaze system

	//The main OVR Camera. Add in Inspector, preferably. (Either OVRCameraRig or OVRPlayerController)
	public GameObject playerCamera;

	void Awake() 
	{

		//if the loaded level is the first level
		if (Camera.main == null && Application.loadedLevel == 0) {

			this.GetComponent<Animator> ().StartPlayback (); //keeps the eyes from opening automatically
           
			StartCoroutine(FirstOpenEyes());

			eyesOpen = true; //sets boolean to closed eyes

		}

	}
	
	void Start () 
	{
	    if (Camera.main != null) //checks for Oculus
		{
			this.gameObject.SetActive (false); //disables blink system if Oculus is not being used
		} 

		else 
		{
			emptyVector = new Vector3(0,0,0); //sets up the empty vector


			//checks if the user set the player camera. 
			if (!playerCamera) {
			  playerCamera = GameObject.Find("OVRCameraRig");
			}

			//the animator component
			animator = this.GetComponent<Animator> ();

			//applies the animation to the position of the Oculus
			this.transform.parent = GameObject.Find ("OVRCameraRig/CenterEyeAnchor").transform;
			transform.localPosition = new Vector3 (0, 0, 1);
			transform.localRotation = new Quaternion(0,0,0,0);
		}

		//only occurs on very first level:
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	void OnLevelWasLoaded(int level)
	{
		//opens eyes at the start of every level
		if (level != 0) {
			StartCoroutine (sceneTimer());
			animator = this.GetComponent<Animator> ();
			animator.SetBool ("Open", true);
			eyesOpen = true;
		}
	}

	//method to be called from an Object that will move the player. Pass in a destination object and a direction to be facing. 
	public void NextLocation(GameObject destination, GameObject direction) {

		//if a destination and direction have been specified for movement
		if (destination && direction) {

		  //performs the transition
		  StartCoroutine(BlinkTransition(0, false, destination.transform.position, direction.transform.position));
		}
	}
	
	public void NextScene(int nextLevel) {
		//initializes the transition process by calling a Coroutine
		StartCoroutine(BlinkTransition (nextLevel, true, emptyVector, emptyVector));
	}

	/* Performs the blink transition
	 * newScene: True if transition is to new scene, false if transition is to new location
	 * destination: destination object passed from above methods, as a Vector3
	 * direction: direction object passed from above methods, as a Vector3
	 */
	IEnumerator BlinkTransition(int nextScene, bool newScene, Vector3 destination, Vector3 direction) {

		//closes the eyes
		animator.SetBool ("Open", false);
		eyesOpen = false;

		//waits for eyes to finish closing
		yield return new WaitForSeconds (animationTime);

		//if the user wanted to transition to a new scene
		if (newScene) {
			//changes scene
			Application.LoadLevel (nextScene);
		}

		//if the user wanted to transition to a new location
		else {
		    //moves the player to specified destination
			playerCamera.transform.position = destination;

			//faces the player toward the direction object
			playerCamera.transform.LookAt(direction);

			//opens the eyes
			animator.SetBool ("Open", true);
			eyesOpen = true;
		}
	}

	//handles opening eyes at the very start
	IEnumerator FirstOpenEyes() {

		//waits for the normal warning message time to pass
		yield return new WaitForSeconds (warningTime);

		//waits for user input
		//yield return StartCoroutine (WaitForKeyDown ());

		//opens the eyes
		animator.StopPlayback ();
		animator.SetBool ("Open", true);
		eyesOpen = true;
	}

	//this method will wait for the user to press any key
	IEnumerator WaitForKeyDown() 
	{
		while (!Input.anyKey) 
		{
			yield return null;
		}
	}

	IEnumerator sceneTimer() {
		yield return new WaitForSeconds (60);

		animator.SetBool ("Open", false);
		StartCoroutine (sceneTransition ());

	}

	IEnumerator sceneTransition() {
		yield return new WaitForSeconds(animationTime);
		Application.LoadLevel (0);
	}
}
