using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnBecameInvisible(){	
		LevelBuilder.instance.SpawnObjects ();	
		Destroy (this.gameObject);	
		Debug.LogError ("OnBecameInvisible");
	}

}
