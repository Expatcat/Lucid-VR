using UnityEngine;
using System.Collections;

public class SphereBehaviour : MonoBehaviour {

	bool looking = false;
	float redColor;
	float originalRedColor;
	float greenColor;
	float blueColor;
	public int timerLength;
	int timer;
	public string activateMessage = "You are looking at a Sphere";

	void Start () 
	{
		originalRedColor = GetComponent<Renderer>().material.GetColor ("_Color").r;
		redColor = originalRedColor;
		greenColor = GetComponent<Renderer>().material.GetColor ("_Color").g;
		blueColor = GetComponent<Renderer>().material.GetColor ("_Color").b;
		timer = timerLength;

	}
	
	// Update is called once per frame
	void Update () 
	{
		//if the object is being looked at and is not max red value:
		if (looking) 
		{
			GameObject.Find("StatusText").GetComponent<TextMesh>().text = activateMessage;
			
			if (redColor < 255) 
			{
				if (timer < 0) 
				{ // if the timer has reached 0
					GetComponent<Renderer>().material.color = new Color (redColor, greenColor, blueColor, 1); //set sphere color
					redColor = redColor + 0.01f; //increase red value of the sphere's color
					timer = timerLength; //reset the timer to the initial value
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
			if (redColor > originalRedColor)
			{
				if (timer < 0) 
				{ //if the timer has reached 0
					GetComponent<Renderer>().material.color = new Color (redColor, greenColor, blueColor, 1);
					redColor = redColor - 0.01f; //decreases red value
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
	
	void Activate() 
	{
		looking = true;
	}
}
