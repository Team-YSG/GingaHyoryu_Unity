﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeScale : MonoBehaviour {

    public GameObject hand;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        hand.transform.position += new Vector3(0, 0, 0.2f);
		transform.localScale += new Vector3(0, 0, 0.2f);
        transform.position += new Vector3(0, 0, 0.1f);

	}
}
