using UnityEngine;
using System.Collections;

public class CarAnimate : MonoBehaviour {


    public Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(30, 0, 0, ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
