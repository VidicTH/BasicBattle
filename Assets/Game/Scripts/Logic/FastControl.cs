using UnityEngine;
using System.Collections;

public class FastControl : MonoBehaviour {

	void OnHover (bool isOver)
	{
		if (isOver)
			Player.instance.FastEnable ();
		else
			Player.instance.FastDisable ();

	}
}
