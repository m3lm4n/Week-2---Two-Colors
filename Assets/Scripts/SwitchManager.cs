using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchManager : MonoBehaviour {

	public static string orangeTag = "Orange";
	public static string purpleTag = "Purple";

	private string activeTag = orangeTag;

	private GameObject[] orangeObjects;
	private GameObject[] purpleObjects;

	private PostProcessShader postShader;

	void Start () {
		postShader = GameObject.Find ("Main Camera").GetComponent<PostProcessShader>();

		orangeObjects = GameObject.FindGameObjectsWithTag (orangeTag);
		purpleObjects = GameObject.FindGameObjectsWithTag (purpleTag);

		Hide (purpleTag);
		Show (orangeTag);
	}

	void Update () {
		
	}

	public void Switch() {
		Hide (activeTag);
		activeTag = activeTag == orangeTag ? purpleTag : orangeTag;
		Show (activeTag);
		postShader.switchColor (activeTag);

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
