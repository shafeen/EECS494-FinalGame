using UnityEngine;
using System.Collections;

public class cutScene : MonoBehaviour {
	public enum CUTSCENETYPES {lookAt, timedCut, track};
	public GameObject focusObject;
	public CUTSCENETYPES cutsceneType;
	public float cutsceneLength;
	public int multiplier;

	private GameObject player;
	private GameObject player_cam;
	private bool isColliding;
	private float time;
	private Quaternion focusRotation;
	private Quaternion focusMouselookRotation;


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
		player = GameObject.FindWithTag("Player");
		player_cam = player.transform.FindChild("Player_Cam").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (isColliding) {
			if (cutsceneType == CUTSCENETYPES.track) {
				SetFocusRotation();
			}
			player.transform.rotation = Quaternion.Lerp (player.transform.rotation, focusRotation, multiplier * Time.deltaTime);
			player_cam.transform.rotation = Quaternion.Lerp (player_cam.transform.rotation, focusMouselookRotation, multiplier * Time.deltaTime);
		}
		switch (cutsceneType) {
			case CUTSCENETYPES.lookAt:
				if(Quaternion.Angle(focusRotation, player.transform.rotation) < 5){
					isColliding = false;
					player.GetComponent<EnablePlayerInput>().EnableInput();
				}
				break;

			case CUTSCENETYPES.track:
			if (time > cutsceneLength) {
				isColliding = false;
				player.GetComponent<EnablePlayerInput>().EnableInput();
			}
			break;

			case CUTSCENETYPES.timedCut:
				if (time > cutsceneLength) {
					isColliding = false;
					player.GetComponent<EnablePlayerInput>().EnableInput();
				}
				break;
		}
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player" && focusObject && focusObject.active) {
			SetFocusRotation();

			time = 0;
			isColliding = true;
			player.GetComponent<DisablePlayerInput>().DisableInput();
		}
	}

	void SetFocusRotation() {
		Vector3 relativePlayerPos = new Vector3(focusObject.transform.position.x, 
		                                        player.transform.position.y, 
		                                        focusObject.transform.position.z) - player.transform.position;
		Vector3 relativeMouselookPos = focusObject.transform.position - player_cam.transform.position;
		focusRotation = Quaternion.LookRotation(relativePlayerPos);
		focusMouselookRotation = Quaternion.LookRotation(relativeMouselookPos);
	}
}
