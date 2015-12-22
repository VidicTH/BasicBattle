using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public float timeToEnable;
	private bool _canAttack;
	public virtual bool CanAttack {
		get {
			return _canAttack;
		}
		set{
			_canAttack = value;
		}
	}


	public virtual void Attack()
	{
		DisableWeaponByTime ();
	}
	public void DisableWeaponByTime(){
		StartCoroutine (IEDisableWeapon());
	}
	IEnumerator IEDisableWeapon(){
		_canAttack = false;
		yield return new WaitForSeconds (timeToEnable);
		_canAttack = true;
	}
}
