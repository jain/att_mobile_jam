using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game_Logic_Controller : MonoBehaviour {
	public GameObject cube_prefab;
	public List<GameObject> list = new List<GameObject> ();
	public float initial_velocity = 0.1f;

	public static long frameCount = 0;
	public static long score = 0; 

	public static int SPAWN_INTERVAL = 32;
	public static int INCREMENTER_COUNTER_MAX = 60;

	public int incrementer = 1;
	public int incrementer_counter = 0;
	public GameObject plane1;
	public GameObject plane2;
	public GameObject plane3;
	public GameObject plane4;
	public GameObject wall1;
	public GameObject wall2;

	public static float velocity = 0;

	public GameObject score_label;

	// Use this for initialization
	void Start () {
		velocity = initial_velocity;
	}

	// Update is called once per frame
	void FixedUpdate () {
		score += 8 * ((int) velocity); 
		score_label.GetComponent<TextMesh> ().text = (score).ToString ();

		if (frameCount % SPAWN_INTERVAL == 0) {
			if (velocity < 5.0f) {
				velocity += 0.0001f;
			}

			for(int i = 0; i<incrementer; i++){
				GameObject new_cube = Instantiate (cube_prefab, new Vector3 (-75, 142.9f, UnityEngine.Random.Range (-40, 40) + transform.position.z), Quaternion.identity) as GameObject;
				new_cube.transform.localScale = Vector3.one * 2 + Random.insideUnitSphere * 7;
				new_cube.GetComponent<Renderer> ().material.color = new Color (Random.value, Random.value, Random.value, 1);
				new_cube.GetComponent<Rigidbody>().AddForce(Random.insideUnitCircle * 100);
				list.Add (new_cube);
			}

		}

		incrementer_counter ++;
		if (incrementer_counter > INCREMENTER_COUNTER_MAX) {
			incrementer++;
			incrementer_counter = 0;
		}

		// Shift walls
		plane1.transform.Translate (velocity, 0, 0);
		plane2.transform.Translate (velocity, 0, 0);
		plane3.transform.Translate (velocity, 0, 0);
		plane4.transform.Translate (velocity, 0, 0);
		wall1.transform.Translate (velocity, 0, 0);
		wall2.transform.Translate (velocity, 0, 0);


		if (Input.GetMouseButtonDown (0)) {
			Application.LoadLevel("test");
		}

		frameCount++;
	}
}
