using UnityEngine;
using System.Collections;

public class CameraFollowXY : MonoBehaviour {
	public Transform objectToFollow;
	public Vector2 movementRatio = Vector2.one;

	// Update is called once per frame
	void LateUpdate () {
		Vector3 newPosition = objectToFollow.position;
		newPosition.x *= movementRatio.x;
		newPosition.y *= movementRatio.y;
		newPosition.z = transform.position.z;
		transform.position = newPosition;
	}
}
