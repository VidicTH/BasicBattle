using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed = 200f;
	public Vector3 direction = new Vector3(1,0,0);
	
	// Update is called once per frame
	void Update()
	{
		if (!Game.instance.isPause) {
			this.transform.localPosition += direction * (speed * Time.deltaTime);
		}
	}
	
}
