using UnityEngine;
using System.Collections;

public class PutAwayFlashlight : MonoBehaviour {

	private bool flashlight_is_up = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetButtonDown("B_1") || Input.GetKeyDown(KeyCode.Space)) {
			if (flashlight_is_up) {
				animation.Play("Lower_Flashlight");
				flashlight_is_up = false;
			} else {
				animation.Play("Raise_Flashlight");
				flashlight_is_up = true;
			}
		}

	}
}
