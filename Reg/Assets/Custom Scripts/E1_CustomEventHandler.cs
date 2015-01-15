/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Qualcomm Connected Experiences, Inc.
==============================================================================*/

using UnityEngine;
using System.Collections;

/// <summary>
/// A custom handler that implements the ITrackableEventHandler interface.
/// </summary>
public class E1_CustomEventHandler : MonoBehaviour,
ITrackableEventHandler
{
	#region PRIVATE_MEMBER_VARIABLES
	
	private TrackableBehaviour mTrackableBehaviour;
	
	#endregion // PRIVATE_MEMBER_VARIABLES
	
	public GameObject letrero;
	public GameObject error_canvas;
	public GameObject start_canvas;
	public GameObject camara;
	
	private bool flag;
	
	#region UNTIY_MONOBEHAVIOUR_METHODS
	
	void Start()
	{
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
		letrero.SetActive (false);
		error_canvas.SetActive (false);
		StartCoroutine (start_message ());
		
		
		flag = true;
	}
	
	void Update(){
		letrero.transform.LookAt (camara.transform.position);
	}
	
	IEnumerator start_message(){
		yield return new WaitForSeconds(2.0f);
		start_canvas.SetActive (false);
		flag = false;
		
	}
	
	#endregion // UNTIY_MONOBEHAVIOUR_METHODS
	
	
	
	#region PUBLIC_METHODS
	
	/// <summary>
	/// Implementation of the ITrackableEventHandler function called when the
	/// tracking state changes.
	/// </summary>
	public void OnTrackableStateChanged(
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
		    newStatus == TrackableBehaviour.Status.TRACKED ||
		    newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			OnTrackingFound();
		}
		else
		{
			OnTrackingLost();
		}
		Debug.Log ("Trakeando con swagtl");
	}
	
	#endregion // PUBLIC_METHODS
	
	
	
	#region PRIVATE_METHODS
	
	
	private void OnTrackingFound()
	{
		Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
		Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
		
		// Enable rendering:
		foreach (Renderer component in rendererComponents)
		{
			component.enabled = true;
		}
		
		// Enable colliders:
		foreach (Collider component in colliderComponents)
		{
			component.enabled = true;
		}
		
		//Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found con swag");
		letrero.SetActive (true);
		
		
		
		error_canvas.SetActive (false);
		
		letrero.transform.LookAt (camara.transform.position);
	}
	
	
	private void OnTrackingLost()
	{
		Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
		Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);
		
		// Disable rendering:
		foreach (Renderer component in rendererComponents)
		{
			component.enabled = false;
		}
		
		// Disable colliders:
		foreach (Collider component in colliderComponents)
		{
			component.enabled = false;
		}
		
		//Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost sin swag");
		letrero.SetActive (false);
		Debug.Log ("Activando canvas de error");
		if (flag == false) {
			error_canvas.SetActive (true);
		}
		
		
	}
	
	#endregion // PRIVATE_METHODS
}
