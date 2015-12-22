using UnityEngine;
using System.Collections;

public class Missiles : MonoBehaviour
{
	public int fastPoolId = 0;
	public int hitVfxPoolId = 0;
	public float speed = 20f;
	
	CountDownTimer _timer = new CountDownTimer();
	
	float turn;
	float turnSpeed = 720f;
	
	GameObject currentTarget;
	
	void Start()
	{
		_timer.Start(3f);
	}

	void Update()
	{	

		if (!Game.instance.isPause) {
			
			if (_timer.isZero) {
				BlowUp();
			}
		
			if (currentTarget != null) {
		
				//Rotate Towards Target
				var dir = (currentTarget.transform.position - this.transform.position);
				dir.z = 0;
			
				//Smooth Turning Angle
				var targetAngle = FindAngle(Vector3.right, dir, Vector3.forward);
			
				var angles = transform.localEulerAngles;
			
				float angleDelta = targetAngle - angles.z;
			
				if (angleDelta > 180f) {
					angleDelta -= 360f;
				}
				if (angleDelta < -180f) {
					angleDelta += 360f;
				}
			
				if (angleDelta > 0f) {
					angles.z += turnSpeed * Time.deltaTime;
				} else {
					angles.z -= turnSpeed * Time.deltaTime;
				}
						
				// Just set angle to target angle if they are close
				if (Mathf.Abs(angleDelta) < (turnSpeed * Time.deltaTime)) {
					angles.z = targetAngle;
				}
			
				transform.localEulerAngles = angles;
						
			} else {
			
				FindNearestTarget();
						
			}
		
		
			//Move Transform Forward			
			transform.position += transform.right * speed * Time.deltaTime;
		
		}
	}
	
	void OnTriggerEnter2D(Collider2D others)
	{
		BlowUp();
	}
	
	public void OnFastInstantiate()
	{
		_timer.Start(3f);
		currentTarget = null;
	}
	
	public void OnFastDestroy()
	{
		
	}
	
	float FindAngle(Vector3 v1, Vector3 v2, Vector3 axis)
	{
		return Mathf.Atan2(Vector3.Dot(axis, Vector3.Cross(v1, v2)), Vector3.Dot(v1, v2)) * Mathf.Rad2Deg;
	}
	
	void FindNearestTarget()
	{
		
		var targets = Target.GetTargets();
		
		float minDistance = float.MaxValue;
		
		foreach (var target in targets) {
			
			if ( target.transform.position.x > this.transform.position.x ) {
			
				var dist = (target.transform.localPosition - transform.localPosition).sqrMagnitude;	
				
				if ( (dist < minDistance) ) {
					minDistance = dist;
					currentTarget = target.gameObject;
				}
			
			}
			
		}
		
	}
	
	void BlowUp()
	{
//		this.gameObject.FastDestroy(this.fastPoolId);
//		if ( this.hitVfxPoolId != 0 ) {
//			var hitVfxPool = FastPoolManager.GetPool(hitVfxPoolId,null,false);
//			var hitVfx = hitVfxPool.FastInstantiate();
//			hitVfx.transform.position = this.transform.localPosition;
//		}
		Debug.LogError("Missiles Hit");
	}
	
}

