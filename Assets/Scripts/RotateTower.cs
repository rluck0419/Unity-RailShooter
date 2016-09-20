using UnityEngine;
using System.Collections;

public class RotateTower : MonoBehaviour {
	public float rotationSpeed = 10.0f;

	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up * Input.GetAxis ("Horizontal") * rotationSpeed * Time.deltaTime); 
	}
}
