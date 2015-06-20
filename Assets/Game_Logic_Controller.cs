using UnityEngine;
using System.Collections;

public class Game_Logic_Controller : MonoBehaviour {
	public GameObject cube_prefab;
	public ArrayList list = new ArrayList();
	public float velocity = 0.1f;
	public int counter = 0;
	public int incrementer = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject cube in list){
			cube.transform.Translate (new Vector3 (velocity, 0, 0));
		}
		counter++;
		if (counter == 30) {
			velocity*=1.01f;
			for(int i = 0; i<incrementer; i++){
			GameObject new_cube = Instantiate (cube_prefab, new Vector3 (-20, 0, UnityEngine.Random.Range (-20, 20)), Quaternion.identity) as GameObject;
			new_cube.GetComponent<Renderer> ().material.color = new Color (Random.value, Random.value, Random.value, 1);
			list.Add (new_cube);
			}
			counter=0;
			incrementer++;
		}
	}
}
