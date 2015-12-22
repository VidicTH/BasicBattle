using UnityEngine;
using System.Collections;

public class PlaySoundButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnClick(){
		SoundsManager.instance.PlaySoundButton ();
	}
}
