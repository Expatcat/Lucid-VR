using UnityEngine;
using System.Collections;

public class CenterCursor : MonoBehaviour {

	bool oculus = false;
	Camera selectedCamera;
	//default cursor size that the user can change
	public int cursorSize = 50;

	// Use this for initialization
	void Start () {
		//detects which camera is being used:
		if (Camera.main == null) {
				oculus = true;
		}
		if (oculus) {
			//sets the anchors for each camera and enables the GUILayer Component
			GameObject leftAnchor = GameObject.Find ("LeftEyeAnchor");
			if (leftAnchor.GetComponent<GUILayer>() == null) {
				leftAnchor.AddComponent<GUILayer>();
			}
			leftAnchor.GetComponent<GUILayer>().enabled = true;
			GameObject rightAnchor = GameObject.Find ("RightEyeAnchor");
			if (rightAnchor.GetComponent<GUILayer>() == null) {
				rightAnchor.AddComponent<GUILayer>();
			}
			rightAnchor.GetComponent<GUILayer>().enabled = true;
		}

		else {
			GameObject mainCamera = Camera.main.gameObject;
			if (mainCamera.GetComponent<GUILayer>() == null) {
				mainCamera.AddComponent<GUILayer>();
			}
				mainCamera.GetComponent<GUILayer>().enabled = true;
		}
		//centers the cursor based on user input for cursor size
		GetComponent<GUITexture>().pixelInset = new Rect(cursorSize / 2 * -1, cursorSize / 2 * -1, cursorSize, cursorSize);
	}

	// Update is called once per frame
	void Update () {
	}
}