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

	public GameObject plane1;
	public GameObject plane2;
	public GameObject plane3;
	public GameObject plane4;

	public static float velocity = 0;

	public GameObject score_label;

	public int score = 0;

	// Use this for initialization
	void Start () {
		velocity = initial_velocity;
	}

	// Update is called once per frame
	void Update () {
		score ++;
		score_label.GetComponent<TextMesh> ().text = score.ToString ();

		counter++;
		if (counter == MAXCOUNTER) {
			velocity*=1.01f;
			//for(int i = 0; i<incrementer; i++){
			GameObject new_cube = Instantiate (cube_prefab, new Vector3 (-50, 0, UnityEngine.Random.Range (-40, 40) + transform.position.z), Quaternion.identity) as GameObject;
			new_cube.GetComponent<Renderer> ().material.color = new Color (Random.value, Random.value, Random.value, 1);
			new_cube.GetComponent<Rigidbody>().AddForce(Random.insideUnitCircle * 100);
			list.Add (new_cube);
			//}
			counter=0;
			incrementer++;
		}

		print (velocity);
		plane1.transform.Translate (velocity, 0, 0);
		plane2.transform.Translate (velocity, 0, 0);
		plane3.transform.Translate (velocity, 0, 0);
		plane4.transform.Translate (velocity, 0, 0);

		if (Input.GetMouseButtonDown (0)) {
			Application.LoadLevel("test");
		}
	}
}
