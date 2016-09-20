using UnityEngine;
using System.Collections;

public class PlayerMovementY : MonoBehaviour {
	public float movementSpeed = 1.0f;
	public bool inverted = false;
	private float invert = 1; //1 for not inverted, -1 for inverted

	// Use this for initialization
	void Start () {
		if (inverted) {
			invert = -1;
		}
		ScoreManager.Instance.LevelChanged += LevelChanged;
	}

	void OnDestroy() {
		ScoreManager.Instance.LevelChanged -= LevelChanged;
	}

	void OnDisable() {
		ScoreManager.Instance.LevelChanged -= LevelChanged;
	}

	// Update is called once per frame
	void Update () {
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");

		Vector3 direction = new Vector3 (horizontal, 0, invert * vertical);
		Vector3 finalDirection = new Vector3 (horizontal, 1.0f, invert * vertical);

		transform.position += direction * movementSpeed * Time.deltaTime;
		transform.rotation = Quaternion.RotateTowards (transform.rotation, Quaternion.LookRotation (finalDirection), Mathf.Deg2Rad * 50.0f);
	}

	void LevelChanged(int newLevel) {
		Debug.Log ("ShipMovement: new level event received! Level: " + newLevel);
	}
}