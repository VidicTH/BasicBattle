using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnBecameInvisible(){
		Destroy (this.gameObject);
	}
	void OnTriggerEnter2D(Collider2D other)
	{				
		Destroy (this.gameObject);
		Destroy (other.gameObject);
		Player.instance.score += 1;
		Debug.LogError (Player.instance.score.ToString());
		GamePanel.instance.UpdateScoreLabe ();
	}
}
