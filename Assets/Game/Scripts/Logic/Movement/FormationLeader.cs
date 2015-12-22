using UnityEngine;
using System.Collections;

public class FormationLeader : MonoBehaviour {
		
	float yOrigin = 0;
	float amplitude = 1f;
	float speed = 3f;
		
	float time = 0;
	// Use this for initialization
	void Start () 
	{
		yOrigin = this.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if ( !Game.instance.isPause ) {
			
			time += Time.deltaTime;
			
			float t = Mathf.PingPong(time,1f);
			float y = Mathf.Sin(Mathf.PI*t) * amplitude;
			//y = Mathf.Sin(Mathf.PI*t) * amplitude;
		
			var pt = this.transform.position;
			pt.y = yOrigin + y;
			pt.x -= speed * Time.deltaTime;
			this.transform.position = pt;
		}
	}
	
}
