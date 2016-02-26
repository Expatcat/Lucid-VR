using UnityEngine;
using System.Collections;

public class BirdScript : MonoBehaviour {

    [SerializeField]
    AudioClip[] birdCallArray;

    [SerializeField]
    float baseDelayTime = 2;

    [SerializeField]
    float baseRandom = 1;

    [SerializeField]
    float maxRandom = 5;

    float timeRemaining = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
        if (timeRemaining <= 0)
        {
            AudioClip clip = birdCallArray[(int)(Random.Range(0, birdCallArray.Length))];
            AudioSource.PlayClipAtPoint(clip, transform.position);
            timeRemaining = Random.Range(baseRandom, maxRandom) + baseDelayTime;
        }

        else
        {
            timeRemaining -= Time.deltaTime;

        }

	}
}
