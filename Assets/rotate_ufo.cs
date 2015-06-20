using UnityEngine;
using System.Collections;

public class rotate_ufo : MonoBehaviour {

	float sinCounter = 0;

	float initialHeight = 0;

	// Use this for initialization
	void Start () {
		initialHeight = transform.position.y;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		sinCounter += 0.04f;
		transform.position = new Vector3 (transform.position.x, initialHeight + Mathf.Sin (sinCounter) * 10, 
		                                 transform.position.z);
		                                 
		transform.Rotate (new Vector3 (0, 0.1f, 0));
	}
}
