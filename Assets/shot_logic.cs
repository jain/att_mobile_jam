﻿using UnityEngine;
using System.Collections;

public class shot_logic : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision coll)
	{
		if (coll.gameObject.tag == "obstacle") {
			Destroy(coll.gameObject);
			Destroy(gameObject);
		}
	}
}
