using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour
{

	public float rotateSpeed = 700f;
	public bool clockwise = true;
	private int coreValue;
	// Update is called once per frame
	void Start ()
	{
		
		if (clockwise) {
			coreValue = -1;
		} else {
			coreValue = 1;
		}

	}

	void Update ()
	{

		if (!Game.instance.isPause) {
			var rot = this.transform.localEulerAngles;
			rot.z += coreValue * rotateSpeed * Time.deltaTime;
			this.transform.localEulerAngles = rot;
		}

	}
}
