using UnityEngine;
using System.Collections;

public class ObstaclesTarget : MonoBehaviour {

	static ObstaclesTarget _instance;
	public static ObstaclesTarget instance {
		get {
			return _instance;
		}
	}
	void Awake () {
		if (_instance != null) {
			Debug.LogError("Multiple LevelBuilder Instances Exist.");
		} else {
			_instance = this;
		}
	}
}
