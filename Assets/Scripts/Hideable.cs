using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hideable : MonoBehaviour {

	private SpriteRenderer spriteRenderer;
	private BoxCollider2D boxCollider;

	private float hiddenAlpha = 0.2f;
	private float shownAlpha = 1f;

	void Awake() {
		spriteRenderer = GetComponent<SpriteRenderer> ();
		boxCollider = GetComponent<BoxCollider2D> ();
	}

	public void Hide() {
		Color tmp = spriteRenderer.color;
		tmp.a = hiddenAlpha;
		spriteRenderer.color = tmp;
		boxCollider.enabled = false;
	}

	public void Show() {
		Color tmp = spriteRenderer.color;
		tmp.a = shownAlpha;
		spriteRenderer.color = tmp;
		boxCollider.enabled = true;
	}
}
