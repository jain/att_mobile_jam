using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float velocity = 0.1f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.DownArrow))
			transform.Translate (new Vector3 (velocity, 0, 0));
		else if (Input.GetKey (KeyCode.RightArrow))
			transform.Translate (n	ew Vector3 (0, 0, velocity));
		else if (Input.GetKey (KeyCode.LeftArrow))
			transform.Translate (new Vector3 (0, 0, -velocity));
		else if (Input.GetKey (KeyCode.UpArrow))
			transform.Translate (new Vector3 (-velocity, 0, 0));
	}
}
