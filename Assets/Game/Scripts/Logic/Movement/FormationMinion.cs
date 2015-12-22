using UnityEngine;
using System.Collections;

public class FormationMinion : MonoBehaviour {

	public Transform followTarget;
	public float smoothTime = 0.5f;
	
	Health followTargetHealth;
	Health myHealth;

	Vector3 offset;
	float currentVelocity = 0;

	// Use this for initialization
	void Start () 
	{
		
		followTargetHealth = followTarget.GetComponent<Health>();
		followTargetHealth.OnDeath.AddListener(OnTargetDeath);
		
		myHealth = GetComponent<Health>();
		myHealth.OnDeath.AddListener(OnMyDeath);
		
		offset = this.transform.position - followTarget.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () 
	{	
		if ( followTarget != null ) {
			var targetPt = followTarget.transform.position + offset;
			var myPt = this.transform.position;
			myPt.x = targetPt.x;
			myPt.y = Mathf.SmoothDamp(myPt.y,targetPt.y,ref currentVelocity,smoothTime);
			this.transform.position = myPt;
		}
	}
	
	public void OnTargetDeath()
	{
		//Die
		myHealth.Kill();
	}
	
	public void OnMyDeath()
	{
	
	}
	
}
