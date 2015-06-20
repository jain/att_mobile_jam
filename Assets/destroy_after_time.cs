using UnityEngine;
using System.Collections;

public class destroy_after_time : MonoBehaviour {

	public int life = 240;
	public float initial_scale = 1;

	// Use this for initialization
	void Start () {
		initial_scale = transform.localScale.x;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		life --;

		if (life <= 60) {
			float ratio = life / 60.0f;

			float new_scale = ratio * initial_scale;
			transform.localScale = Vector3.one * new_scale;
		}

		if (life <= 0)
			Destroy (gameObject);
	}
}
