using UnityEngine;
using System.Collections;

public class WheelMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    float rotationPosition;
	// Update is called once per frame
	void Update () {
        rotationPosition += .01f;
            rotationPosition = rotationPosition % 360;
        this.transform.Rotate(rotationPosition, 0, 0);
	}
}
