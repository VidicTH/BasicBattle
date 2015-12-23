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
	//PUBLIC VALUE
	public bool isGoup;
	public bool isSlow;
	public bool isFast;
	public int score;

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
		velocity.y = -2f;
		isGoup = false;
		this.weapon.CanAttack = true;
		score = 0;
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
		if (isSlow) {
			velocity.y = 1;
		} else if (isFast) {
			velocity.y = 3;
		} else {
			velocity.y = 2f;
		}
	}
	public void GoDown(){
		if (isSlow) {
			velocity.y = -1;
		} else if (isFast) {
			velocity.y = -3;
		} else {
			velocity.y = -2f;
		}
	}

	public void SlowEnable(){
		isSlow = true;
	}
	public void SlowDisable(){
		isSlow = false;
	}
	public void FastEnable(){
		isFast = true;
	}
	public void FastDisable(){
		isFast = false;
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
