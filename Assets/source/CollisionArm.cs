using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionArm : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider collision)
	{
		Debug.Log("Hit Trigger");
	}

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log("Hit");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
