using UnityEngine;
using System.Collections;

public class HammerWeapon : Weapon {

	[SerializeField]  GameObject bullet;
	public override void Attack()
	{			
		base.Attack();
		GameObject bulletObj = GameObject.Instantiate (bullet);
		bulletObj.transform.localPosition = Player.instance.gameObject.transform.localPosition;
		bulletObj.transform.parent = LevelBuilder.instance.gameObject.transform;

	}
}
