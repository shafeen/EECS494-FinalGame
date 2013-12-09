using UnityEngine;
using System.Collections;

public class DisablePlayerInput : MonoBehaviour {
	private GameObject player_cam;
	private GameObject player;

	// Use this for initialization
	void Start () {
//		player = GameObject.FindWithTag("Player");
//		player_cam = player.transform.FindChild("Player_Cam").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DisableInput() {
		Debug.Log("Disable Input");
		gameObject.GetComponent<MouseLook>().enabled = false;
		transform.Find("Player_Cam").gameObject.GetComponent<MouseLook>().enabled = false;
		gameObject.GetComponent<CharacterMotor>().canControl = false;
		gameObject.GetComponent<FPSInputController>().enabled = false;
		transform.Find("Player_Cam").gameObject.GetComponent<HeadBob>().enabled = false;
		transform.Find("Player_Cam").gameObject.GetComponent<CheckInspectRange>().enabled = false;
	}
}
