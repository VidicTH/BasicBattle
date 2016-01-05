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
	Player player;

	// 
	[Header("\tUI Field")]

	[SerializeField] UILabel scoreLabel;

	[SerializeField] GameObject gamePrefab;

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
		GameObject game = GameObject.Instantiate (gamePrefab);
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

	public void UpdateScoreLabe(){
		scoreLabel.text = "Score: " +  Player.instance.score.ToString ("0000");
	}

	public void GameOver(){
		GameObject gamePreb = GameObject.Find ("GameplayPrefab(Clone)");
		Destroy (gamePreb);
		//game.isPause = true;
		GameGui.instance.PushPanel ("ResultPanel");
	}
}
