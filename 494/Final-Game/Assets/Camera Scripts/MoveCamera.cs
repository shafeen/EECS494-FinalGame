using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

	public GameObject cam;
	public bool xbox = false;

	private GameObject object_cam;
	private Transform player_position;

	private float time;
	private GameObject player;
	private GameObject player_cam;

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
//		mouseInputX = GameObject.Find ("Player").GetComponent<MouseLook>();
//		mouseInputY = GameObject.Find ("Main Camera").GetComponent<MouseLook>();
//		charMotorInput = GameObject.Find("Player").GetComponent<CharacterMotor>();
		player = GameObject.Find ("Player");
		player_cam = player.transform.FindChild("Player_Cam").gameObject;
		object_cam = transform.FindChild("Object_Cam").gameObject;
		player_position = player.transform.FindChild("Player_Cam").gameObject.transform;
	}

	// Update is called once per frame
	void Update () {
		fwd = player_cam.transform.forward;
		Debug.DrawRay(player_cam.transform.position, 15*fwd, Color.red, 0.0f, false);
		if((xbox) ? Input.GetButtonDown("A_1") : Input.GetMouseButtonDown(0)){
			Physics.Raycast(player_cam.transform.position, fwd, out hit, activateDistance);
			if(hit.collider.tag == "focusObject"){
				activate();
			}
		}
		if (clicked) {
			time += Time.deltaTime;
			if (time > lookTime) {
				player_cam.transform.rotation = Quaternion.Lerp (player_cam.transform.rotation, tempObj.transform.rotation, rotMultiplier * Time.deltaTime);
				player_cam.transform.position = Vector3.Lerp (player_cam.transform.position, tempObj.transform.position, posMultiplier * Time.deltaTime);
				print((player_cam.transform.position - tempObj.transform.position).magnitude);
				if((player_cam.transform.position - tempObj.transform.position).magnitude < 1){
					clicked = false;
					player.GetComponent<MouseLook>().enabled = true;
					player_cam.GetComponent<MouseLook>().enabled = true;
					player.GetComponent<CharacterMotor>().canControl = true;
					player.GetComponent<FPSInputController>().enabled = true;
					player_cam.transform.position = tempObj.transform.position;
					player_cam.transform.rotation = tempObj.transform.rotation;
				}
			}

			else {
				player.GetComponent<MouseLook>().enabled = false;
				player_cam.GetComponent<MouseLook>().enabled = false;
				player.GetComponent<CharacterMotor>().canControl = false;
				player.GetComponent<FPSInputController>().enabled = false;
				player_cam.transform.rotation = Quaternion.Lerp (player_cam.transform.rotation, object_cam.transform.rotation, rotMultiplier * Time.deltaTime);
				player_cam.transform.position = Vector3.Lerp (player_cam.transform.position, object_cam.transform.position, posMultiplier * Time.deltaTime);
			}
		}
	}
	void activate() {
		clicked = true;
		tempObj = new GameObject();
		tempObj.transform.position = player.transform.position;
		tempObj.transform.rotation = player.transform.rotation;
		time = 0;
	}
}
