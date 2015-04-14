using UnityEngine;
using System.Collections;

public class Raycast : MonoBehaviour {
	public int rayLength;
	Ray gazeRay;
	GameObject centerAnchor;
	GameObject chosenObject;
	bool oculus = false;
	public string interactTag;

	// Use this for initialization
	void Start () {
		if (Camera.main == null) {
			oculus = true;
		}



		if (oculus) {
			centerAnchor = GameObject.Find ("CenterEyeAnchor");
		}
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		//creates the ray to be Raycasted:
		if (oculus) {
			gazeRay = new Ray (centerAnchor.transform.position, centerAnchor.transform.forward);
		} 
		else {
			gazeRay = new Ray (Camera.main.transform.position, Camera.main.transform.forward);
		}
		//Debug.DrawRay (centerPoint.transform.position, centerPoint.transform.forward * rayLength);
		if (Physics.Raycast (gazeRay, out hit, rayLength)) {
			//specifies the tag that it should activate:
			if (hit.collider.tag == interactTag) {
				//stores the object it collides with for use with deactivation:
				if (chosenObject == null) {
					chosenObject = hit.collider.gameObject;
				}
				//calls Activate method in the object:
				chosenObject.gameObject.SendMessage ("Activate");
			} else {
				//deactivates the object once the user looks away from tagged object:
				if (chosenObject != null) {
					chosenObject.gameObject.SendMessage ("Deactivate");
					chosenObject = null;
				}
			}
			//deactivates the object once the user looks away and is looking at nothing:
		} 
		else {
			if (chosenObject != null) {
				chosenObject.gameObject.SendMessage ("Deactivate");
				chosenObject = null;
			}
		}
	}
}
