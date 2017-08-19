using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

	public float speed;
	float size = 100;  //NOTE!

	// Update is called once per frame
	void Update()
	{
		transform.Translate(0, 0, speed);

		if (this.transform.position.z + size < 0)
		{
			Debug.Log("out of display");
			this.transform.Translate(0, 0, size * 2);
		}
	}
}
