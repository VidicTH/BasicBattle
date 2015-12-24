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
	Game game;
	Player player;

	// 
	[Header("\tUI Field")]

	[SerializeField] UILabel scoreLabel;



	// Use this for initialization
	void Awake ()
	{
		if (_instance != null) {
			Debug.LogError ("Multiple Game Instances Exist.");
		} else {
			_instance = this;
		}
		game = Game.instance;

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

	public void UpdateScoreLabe(){
		scoreLabel.text = "Score: " +  Player.instance.score.ToString ("0000");
	}

	public void GameOver(){
		game.isPause = true;
		GameGui.instance.PushPanel ("ResultPanel");
	}
}
