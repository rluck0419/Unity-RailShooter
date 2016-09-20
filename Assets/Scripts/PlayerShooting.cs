using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {
	public Rigidbody bullet;
	public float velocity = 10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			Rigidbody newBullet = Instantiate (bullet, transform.position, transform.rotation) as Rigidbody;
			newBullet.AddForce (transform.forward*velocity,ForceMode.VelocityChange);
		}
	}
}
