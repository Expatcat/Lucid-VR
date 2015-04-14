using UnityEngine;
using System.Collections;

public class CursorLocation : MonoBehaviour {

	public int distance = 5; //affects distance of 3D object from cam
	bool oculus; //is Oculus being used?

	// Use this for initialization
	void Start () {
		if (Camera.main == null) { //checks for Oculus
			oculus = true;
		}

		if (oculus) {
		  //moves the cursor in front of the Oculus cameras
     	  this.transform.parent = GameObject.Find ("OVRCameraRig/CenterEyeAnchor").transform;
		}
		else {
		  //moves the cursor in front of the main camera.
		  this.transform.parent = Camera.main.transform;
		}
		transform.localPosition = new Vector3(0, 0, distance);
		transform.localRotation = new Quaternion (0, 0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition = new Vector3(0, 0, distance);
		transform.localRotation = new Quaternion (0, 0, 0, 0);
	}
}
