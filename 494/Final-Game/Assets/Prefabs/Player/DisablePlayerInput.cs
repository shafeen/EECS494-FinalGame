using UnityEngine;
using System.Collections;

public class DisablePlayerInput : MonoBehaviour {
	private GameObject player_cam;
	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		player_cam = player.transform.FindChild("Player_Cam").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DisableInput() {
		player.GetComponent<MouseLook>().enabled = false;
		player_cam.GetComponent<MouseLook>().enabled = false;
		player.GetComponent<CharacterMotor>().canControl = false;
		player.GetComponent<FPSInputController>().enabled = false;
		player_cam.GetComponent<HeadBob>().enabled = false;
		player_cam.GetComponent<CheckInspectRange>().enabled = false;
	}
}
