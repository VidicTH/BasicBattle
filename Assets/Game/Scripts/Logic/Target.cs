using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Target : MonoBehaviour {

	static List<Target> _targets = new List<Target>();
	public static List<Target> GetTargets() {
		return _targets;
	}
	
	[SerializeField] bool targetable = true;
	public bool IsTargetable {
		get {
			return targetable;
		}
		set {
			
			targetable = value;
			
			if ( value ) {
				if ( gameObject.activeSelf && this.enabled ) {
					AddToList();
				}
			} else {
				RemoveFromList();
			}
			
		}
		
	}
	
	public delegate void TargetDelegate(Target Target);
	public event TargetDelegate OnTargetabilityChanged;
	
	bool isListed = false;
	void AddToList()
	{
		if ( !isListed ) {		
			_targets.Add(this);
			isListed = true;
			if ( OnTargetabilityChanged != null ) {
				OnTargetabilityChanged(this);
			}
		}
	}
	
	void RemoveFromList()
	{
		if ( isListed ) {
			_targets.Remove(this);
			isListed = false;
			if ( OnTargetabilityChanged != null ) {
				OnTargetabilityChanged(this);
			}
		}
	}

#region Monobehavior
	// Use this for initialization
	void Start () {
		if ( targetable ) {
			AddToList();
		}
	}
	
	void OnDestroy()
	{
		targetable = false;
		RemoveFromList();
	}
	
	void OnEnable() {
		if ( targetable ) {
			AddToList();
		}
	}
	
	void OnDisable() {
		if ( targetable ) {
			RemoveFromList();
		}
	}
	
#endregion
	
}
