/* 
 * User Name: Kristin Agcaoili 
 * Name of File: ChangeSkyboxVer5
 * Project: Dreamscape in Hack AZ
 * Date: 3-7-15
 * Sources: Connor Smith, Anish Kannan, Nick Crow 
 */ 

using UnityEngine;
using System.Collections;

public class ChangeSkyboxVer5 : MonoBehaviour {

	public Material theSkybox; //skybox to change the color of
	public float duration = 15.0F; //premade duration 
	
	//ints to call colors from array 
	int firstRandomInt;
	int secondRandomInt;
	
	float t; //store time for lerp duration 
	Color[] arrayOfColors; //initialize array of colors 
	bool colorStart = false; //check if changeColor is running

	/*
	 * Name: Start
	 * Purpose: Initializes variables and array
	 */ 
	void Start () {
		
		//gets two random integers from 0 to 8 exclusive
		firstRandomInt = getRandomInt(); 
		
		//sets secondRandomInt to firstRandomInt
		secondRandomInt = firstRandomInt;
		
		//assign arrayOfColors to static variable colors
		arrayOfColors = new Color[8]; 
		arrayOfColors[0] = Color.red; 
		arrayOfColors[1] = Color.green; 
		arrayOfColors[2] = Color.blue; 
		arrayOfColors[3] = Color.cyan; 
		arrayOfColors[4] = Color.magenta; 
		arrayOfColors[5] = Color.white; 
		arrayOfColors[6] = Color.grey; 
		arrayOfColors[7] = Color.yellow; 
	}
	
	/* 
	 * Name: Update
	 * Purpose: Calls Coroutine to change color 
	 */ 
	void Update () {

		//Checks if coroutine is already running. Ensures it runs once.
        if (!colorStart) { //if color start is false 
        	StartCoroutine(changeColor()); //calls coroutine to change color
		}

	} 
		
	/* 
	 * Name: getRandomInt
	 * Purpose: Gets random integer between 0 and 8 exclusive
	 */ 
	int getRandomInt() { 
		return Random.Range(0,8); //method to get range between two numbers 
	}
	
	/* 
	 * Name: changeColor 
	 * Purpose: Changes between two random colors 
	 */ 
	IEnumerator changeColor () {
			
		colorStart = true; //ensures that changeColor doesn't run again
		
		//check if both numbers the same, then change second number 
		while (firstRandomInt == secondRandomInt) {
			secondRandomInt = getRandomInt(); 
		}
			
		//lerps between two colors while changing duration 
		for (t = 0.0f; t < duration; t+= Time.deltaTime) {
			Color lerpedColor = Color.Lerp(arrayOfColors[firstRandomInt], arrayOfColors[secondRandomInt], t/ duration);
			theSkybox.SetColor("_Tint", lerpedColor); //set skybox to color
			yield return null; //continues run through coroutine til exit for 
		} 
			
		firstRandomInt = secondRandomInt; //ensure transition to new color
		colorStart = false; //allow coroutine to be called in update again
	}
	
}
