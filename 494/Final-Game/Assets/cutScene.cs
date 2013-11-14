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
	private FPSInputController fpsInput;
	private MouseLook mouseInput;
	public CUTSCENETYPES cutsceneType;

	// Use this for initialization
	void Start () {
		isColliding = false;
		fpsInput = GameObject.Find ("Player").GetComponent<FPSInputController>();
		mouseInput = GameObject.Find ("Player").GetComponent<MouseLook>();

	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (isColliding) {
			player.rotation = Quaternion.Lerp (player.rotation, focusRotation, multiplier * Time.deltaTime);
		}
		switch (cutsceneType) {
			case CUTSCENETYPES.lookAt:
				if(Quaternion.Angle(focusRotation, player.rotation) < 5){
					isColliding = false;
					mouseInput.enable = true;
					fpsInput.enable = true;
				}
				break;
			case CUTSCENETYPES.timedCut:
				if (time > cutsceneLength) {
					isColliding = false;
					mouseInput.enable = true;
					fpsInput.enable = true;
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
		mouseInput.enable = false;
		fpsInput.enable = false;
	}
}
