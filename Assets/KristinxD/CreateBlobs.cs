/* 
 * Name: Kristin Agcaoili 
 * Purpose: Instantiates multiple blobs 
 * File Name: CreateBlobs
 * Date: 3-7-15
 * Sources: Connor Smith 
 */ 


using UnityEngine;
using System.Collections;

public class CreateBlobs : MonoBehaviour {

	public Object blob; //create object for multiple blob
	public int minRange; //minimum range for distance to instantiate
	public int maxRange; //maximum range for dist to instantiate
	public int amount; //amount of blobs to instantiate
	public GameObject player; //store player gameobject 

	// Use this for initialization
	void Start () {
		
		StartCoroutine(blobInstantiate()); //call coroutine to instantiate 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	/* 
	 * Name: blobInstantiate
	 * Description: Instantiates blobs and puts them in random location 
	 */
	IEnumerator blobInstantiate () { 
	
		//while we have enough blobs, create new blobs in random locations in
		//specific range 
		for (int i=0; i < amount; i++) {
			
			//store new random location based on players position
			Vector3 location = new Vector3(player.transform.position.x + Random.Range(minRange,maxRange), 
				player.transform.position.y + Random.Range(minRange, maxRange), 
				player.transform.position.z + Random.Range(minRange, maxRange)); 
			
			//instantiates blob at that location with random rotations 
			Instantiate(blob, location, new Quaternion(Random.Range(0, 360), Random.Range(0, 360), 
				Random.Range(0, 360), 0)); 
			yield return null; 
		}
	
	}
}
