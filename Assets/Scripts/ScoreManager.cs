using UnityEngine;
using System.Collections;

public class ScoreManager: MonoBehaviour {
	public int currentLevel = 0;
	public int[] levelScoreThresholds;
	public int score = 0;

	public delegate void LevelChangedEvent(int newLevel);
	public event LevelChangedEvent LevelChanged;

	void OnGUI() {
		GUILayout.Label ("Score: " + score);
	}

	void Update() {
		//handle game state here
		if (score > levelScoreThresholds [currentLevel]) {
			currentLevel += 1;
			//send notification (of some kind) to objects that need to react
			LevelChanged(currentLevel);
		}
	}

	#region SingletonAndAwake
	private static ScoreManager instance = null;
	public static ScoreManager Instance {
		get { return instance; }
	}
	void Awake() {
		if (instance != null && instance != this) {
			Destroy (this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad (this.gameObject);
		gameObject.name = "$ScoreManager";
	}
	#endregion
}
