using UnityEngine;
using System.Collections;

public class FireScript : MonoBehaviour {
    public Light light;
    float maxIntensity = 1.5f;
    float minIntensity = .5f;

    float intervalTime = .1f;
    private float flickerInterval = .1f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        flickerInterval -= Time.deltaTime;

        if (flickerInterval < 0)
        {
            light.intensity = Random.Range(minIntensity, maxIntensity);
            flickerInterval = intervalTime;
        }
	}
}
