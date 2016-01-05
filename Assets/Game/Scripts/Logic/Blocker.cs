using UnityEngine;
using System.Collections;

public class Blocker : MonoBehaviour
{
	public bool topBlocker;

	void OnTriggerEnter2D (Collider2D  other)
	{		

		if (other.tag == "Obstacle") {
			if(topBlocker){
				GamePanel.instance.GameOver ();
			}
		} else {
			var player = Player.instance;
			if (!topBlocker) {
				player.isGoup = true;
			} else {
				player.isGoup = false;
			}
		}
	}
}
