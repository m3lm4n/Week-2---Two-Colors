using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostProcessShader : MonoBehaviour {

	public Material postProcessMaterial;
	public GameObject player;

	private Vector4 orangeColor = new Vector4(243f/255f, 66f/255f, 19f/255f, 0.3f);
	private Vector4 purpleColor = new Vector4 (74f / 255f, 52f / 255f, 125f / 255f, 1f);

	private Vector4 activeColor;

	private Camera cameraComponent;

	// Use this for initialization
	void Start () {
		cameraComponent = GetComponent<Camera> ();
		activeColor = orangeColor;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void switchColor(string colorTag) {
		activeColor = colorTag == SwitchManager.orangeTag ? orangeColor : purpleColor;
	}

	void OnRenderImage (RenderTexture source, RenderTexture destination)
	{
		postProcessMaterial.SetVector ("_Color", activeColor);
		postProcessMaterial.SetVector ("_Source", cameraComponent.WorldToScreenPoint(player.transform.position));
		Graphics.Blit (source, destination, postProcessMaterial);
	}
}
