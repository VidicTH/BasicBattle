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
	public Rigidbody2D pRigidbody2D {
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

	//SerializeField 
	[SerializeField] StateManager weapons;
	void Awake () {
		if (_instance != null) {
			Debug.LogError("Multiple Player Instances Exist.");
		} else {
			_instance = this;
		}
	}

	// Use this for initialization
	void Start () {
		weapons.ChangeState ("Hammer");
		if (weapons.current != null) {
			weapon = weapons.current.GetComponent<Weapon> ();
		}

		velocity.y = -3;
		isGoup = false;
		this.weapon.CanAttack = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!game.isPause) {
			if (isGoup) {
				GoUp ();
			} else {
				GoDown ();
			}
			pRigidbody2D.velocity = velocity;
		}
		else if (pRigidbody2D != null) {

			pRigidbody2D.velocity = new Vector2 (0, 0);			

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

}
