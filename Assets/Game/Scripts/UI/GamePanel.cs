using UnityEngine;
using System.Collections;

public class GamePanel : AnimatedPanel
{


	static GamePanel _instance;

	public static GamePanel instance {
		get {
			return _instance;
		}
	}


	// Use this for initialization
	void Awake ()
	{
		if (_instance != null) {
			Debug.LogError ("Multiple Game Instances Exist.");
		} else {
			_instance = this;
		}

	}

	
	#region Panel

	protected override void PanelWillShow ()
	{

	}

	protected override void PanelDidShow ()
	{
		Game.instance.isPause = false;
		
	}

	protected override void PanelWillHide ()
	{
		
	}

	protected override void PanelDidHide ()
	{
		
	}

	#endregion

	public void Attack ()
	{
		Player.instance.Attack ();
	}


}
