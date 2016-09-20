using UnityEngine;
using System.Collections;

public class DestroyBullets : MonoBehaviour {
	public float destroyDistance = 100.0f;


	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if ((player.transform.position - transform.position).magnitude > destroyDistance) {
			Destroy (gameObject);
		}
	}
}
