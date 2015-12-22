using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

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

	}

}
