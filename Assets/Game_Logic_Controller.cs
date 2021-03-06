﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game_Logic_Controller : MonoBehaviour {
	public GameObject cube_prefab;
	public List<GameObject> list = new List<GameObject> ();
	public float initial_velocity = 0.1f;
	
	public long frameCount = 0;
	public long score = 1; 
	
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
	public GameObject whale_prefab;

	
	public static float velocity = 0;
	
	public GameObject score_label;
	
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
			if(PlayerController.shot_cooldown > 120)
				score_label.GetComponent<TextMesh> ().text = "SHOT READY!";
		}

		if (frameCount == 100) {
			GameObject new_whale = Instantiate (whale_prefab, new Vector3 (-75, 142.9f, UnityEngine.Random.Range (-40, 40) + transform.position.z), Quaternion.identity) as GameObject;
			new_whale.GetComponent<Rigidbody>().AddTorque(Random.insideUnitCircle * 100);
		}
		
		if (frameCount % SPAWN_INTERVAL == 0) {
			if (velocity < 5.0f) {
				velocity += 0.0001f;
			}
			for(int i = 0; i<incrementer; i++){
				GameObject new_cube = Instantiate (cube_prefab, new Vector3 (-75, 142.9f, UnityEngine.Random.Range (-40, 40) + transform.position.z), Quaternion.identity) as GameObject;
				new_cube.transform.localScale = Vector3.one * 3 + Random.insideUnitSphere * 6;
				new_cube.GetComponent<Renderer> ().material.color = new Color (Random.value, Random.value, Random.value, 1);
				new_cube.GetComponent<Rigidbody>().AddForce(Random.insideUnitCircle * 100);
				new_cube.GetComponent<Rigidbody>().AddTorque(Random.insideUnitCircle * 40);
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
		//plane3.transform.Translate (velocity, 0, 0);
		//plane4.transform.Translate (velocity, 0, 0);
		//wall1.transform.Translate (velocity, 0, 0);
		//wall2.transform.Translate (velocity, 0, 0);
		
		
		if (Input.GetMouseButtonDown (1)) {
			Application.LoadLevel("test");
		}
		
		frameCount++;
	}
}