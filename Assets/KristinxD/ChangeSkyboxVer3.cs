using UnityEngine;
using System.Collections;

public class ChangeSkyboxVer3 : MonoBehaviour {

	public Material theSkybox;
	public Color colorStart = Color.red; 
	public Color colorEnd = Color.green;
	public float duration = 1.0F; 

	// Use this for initialization
	void Start () {
		//Color colorStart = Color.red; 
		//Color colorEnd = Color.green;
		//float duration = 1.0F; 
	}
	
	// Update is called once per frame
	void Update () {
		//float duration = 1.0F;
		float lerp = Mathf.PingPong(Time.time, duration) / duration; 
		theSkybox.SetColor("_Tint", Color.Lerp(colorStart, colorEnd, lerp)); 
	}
	

	    //void Update() {
	    //    float lerp = Mathf.PingPong(Time.time, duration) / duration;
	    //    rend.material.color = Color.Lerp(colorStart, colorEnd, lerp);
	    //}
	//}
}
