using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour {

	public static Transform target;

	static CameraFollower _instance;
	public static CameraFollower instance {
		get {
			return _instance;
		}
	}

	//public Transform target;
	
	public Vector3 offset;
	
	public float smoothTime = 0f;
	
	private Vector3 velocity = Vector3.zero;
	
	void Awake()
	{
		_instance = this;
	}
	
	void Update()
	{
		//Move();
	}
	
	void FixedUpdate()
	{
		Move(); //Switching to use FixedUpdate only. Other methods are causing too much jitter
	}
	
	void LateUpdate()
	{
		//Move();
	}
	
	void Move()
	{
		if ( target != null ) {
			// Define a target position above and behind the target transform
			Vector3 targetPosition = new Vector3 (target.transform.position.x, this.transform.position.y, this.transform.position.z);
			targetPosition += offset;
			
			// Smoothly move the camera towards that target position
			this.transform.position =  Vector3.SmoothDamp(this.transform.position, targetPosition, ref velocity, smoothTime);
		}
	}
	
}
