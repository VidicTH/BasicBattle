using UnityEngine;
using System.Collections;

public class LevelBuilder : MonoBehaviour {

	static LevelBuilder _instance;
	public static LevelBuilder instance {
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


	CountDownTimer _timer = new CountDownTimer();

	public GameObject obstacles;
	void Start(){
		_timer.Start (3f);
//		GameObject obstacle = GameObject.Instantiate (obstacles);
//		obstacle.transform.parent = ObstaclesTarget.instance.gameObject.transform;
//		obstacle.transform.localPosition = Vector3.zero;
	}
	void Update(){
		if (!Game.instance.isPause) {
			if (_timer.isZero) {
				_timer.Restart (3f);
				GameObject obstacle = GameObject.Instantiate (obstacles);
				obstacle.transform.parent = ObstaclesTarget.instance.gameObject.transform;
				obstacle.transform.localPosition = Vector3.zero;
			}
		}
	}

//	public void SpawnObjects(){
//		GameObject obstacle = GameObject.Instantiate (obstacles);
//		obstacle.transform.parent = ObstaclesTarget.instance.gameObject.transform;
//		obstacle.transform.localPosition = Vector3.zero;
//	}
}
