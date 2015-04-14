using UnityEngine;
using System.Collections;

public class BeachPortal : MonoBehaviour {
	
	bool looking = false; //checks if the object is being looked at
	
	//if possible, drag Blink System through Inspector (So that it doesn't have to find at runtime)
	public GameObject blinkSystem;
	
	/* If you will be blinking to a new location:
	 */ 
	public GameObject destinationObject = null; // An empty game object you want to move to
	public GameObject directionObject = null; // An object that the camera will be facing when the eyes open
	/* 
	 * Note: If you will be blinking to new locations multiple times, be sure to specify
	 *       more public GameObjects and call them in your code later (See "Activate" method)
	 */
	
	
	// Use this for initialization
	void Start () 
	{
		//sets up the Blink System if it wasn't dragged in the Inspector. Please drag in the Inspector.
		if (!blinkSystem) {
			blinkSystem = GameObject.Find ("Blink System");
		}
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Will execute while object is being looked at
		if (looking) 
		{
			/*
			 * Your Code Here
			 */
		}
		
		// Will execute while object is not being looked at
		else if (!looking) 
		{
			/*
			 * Your Code Here
			 */
		}
		
		/*
		 * Any other code that will execute regardless of looking
		 */
		
		looking = false; //must be on LAST line of Update!
	}
	
	// Checks if this object is being looked at
	void Activate()
	{
		looking = true;

		  blinkSystem.SendMessage("NextScene", 2);
		
		/* To advance to the next location: 
          * 
          * //Makes sure that you have placed destination and direction objects
          * if (destinationObject && directionObject) 
          * {
          * 	//calls the proper methods inside the blink script
	  	  * 	blinkSystem.GetComponent <BlinkScript>().NextLocation (destinationObject, directionObject);
	  	  * 
	  	  * 	//makes sure that the movement only occurs once
		  * 	destinationObject = null;
	      * 	directionObject = null;
		  * }
		  * 
		  * Note: To move multiple times within a scene, simply add more public GameObjects and call them in the same
		  * way that they are called above.
		  * 
          */
	}
}

