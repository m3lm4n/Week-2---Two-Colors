using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchManager : MonoBehaviour {

	private static string orangeTag = "Orange";
	private static string purpleTag = "Purple";

	private string activeTag = orangeTag;

	private GameObject[] orangeObjects;
	private GameObject[] purpleObjects;

	void Start () {
		orangeObjects = GameObject.FindGameObjectsWithTag (orangeTag);
		purpleObjects = GameObject.FindGameObjectsWithTag (purpleTag);
	}

	void Update () {
		
	}

	public void Switch() {
		Hide (activeTag);
		activeTag = activeTag == orangeTag ? purpleTag : orangeTag;
		Show (activeTag);
	}

	private void Hide(string tag) {
		GameObject[] toHide = tag == orangeTag ? orangeObjects : purpleObjects;
		foreach(GameObject objToHide in toHide) {
			objToHide.GetComponent<Hideable> ().Hide ();
		}
	}

	private void Show(string tag) {
		GameObject[] toShow = tag == orangeTag ? orangeObjects : purpleObjects;
		foreach(GameObject objToShow in toShow) {
			objToShow.GetComponent<Hideable> ().Show ();
		}
	}
}
