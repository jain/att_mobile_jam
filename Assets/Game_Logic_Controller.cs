using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game_Logic_Controller : MonoBehaviour {
	public GameObject cube_prefab;
	public List<GameObject> list = new List<GameObject> ();
	public float initial_velocity = 0.1f;
	public int counter = 0;
	public int MAXCOUNTER = 30;
	public int incrementer = 1;
	public int incrementer_counter = 0;
	public int incrementer_counter_max = 60;
	public int message_timer = 0;
	public GameObject plane1;
	public GameObject plane2;
	public GameObject plane3;
	public GameObject plane4;
	public GameObject wall1;
	public GameObject wall2;

	public static float velocity = 0;

	public GameObject score_label;

	public int score = 0;

	public bool whale_drop = false;
	public int whale_drop_counter = 0;
	public GameObject whale_prefab;

	// Use this for initialization
	void Start () {
		velocity = initial_velocity;
		score_label.GetComponent<TextMesh>().text = "Chase the UFO!";
	}

	// Update is called once per frame
	void FixedUpdate () {
		score = score + (int) (32 * velocity); 
		if (frameCount > 200) {
			score_label.GetComponent<TextMesh> ().text = (score).ToString ();
		}

		if (!whale_drop) {
			whale_drop_counter ++;
			
			if(whale_drop_counter >= 1)
			{
				GameObject new_whale = Instantiate (whale_prefab, new Vector3 (-75, 142.9f, UnityEngine.Random.Range (-40, 40) + transform.position.z), Quaternion.identity) as GameObject;
				new_whale.GetComponent<Rigidbody>().AddTorque(Random.insideUnitCircle * 100);
				whale_drop = true;
			}
		}

		score ++;

		message_timer ++;
		if(message_timer > 240)
			score_label.GetComponent<TextMesh> ().text = score.ToString ();

		counter++;
		if (counter == MAXCOUNTER) {
			velocity += 0.0001f;
			if(velocity > 5)
				velocity = 5;
			for(int i = 0; i<incrementer; i++){
			GameObject new_cube = Instantiate (cube_prefab, new Vector3 (-75, 142.9f, UnityEngine.Random.Range (-40, 40) + transform.position.z), Quaternion.identity) as GameObject;
			new_cube.transform.localScale = Vector3.one * 2 + Random.insideUnitSphere * 7;
			new_cube.GetComponent<Renderer> ().material.color = new Color (Random.value, Random.value, Random.value, 1);
			new_cube.GetComponent<Rigidbody>().AddForce(Random.insideUnitCircle * 100);
			list.Add (new_cube);
			}
			counter=0;

		}

		incrementer_counter ++;
		if (incrementer_counter > incrementer_counter_max) {
			incrementer++;
			incrementer_counter = 0;
		}

		plane1.transform.Translate (velocity, 0, 0);
		plane2.transform.Translate (velocity, 0, 0);
		//plane3.transform.Translate (velocity, 0, 0);
		//plane4.transform.Translate (velocity, 0, 0);
		//wall1.transform.Translate (velocity, 0, 0);
		//wall2.transform.Translate (velocity, 0, 0);


		if (Input.GetMouseButtonDown (0)) {
			Application.LoadLevel("test");
		}
	}
}
