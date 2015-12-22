using UnityEngine;
using System.Collections;

public class GamePanel : AnimatedPanel {


	static GamePanel _instance;
	public static GamePanel instance {
		get {
			return _instance;
		}
	}
	[Header("Panel Field")]
	
	[SerializeField] UILabel panelNameLabel;
	// Use this for initialization
	void Awake () {
		_instance = this;
	}

	
	#region Panel

	protected override void PanelWillShow ()
	{

	}
	protected override void PanelDidShow ()
	{
		
	}
	protected override void PanelWillHide ()
	{
		
	}
	protected override void PanelDidHide ()
	{
		
	}
	#endregion
}
