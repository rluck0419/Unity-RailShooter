using UnityEngine;
using System.Collections;

public class AddToScoreOnTriggerEnter : MonoBehaviour {
	public int pointValue = 100;

	void OnTriggerEnter () {
		ScoreManager.Instance.score += pointValue;
	}
}
