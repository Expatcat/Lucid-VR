using UnityEngine;
using System.Collections;

public class PlaceText : MonoBehaviour {

	bool oculus = false;
	public int statusTextX = 0;
	public int statusTextY = 5;
	public int statusTextZ = 15;

	// Use this for initialization
	void Start () {
		if (Camera.main == null) { //checks for Oculus
			oculus = true;
		}

		if (oculus) {
			//places text under center eye anchor if oculus
			this.transform.parent = GameObject.Find ("CenterEyeAnchor").transform;
		}
		else { 
			//places text under main camera otherwise
			this.transform.parent = Camera.main.transform;
		}

		//places text at preferred location in front of camera
		transform.localPosition = new Vector3(statusTextX, statusTextY, statusTextZ);
		transform.localRotation = new Quaternion (0, 0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
