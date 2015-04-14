using UnityEngine;
using System.Collections;

public class CylinderBehaviour : MonoBehaviour {
	
	bool looking = false;
	float redColor;
	float originalBlueColor;
	float greenColor;
	float blueColor;
	public int timerLength;
	int timer;
	int endSceneTimer;
	public string activateMessage = "You are looking at a Cylinder";

	void Start () 
	{
		redColor = GetComponent<Renderer>().material.GetColor ("_Color").r;
		greenColor = GetComponent<Renderer>().material.GetColor ("_Color").g;
		blueColor = GetComponent<Renderer>().material.GetColor ("_Color").b;
		originalBlueColor = blueColor;
		timer = timerLength;
		endSceneTimer = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//if the object is being looked at and is not max red value:
		if (looking) 
		{
			GameObject.Find("StatusText").GetComponent<TextMesh>().text = activateMessage;

			if (endSceneTimer > 50) 
			{
				GameObject.Find ("Blink System").SendMessage ("NextScene");
			}

			if (blueColor < 255) 
			{
				if (timer < 0) 
				{ // if the timer has reached 0
					GetComponent<Renderer>().material.color = new Color (redColor, greenColor, blueColor, 1); //set sphere color
					blueColor = blueColor + 0.01f; //increase red value of the sphere's color
					timer = timerLength; //reset the timer to the initial value
					endSceneTimer++;
				}

				else 
				{
					timer--; // decrements the timer each loop
				}
			}
		}

		//if the object is not activated and the object is not the original color:
		else if (!looking)
		{
			if (blueColor > originalBlueColor)
			{
				if (timer < 0) 
				{ //if the timer has reached 0
					GetComponent<Renderer>().material.color = new Color (redColor, greenColor, blueColor, 1);
					blueColor = blueColor - 0.01f; //decreases red value
					timer = timerLength; //sets timer back to initial value
				}

				else 
				{
					timer--; //decrements timer
				}
			}
		}
		looking = false;
	}
	
	//runs while the object is being looked at
	void Activate() 
	{
		looking = true;
	}
}