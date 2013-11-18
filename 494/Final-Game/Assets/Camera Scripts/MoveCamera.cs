using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {
	public GameObject cam;
	public bool xbox = false;
	private float time;
	public GameObject playerCam;
	public int posMultiplier;
	public int rotMultiplier;
	public float lookTime;
	private bool clicked = false;
	public GameObject tempObj;
	private MouseLook mouseInputY;
	private CharacterMotor charMotorInput;
	private MouseLook mouseInputX;
	private Vector3 fwd;
	private RaycastHit hit;
	public float activateDistance = 15;
	// Use this for initialization
	void Start () {
		mouseInputX = GameObject.Find ("Player").GetComponent<MouseLook>();
		mouseInputY = GameObject.Find ("Main Camera").GetComponent<MouseLook>();
		charMotorInput = GameObject.Find("Player").GetComponent<CharacterMotor>();
	}

	// Update is called once per frame
	void Update () {
		fwd = playerCam.transform.TransformDirection(Vector3.forward);
		if((xbox) ? Input.GetButtonDown("A_1") : Input.GetMouseButtonDown(0)){
			Physics.Raycast(playerCam.transform.position, fwd, out hit, activateDistance);
			if(hit.collider.tag == "focusObject"){
				activate();
			}
		}
		time += Time.deltaTime;
		if (clicked) {
			if (time > lookTime) {
				playerCam.transform.rotation = Quaternion.Lerp (playerCam.transform.rotation, tempObj.transform.rotation, rotMultiplier * Time.deltaTime);
				playerCam.transform.position = Vector3.Lerp (playerCam.transform.position, tempObj.transform.position, posMultiplier * Time.deltaTime);
				if((playerCam.transform.position - tempObj.transform.position).magnitude < 0.001){
					clicked = false;
					mouseInputX.enabled = true;
					mouseInputY.enabled = true;
					charMotorInput.canControl = true;
					playerCam.transform.position = tempObj.transform.position;
					playerCam.transform.rotation = tempObj.transform.rotation;
				}
			}

			else {
				mouseInputY.enabled = false;
				mouseInputX.enabled = false;
				charMotorInput.canControl = false;
				playerCam.transform.rotation = Quaternion.Lerp (playerCam.transform.rotation, cam.transform.rotation, rotMultiplier * Time.deltaTime);
				playerCam.transform.position = Vector3.Lerp (playerCam.transform.position, cam.transform.position, posMultiplier * Time.deltaTime);
			}
		}
	}
	void activate() {
		clicked = true;
		time = 0;
		tempObj.transform.position = playerCam.transform.position;
		tempObj.transform.rotation = playerCam.transform.rotation;
	}
}
