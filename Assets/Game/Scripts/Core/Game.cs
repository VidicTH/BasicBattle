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


	public bool _isPause = false;
	
#region GameValues


#endregion

#region Monobehavior


	void Awake ()
	{
				
		if (_instance != null) {
			Debug.LogError("Multiple Game Instances Exist.");
		} else {
			_instance = this;
			DontDestroyOnLoad(gameObject);
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
