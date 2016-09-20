using UnityEngine;
using System.Collections;

public class RollY : MonoBehaviour {
	public float doubleTapDelay = 0.4f;
	public float barrelRollDuration = 1.0f;
	private float time = float.MaxValue;
	private bool buttonDown = false;
	private bool inBarrelRoll = false;

	// Update is called once per frame
	void Update () {
		if (!inBarrelRoll) {
			float bankAxis = Input.GetAxis ("Roll");
			Vector3 newRotationEuler = transform.rotation.eulerAngles;
			newRotationEuler.y = -90 * bankAxis;
			Quaternion newQuat = Quaternion.identity;
			newQuat.eulerAngles = newRotationEuler;
			transform.rotation = newQuat;

			if (bankAxis == 0.0f) {
				buttonDown = false;
			} else if (buttonDown == false) {
				buttonDown = true;
				if (time < doubleTapDelay) {
					if (bankAxis < 0.0f) {
						StartCoroutine ("BarrelRollLeft");
					} else if (bankAxis > 0.0f) {
						StartCoroutine ("BarrelRollRight");
					}
				}
				time = 0.0f;
			}
			time += Time.deltaTime;
		}
	}

	IEnumerator BarrelRollLeft() {
		inBarrelRoll = true;
		float t = 0.0f;

		Vector3 initialRotation = transform.localRotation.eulerAngles;
		Vector3 goalRotation = initialRotation;
		goalRotation.z += 180.0f;

		Vector3 currentRotation = initialRotation;
					
		while (t < barrelRollDuration / 2.0f) {
			currentRotation.z = Mathf.Lerp (initialRotation.z, goalRotation.z, t / (barrelRollDuration / 2.0f));
			transform.localRotation = Quaternion.Euler (currentRotation);
			t += Time.deltaTime;
			yield return null;
		}

		t = 0;

		initialRotation = transform.localRotation.eulerAngles;
		goalRotation = initialRotation;
		goalRotation.z += 180.0f;

		while (t < barrelRollDuration / 2.0f) {
			currentRotation.z = Mathf.Lerp (initialRotation.z, goalRotation.z, t / (barrelRollDuration / 2.0f));
			transform.localRotation = Quaternion.Euler (currentRotation);
			t += Time.deltaTime;
			yield return null;
		}

		inBarrelRoll = false;
	}

	IEnumerator BarrelRollRight() {
		inBarrelRoll = true;
		float t = 0.0f;

		Vector3 initialRotation = transform.localRotation.eulerAngles;
		Vector3 goalRotation = initialRotation;
		goalRotation.z -= 180.0f;

		Vector3 currentRotation = initialRotation;

		while (t < barrelRollDuration / 2.0f) {
			currentRotation.z = Mathf.Lerp (initialRotation.z, goalRotation.z, t / (barrelRollDuration / 2.0f));
			transform.localRotation = Quaternion.Euler (currentRotation);
			t += Time.deltaTime;
			yield return null;
		}

		t = 0;

		initialRotation = transform.localRotation.eulerAngles;
		goalRotation = initialRotation;
		goalRotation.z -= 180.0f;

		while (t < barrelRollDuration / 2.0f) {
			currentRotation.z = Mathf.Lerp (initialRotation.z, goalRotation.z, t / (barrelRollDuration / 2.0f));
			transform.localRotation = Quaternion.Euler (currentRotation);
			t += Time.deltaTime;
			yield return null;
		}

		inBarrelRoll = false;
	}
}
