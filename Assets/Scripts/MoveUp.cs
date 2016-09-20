using UnityEngine;
using System.Collections;

public class MoveUp : MonoBehaviour {
	public float speed = 40.0f;

	// Update is called once per frame
	void Update () {
		transform.position -= transform.forward * speed * Time.deltaTime;
	}
}
