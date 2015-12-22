using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Health : MonoBehaviour {

	[SerializeField] protected  float _currentHealth;
	[SerializeField] protected  float _maxHealth;
	
	public float currentHealth 
	{
		get {
			return _currentHealth;
		}
		set {
			_currentHealth = value;
		}
	}
	
	public float maxHealth
	{
		set {
			_maxHealth = value;
			_currentHealth = Mathf.Clamp(currentHealth,0,maxHealth);
			OnValueChanged.Invoke();
		}
		get {
			return _maxHealth;
		}
	}
	
	public float percent {
		get {
			if ( maxHealth == 0 )
			{
				return 0;
			}
			return Mathf.Clamp01(currentHealth / maxHealth);
		}
	}
	
	public bool IsDead {
		get {
			return (currentHealth == 0);
		}
	}
	
	public UnityEvent OnDamaged;
	public UnityEvent OnHealed;
	public UnityEvent OnValueChanged;
	public UnityEvent OnDeath;
	
	bool _invulnerable = false;
	public bool IsInvulnerable { 
		get {
			return _invulnerable;
		}
		set {
			_invulnerable = value;
		}
	}
	
	
#region Monobehavior
	
	protected virtual void Start () 
	{
	
	}
	
#endregion
	public void x2Heal(){
		maxHealth *= 2;
		_currentHealth = maxHealth;
		OnValueChanged.Invoke();
		OnHealed.Invoke ();
	}
	public void FullHeal()
	{
		_currentHealth = maxHealth;
		OnValueChanged.Invoke();
		OnHealed.Invoke();
	}
	
	public void Kill()
	{
		if ( _currentHealth != 0 ) {
			_currentHealth = 0;
			OnValueChanged.Invoke();
			OnDamaged.Invoke();
			Die();
		}
	}
	
	public void Damage(float amount)
	{
		if ( !this.IsDead && !this.IsInvulnerable) 
		{		
			_currentHealth = Mathf.Clamp(_currentHealth - amount,0,maxHealth);
			
			OnValueChanged.Invoke();
			OnDamaged.Invoke();
			
			if ( _currentHealth == 0 )
			{
				Die();
			}
		
		}
	}
	
	public void Heal(float amount)
	{
		if ( !this.IsDead ) 
		{
		
			_currentHealth = Mathf.Clamp(_currentHealth + amount,0,maxHealth);
		
			OnValueChanged.Invoke();
			OnHealed.Invoke();
			
			if ( currentHealth == 0 )
			{
				Die();
			}
			
		}	
	}
	
	protected void Die()
	{
		OnDeath.Invoke();
	}
	
}
