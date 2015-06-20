using UnityEngine;
using System.Collections;

public class obstacle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 (Game_Logic_Controller.velocity, 0, 0);
	}
}
