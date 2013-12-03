using UnityEngine;
using System.Collections;

public class PutAwayFlashlight : MonoBehaviour {

	private bool flashlight_is_up = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetButtonDown("B_1") || Input.GetKeyDown(KeyCode.E)) {
			if (flashlight_is_up) {
				LowerFlashlight();
			} else {
				RaiseFlashlight();
			}
		}

	}

	public void LowerFlashlight() {
		animation.Play("Lower_Flashlight");
		flashlight_is_up = false;
	}

	public void RaiseFlashlight() {
		animation.Play("Raise_Flashlight");
		flashlight_is_up = true;
	}
}
