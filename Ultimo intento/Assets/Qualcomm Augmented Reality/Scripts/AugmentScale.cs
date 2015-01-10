using UnityEngine;
using System.Collections;

public class AugmentScale : MonoBehaviour {


	public void scaleUp() {
		
		TrackableBehaviour[] trackables = FindObjectsOfType(typeof(TrackableBehaviour)) as TrackableBehaviour[];
		
		foreach (var tr in trackables) {
			
			if (tr.transform.childCount > 0) {
				
				Transform augmentation = tr.transform.GetChild(0);
				Vector3 scale = augmentation.localScale;
				augmentation.localScale = 1.5f * scale;
			}
		}
	}
}
