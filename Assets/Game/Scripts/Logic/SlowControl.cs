using UnityEngine;
using System.Collections;

public class SlowControl : MonoBehaviour {
	
	void OnHover (bool isOver)
	{
		if (isOver)
			Player.instance.SlowEnable ();
		else
			Player.instance.SlowDisable ();

	}
}
