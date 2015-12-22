using UnityEngine;
using System.Collections;

public class SoundsManager : MonoBehaviour {

	static SoundsManager _instance;
	
	public static SoundsManager instance {
		get {
			return _instance;
		}
	}
	void Awake () {
		_instance = this;
	}


	[SerializeField] AudioClip button;
	[SerializeField] AudioClip cancelBtn;

	public void PlaySoundButton(){
		Play (button);
	}
	public void PlayCancelButton(){
		Play (cancelBtn);
	}


	public void Play(AudioClip clip, float volume = 1f) {
		if (Game.instance.BGM) {
			var go = new GameObject ("Sound", typeof(AudioSource));
			go.GetComponent<AudioSource> ().PlayOneShot (clip, volume);
			UnityEngine.Object.Destroy (go, clip.length);
		}
	}
}
