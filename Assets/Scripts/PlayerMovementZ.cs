using UnityEngine;
using System.Collections;

public class PlayerMovementZ : MonoBehaviour {
	public Vector2 movementSpeed = Vector2.one;
	public bool inverted = false;
	private float invert = 1; //1 for not inverted, -1 for inverted
	public float angleChangeSpeed = 50.0f;

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
		float horizontal = Input.GetAxis ("Horizontal")*movementSpeed.x;
		float vertical = Input.GetAxis ("Vertical")*movementSpeed.y;

		Vector3 direction = new Vector3 (horizontal, invert*vertical, 0);
		Vector3 finalDirection = new Vector3 (horizontal, invert*vertical, 1.0f);

		transform.position += direction * Time.deltaTime;
		transform.rotation = Quaternion.RotateTowards (transform.rotation, Quaternion.LookRotation (finalDirection), angleChangeSpeed*Time.deltaTime);
	}

	void LevelChanged(int newLevel) {
		Debug.Log ("ShipMovement: new level event received! Level: " + newLevel);
	}
}