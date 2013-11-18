using UnityEngine;
using System.Collections;

public class cutScene : MonoBehaviour {
	public enum CUTSCENETYPES {lookAt, timedCut};
	private Transform target;
	public int multiplier;
	public float cutsceneLength;
	public GameObject focusObject;
	private Transform player;
	private bool isColliding;
	private float time;
	private Quaternion focusRotation;
	private CharacterMotor charMotorInput;
	private MouseLook mouseInputX;
	private MouseLook mouseInputY;
	public CUTSCENETYPES cutsceneType;

	// Use this for initialization
	void Start () {
		isColliding = false;
		mouseInputX = GameObject.Find ("Player").GetComponent<MouseLook>();
		mouseInputY = GameObject.Find ("Main Camera").GetComponent<MouseLook>();
		charMotorInput = GameObject.Find("Player").GetComponent<CharacterMotor>();
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (isColliding) {
			player.rotation = Quaternion.Lerp (player.rotation, focusRotation, multiplier * Time.deltaTime);
		}
		switch (cutsceneType) {
			case CUTSCENETYPES.lookAt:
				if(Quaternion.Angle(focusRotation, player.rotation) < 15){
					isColliding = false;
					charMotorInput.canControl = true;
					mouseInputX.enabled = true;
					mouseInputY.enabled = true;
				}
				break;
			case CUTSCENETYPES.timedCut:
				if (time > cutsceneLength) {
					isColliding = false;
					charMotorInput.canControl = true;
					mouseInputX.enabled = true;
					mouseInputY.enabled = true;
				}
				break;
		}
	}
	void OnTriggerEnter(Collider other){
		target = focusObject.transform;
		time = 0;
		player = GameObject.Find("Player").transform;
		Vector3 relativePos = target.position - player.position;
		focusRotation = Quaternion.LookRotation(relativePos);
		isColliding = true;
		charMotorInput.canControl = false;
		mouseInputX.enabled = false;
		mouseInputY.enabled = false;
	}
}
