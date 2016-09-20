using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	public float targetDistance = 10.0f;
	public float time = 2.0f;
	public bool shot = false;
	public bool exploded = false;
	public int pointValue = 100;
	public Rigidbody bullet;
	public float velocity = 10.0f;

	// Use this for initialization
	void Start () {
	}

	void OnTriggerEnter () {
		if (!shot) {
			ScoreManager.Instance.score += pointValue;
			shot = true;
		}
		StartCoroutine (Explosion());
	}

	// Update is called once per frame
	void LateUpdate () {
		if (!exploded) {
			GameObject player = GameObject.FindGameObjectWithTag ("Player");
			if ((player.transform.position - transform.position).magnitude < targetDistance) {
				Vector3 newPosition = transform.position;
				newPosition.z = player.transform.position.z + targetDistance;
				transform.position = newPosition;
			}
// create new bullet directed at player & add force to shoot the bullet faster than other ojbects in scene
//			Rigidbody newBullet = Instantiate (bullet, transform.position, transform.rotation) as Rigidbody;
//			newBullet.AddForce (transform.forward*-velocity,ForceMode.VelocityChange);
		}
	}

	IEnumerator Explosion () {
		exploded = true;
		float t = 0.0f;
		while (t < time) {
			ParticleSystem explosionParticles = gameObject.GetComponent<ParticleSystem> ();
			explosionParticles.Emit(100);
			t += Time.deltaTime;
			yield return null;
		}
		Destroy (gameObject);
	}
}
