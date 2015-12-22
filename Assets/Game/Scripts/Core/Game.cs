using UnityEngine;
using System.Collections;
using System;

/*
 *	This class is for holding game state across scenes
 */
public class Game : MonoBehaviour
{

	static Game _instance;

	public static Game instance {
		get {
			return _instance;
		}
	}




	
#region GameValues
	private bool _isPause = false;
	public bool isPause{
		get {
			return _isPause;
		}
		set {
			_isPause=value;
		}
	}
	public bool BGM {
		get{
			if(PlayerPrefs.GetInt("BGM")==0)
				return true;
			return false;
		}
		set{
			if(value==true){
				PlayerPrefs.SetInt("BGM",0);
			}
			else{
				PlayerPrefs.SetInt("BGM",1);
			}
		}
	}

#endregion

#region Monobehavior


	void Awake ()
	{
				
		if (_instance != null) {
			Debug.LogError("Multiple Game Instances Exist.");
		} else {
			_instance = this;
		}
		_isPause = true;
		
	}
	
	void Start()
	{	

	}

	void Update()
	{

	}


	void OnDestroy()
	{
	
	}

	void OnApplicationQuit()
	{

	}

	void OnApplicationPause(bool pauseStatus)
	{
	
	}
	
	void OnApplicationFocus(bool focusStatus)
	{
	
	}


#endregion

}
