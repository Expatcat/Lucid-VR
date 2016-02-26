using UnityEngine;
using System.Collections;

public class ChangeSkyboxVer2 : MonoBehaviour {

	public Material theSkybox; 

	// Use this for initialization
	void Start () {
		//RenderSettings.skybox.SetColor("_Tint", Color.red);
		theSkybox.SetColor("_Tint", Color.green); 
		//theSkybox.SetColor("_Tint", Color (1.0, 0.0, 0.0)); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
