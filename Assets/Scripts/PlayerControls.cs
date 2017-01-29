using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

	private Player player;

	private bool isJumping;

	private void Awake() {
		player = GetComponent<Player> ();
	}

	private void Update (){
		float h = Input.GetAxis ("Horizontal");

		player.Move (h);

		if (Input.GetButtonDown ("Jump") && !isJumping) {
			player.Jump ();
			isJumping = true;
		}

		if (Input.GetButtonUp ("Jump")) {
			player.EndJump ();
			isJumping = false;
		}
	}

}
