/*
 * Description: This script will place either a normal camera
 * or an OVR camera as a child of either the main camera or the
 * main OVR camera. This new camera only renders the UI layer - 
 * which contains the cursor. Therefore, the user will always
 * be able to see the UI layer from the perspective of this camera,
 * which is overlayed onto the main camera being used
 * */

using UnityEngine;
using System.Collections;

public class RenderCursor : MonoBehaviour {

	public GameObject cursorCam; //normal camera
	public GameObject ovrCam; //OVR rig

	// Use this for initialization
	void Start () {
		if (Camera.main != null) //checks for Oculus
		{
			//turns off OVR Cursor Cam
			ovrCam.SetActive(false);

			//sets the cursor camera as a child of main camera
			cursorCam.transform.parent = Camera.main.transform;

			//places camera at same position of main camera:
			cursorCam.transform.localPosition = new Vector3 (0, 0, 0);
			cursorCam.transform.localRotation = new Quaternion (0, 0, 0, 0);

			//disables UI layer on Main Camera (Handled by Cursor Cam)
			Camera.main.cullingMask = ~(1 << LayerMask.NameToLayer ("UI"));
		}

		else { //if OVR is being used

			//turns off normal Cursor Cam to use OVR instead
			cursorCam.SetActive(false);
		
			//places camera rig under the main OVR Camera rig:
			ovrCam.transform.parent = GameObject.Find("OVRCameraRig").transform;

			//places rig at same position at main OVR rig
			ovrCam.transform.localPosition = new Vector3 (0, 0, 0);
			ovrCam.transform.localRotation = new Quaternion (0, 0, 0, 0);

			//disables UI layer on normal Oculus cams
			GameObject.Find ("OVRCameraRig/LeftEyeAnchor").GetComponent<Camera>().cullingMask = 
				~(1 << LayerMask.NameToLayer ("UI"));
			GameObject.Find ("OVRCameraRig/RightEyeAnchor").GetComponent<Camera>().cullingMask = 
				~(1 << LayerMask.NameToLayer ("UI"));
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
}
