using UnityEngine;
using System.Collections;

public class cutScene : MonoBehaviour {
	public enum CUTSCENETYPES {lookAt, timedCut};
	public GameObject focusObject;
	public CUTSCENETYPES cutsceneType;
	public float cutsceneLength;
	public int multiplier;

	private GameObject player;
	private GameObject player_cam;
	private bool isColliding;
	private float time;
	private Quaternion focusRotation;


//	private Transform target;
//	public float cutsceneLength;
//	public GameObject focusObject;
//	private Transform player;
//	private bool isColliding;
//	private float time;
//	private Quaternion focusRotation;
//	private CharacterMotor charMotorInput;
//	private MouseLook mouseInputX;
//	private MouseLook mouseInputY;

	// Use this for initialization
	void Start () {
		isColliding = false;
		player = GameObject.Find("Player");
		player_cam = player.transform.FindChild("Player_Cam").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (isColliding) {
			player.transform.rotation = Quaternion.Lerp (player.transform.rotation, focusRotation, multiplier * Time.deltaTime);
		}
		switch (cutsceneType) {
			case CUTSCENETYPES.lookAt:
				if(Quaternion.Angle(focusRotation, player.transform.rotation) < 5){
					isColliding = false;
					player.GetComponent<MouseLook>().enabled = true;
					player_cam.GetComponent<MouseLook>().enabled = true;
					player.GetComponent<CharacterMotor>().canControl = true;
					player.GetComponent<FPSInputController>().enabled = true;
				}
				break;
			case CUTSCENETYPES.timedCut:
				if (time > cutsceneLength) {
					isColliding = false;
					player.GetComponent<MouseLook>().enabled = true;
					player_cam.GetComponent<MouseLook>().enabled = true;
					player.GetComponent<CharacterMotor>().canControl = true;
					player.GetComponent<FPSInputController>().enabled = true;
				}
				break;
		}
	}
	void OnTriggerEnter(Collider other){
		Vector3 relativePos = focusObject.transform.position - player.transform.position;
		relativePos.y = player.transform.position.y;
		focusRotation = Quaternion.LookRotation(relativePos);

		time = 0;
		isColliding = true;
		player.GetComponent<MouseLook>().enabled = false;
		player_cam.GetComponent<MouseLook>().enabled = false;
		player.GetComponent<CharacterMotor>().canControl = false;
		player.GetComponent<FPSInputController>().enabled = false;
	}
}
