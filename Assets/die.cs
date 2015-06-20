using UnityEngine;
using System.Collections;

public class die : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x > 5.0f)
			Destroy (gameObject);
	}
}
