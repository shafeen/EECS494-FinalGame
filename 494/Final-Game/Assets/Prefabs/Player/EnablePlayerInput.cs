using UnityEngine;
using System.Collections;

public class EnablePlayerInput : MonoBehaviour {
	private GameObject player_cam;
	private GameObject player;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		player_cam = player.transform.FindChild("Player_Cam").gameObject;
	}

	public void EnableInput() {
		Debug.Log("Enable Input");
		player.GetComponent<MouseLook>().enabled = true;
		player_cam.GetComponent<MouseLook>().enabled = true;
		player.GetComponent<CharacterMotor>().canControl = true;
		player.GetComponent<FPSInputController>().enabled = true;
		player_cam.GetComponent<HeadBob>().enabled = true;
		player_cam.GetComponent<CheckInspectRange>().enabled = true;
	}
}
