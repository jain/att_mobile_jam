using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float velocity = 0.1f;
	public GameObject oculus_cam;
	public Vector3 z_axis;

	public bool death = false;
	public int death_counter = 0;
	public int max_death_counter = 180;

	// Use this for initialization
	void Start () {
		z_axis = new Vector3 (0, 0, 1);
	}

	void FixedUpdate()
	{
		if (death)
			death_counter ++;

		if (death_counter > max_death_counter)
			Application.LoadLevel ("test");

		
		Vector3 z_axis_projection = Vector3.Project (oculus_cam.transform.forward, z_axis);
		transform.position += new Vector3 (0, 0, z_axis_projection.z * Game_Logic_Controller.velocity * 1.5f);
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

	}

	void OnCollisionEnter(Collision coll)
	{
		if (coll.gameObject.tag != "obstacle" || death)
			return;

		GameObject[] g_objects = GameObject.FindGameObjectsWithTag("obstacle");
		print (g_objects.Length );
		foreach(GameObject g in g_objects)
		{
			g.GetComponent<Renderer>().material.color = Color.red;		
		}

		GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
		GetComponent<Rigidbody>().AddForce(Random.insideUnitSphere * 1000 + Vector3.up * 1000);
		GetComponent<Rigidbody>().AddTorque(Random.insideUnitSphere * 10);
		death = true;
	}
}
