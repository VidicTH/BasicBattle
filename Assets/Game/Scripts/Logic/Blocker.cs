using UnityEngine;
using System.Collections;

public class Blocker : MonoBehaviour
{

	[Header("\tSerializeField Field")]
	[SerializeField]
	bool
		topBlocker;

	void OnTriggerEnter2D (Collider2D  other)
	{
		var player = Player.instance;
		if (!topBlocker) {
			player.isGoup = true;
		} else {
			player.isGoup = false;
		}

	}
}
