/* 
 * NOTICE: Only runs latest Lerp method 
 * Date: 3-7-15
 * Project: HackAZ 
 */ 

using UnityEngine;
using System.Collections;

public class ChangeSkyboxVer4 : MonoBehaviour {

	public Material theSkybox;
	//public Color[] arrayOfColors;
	public Color colorOne = Color.red; 
	public Color colorTwo = Color.green;
	public Color colorThree = Color.blue; 
	public Color colorFour = Color.cyan; 
	public Color colorFive = Color.magenta; 
	public Color colorSix = Color.white; 
	public Color colorSeven = Color.grey; 
	public Color colorEight = Color.yellow; 
	public float duration = 1.0F; 

	// Use this for initialization
	void Start () {
		//Color colorStart = Color.red; 
		//Color colorEnd = Color.green;
		//float duration = 1.0F; 
	}
	
	// Update is called once per frame
	void Update () {

		//theSkybox.SetColor("_Tint", Color.Lerp(colorOne, colorTwo, (Time.time, duration) / duration))

		Color lerpedColor = Color.Lerp(colorOne, colorTwo, Time.time / duration); 
		theSkybox.SetColor("_Tint", lerpedColor); 
		lerpedColor = Color.Lerp(colorTwo, colorThree, Time.time / duration); 
		theSkybox.SetColor("_Tint", lerpedColor); 
		lerpedColor = Color.Lerp(colorThree, colorFour, Time.time / duration); 
		theSkybox.SetColor("_Tint", lerpedColor); 
		
		//first(); 
		//second(); 
		//float lerp = Mathf.PingPong(Time.time, duration) / duration; 
		//theSkybox.SetColor("_Tint", Color.Lerp(colorOne, colorTwo, duration)); 
		//lerp = Mathf.PingPong(Time.time, duration) / duration; 
		//theSkybox.SetColor("_Tint", Color.Lerp(colorTwo, colorThree, duration)); 
		//theSkybox.SetColor("_Tint", Color.Lerp(colorThree, colorFour, duration)); 
		//theSkybox.SetColor("_Tint", Color.Lerp(colorFour, colorFive, duration)); 
	}
	
	void first() { 
		float lerp = Mathf.PingPong(Time.time, duration) / duration; 
		theSkybox.SetColor("_Tint", Color.Lerp(colorOne, colorTwo, lerp)); 
		Debug.Log(lerp); 
	}
	
	void second() { 
		float lerp = Mathf.PingPong(Time.time, duration) / duration; 
		theSkybox.SetColor("_Tint", Color.Lerp(colorTwo, colorThree, lerp)); 
	}

}
