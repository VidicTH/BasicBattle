using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	static Player _instance;
	public static Player instance {
		get {
			return _instance;
		}
	}


	Rigidbody2D _rigidbody2d;
	public Rigidbody2D rigidbody2D {
		get {
			if (_rigidbody2d == null) {
				_rigidbody2d = GetComponent<Rigidbody2D>();
			}
			return _rigidbody2d;
		}
	}

	//PRIVATE VALUE 
	Game game {
		get {
			return Game.instance;
		}
	}
	Weapon weapon;
	Vector2 velocity = Vector2.zero;
	public bool isGoup;
	public bool isDash;
	void Awake () {
		_instance = this;
	}

	// Use this for initialization
	void Start () {
		velocity.y = -3;
		isGoup = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!game.isPause) {
			if (isGoup) {
				GoUp ();
			} else {
				GoDown ();
			}
			rigidbody2D.velocity = velocity;
		}
		else if (rigidbody2D != null) {

			rigidbody2D.velocity = new Vector2 (0, 0);			

		}

	}
	public void GoUp(){
		if (!isDash) {
			velocity.y = 3;
		} else
			velocity.y = 1.5f;
	}
	public void GoDown(){
		if (!isDash) {
			velocity.y = -3;
		} else
			velocity.y = -1.5f;
	}
	public void DashEnable(){
		isDash = true;
	}
	public void DashDisable(){
		isDash = false;
	}
	public void Attack(){
		if ( this.weapon != null )
		{
			if ( this.weapon.CanAttack )
			{
				this.weapon.Attack();
			}
		}
	}
	public void DisableWeaponByTime(float timer){
		StartCoroutine (IEDisableWeapon(timer));
	}
	IEnumerator IEDisableWeapon(float timer){
		this.weapon.CanAttack = false;
		yield return new WaitForSeconds (timer);
		this.weapon.CanAttack = true;
	}
}
