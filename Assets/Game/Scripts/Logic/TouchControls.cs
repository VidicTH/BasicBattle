using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class TouchControls : MonoBehaviour {

	public static bool tEnabled = true;
	
	public float swipeDistance = 50f;
	public float tapTime = 0.1f;
		
	public UnityEvent OnTouchDown;
	public UnityEvent OnTouchUp;
	public UnityEvent OnSwipe;
	public UnityEvent OnTap;
	
	Vector3 touchStart = Vector3.zero;
	float touchTime = 0;
	
	// Use this for initialization
	void Start() 
	{
		tEnabled = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if ( TouchControls.tEnabled ) {
		
			if ( Input.GetMouseButtonDown(0) )
			{
				touchStart = Input.mousePosition;
				touchTime = 0;
				
				this.OnTouchDown.Invoke();
			
			}	
			else if ( Input.GetMouseButtonUp(0) )
			{
				
				this.OnTouchUp.Invoke();
				
				//Check for a swipe
				var touchDelta = (Input.mousePosition - touchStart).magnitude;
				if ( touchDelta >= swipeDistance )
				{
					this.OnSwipe.Invoke(); 
				}
				
				if ( touchTime <= tapTime )
				{
					this.OnTap.Invoke();
				}
				
			}
			else if ( Input.GetMouseButton(0) )
			{
				touchTime += Time.deltaTime;
			}
		
		}
		
	}
	
}
