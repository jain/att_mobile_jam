using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float velocity = 0.1f;
	public GameObject oculus_cam;
	public Vector3 z_axis;
	// Use this for initialization
	void Start () {
		z_axis = new Vector3 (0, 0, 1);
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Input.GetKey (KeyCode.DownArrow))
			transform.Translate (new Vector3 (velocity, 0, 0));
		else if (Input.GetKey (KeyCode.RightArrow))
			transform.Translate (new Vector3 (0, 0, velocity));
		else if (Input.GetKey (KeyCode.LeftArrow))
			transform.Translate (new Vector3 (0, 0, -velocity));
		else if (Input.GetKey (KeyCode.UpArrow))
			transform.Translate (new Vector3 (-velocity, 0, 0));*/

		Vector3 z_axis_projection = Vector3.Project (oculus_cam.transform.forward, z_axis);
		transform.position += new Vector3 (0, 0, z_axis_projection.z * velocity);
	}
}
