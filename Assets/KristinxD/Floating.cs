/* 
 * Name: Kristin Agcaoili 
 * File: Floating
 * Date: 3-7-15
 * Description: Picks a random location for blob to go 
 * Sources: Connor Smith 
 */ 


using UnityEngine;
using System.Collections;

public class Floating : MonoBehaviour {

	
	public string playerName; //to store name of player
	public float speed; //to store speed of floating blobs
	public int minVal; //minimum range for distance for floating
	public int maxVal; //maximum range for distance for floating
	
	GameObject player; //store player for ranges of floating
	bool check = false; //to check if in coroutine or not
	float i; //to store time lerp counter
	
	//set vector locations 
	Vector3 playerLoc;
	Vector3 startLocation;
	Vector3 destination;
	Vector3 testVector = new Vector3(0,0,0); //sets testVector to 0's

	// Use this for initialization
	void Start () {
		
		player = GameObject.Find(playerName); //sets player variable 
		startLocation = transform.position; //sets current location to start loc
		playerLoc = player.transform.position; //sets player location
		destination = testVector; //sets desintation of float to 0

	}
	
	// Update is called once per frame
	void Update () {
		
		//run coroutine ONLY if check is FALSE 
		if (!check) { 
		
			StartCoroutine(blobFloat()); //call blobFloat coroutine 
		}
		
	
	}
	
	/* 
	 * Name: blobFloat
	 * Description: Coroutine that creates new random destination in relation to 
	 *              the player and uses lerp so the blob can move toward that 
	 *              destination.
	 */ 
	IEnumerator blobFloat() { 
	
		check = true; //ensures coroutine doesn't run in update again
		
		//checks if its first time destination if being set
		if (destination == testVector) {
			
			//creates new random x, y, z location 
			destination = new Vector3(playerLoc.x + Random.Range(minVal, maxVal), 
					playerLoc.y + Random.Range(minVal, maxVal), 
					playerLoc.z + Random.Range(minVal, maxVal));
		}
		
		//uses lerp to change location in duration of time
		for (i=0.0f; i<speed; i+=Time.deltaTime ) {

			Vector3 location = Vector3.Lerp(startLocation, destination, i/speed ); 
			this.transform.position = location; //sets position to new location 
			yield return null; 
			
		}
		
		destination = testVector; //resets the destination to start again
		startLocation = transform.position; //makes position the new start 
		check = false; //ensures coroutine runs again in update 
	
	}
}
