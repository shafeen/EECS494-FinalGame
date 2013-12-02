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
	
	// Update is called once per frame
	void Update () {
	
	}

	public void EnableInput() {
		player.GetComponent<MouseLook>().enabled = true;
		player_cam.GetComponent<MouseLook>().enabled = true;
		player.GetComponent<CharacterMotor>().canControl = true;
		player.GetComponent<FPSInputController>().enabled = true;
		player_cam.GetComponent<HeadBob>().enabled = true;
	}
}
