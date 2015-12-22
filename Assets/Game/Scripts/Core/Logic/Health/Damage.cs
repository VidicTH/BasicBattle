using UnityEngine;
using UnityEngine.Events;
using System.Collections;

//This script should deal damage to anything it collides with that contains a health object

public class Damage : MonoBehaviour {

	public float value = 1f;

	public UnityEvent OnDamage;
	
	// Use this for initialization
	protected virtual void Start() 
	{
	
	}
	
	protected virtual void OnTriggerEnter2D(Collider2D other)
	{
		Trigger(other.gameObject);
	}
	
	protected virtual void OnColliderEnter2D(Collision2D collision)
	{
		Trigger(collision.gameObject);
	}
	
	protected virtual void Trigger(GameObject other)
	{
		var health = other.GetComponent<Health>();
		
		if ( health != null ) {			
			if ( !health.IsInvulnerable ) {				
				health.Damage(value);
				OnDamage.Invoke();
			}
		}
	}
			
}
