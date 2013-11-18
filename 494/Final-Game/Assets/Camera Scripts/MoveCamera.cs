using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {
//	public GameObject cam;
//	private float time;
//	public GameObject playerCam;
//	public int posMultiplier;
//	public int rotMultiplier;
//	public float lookTime;
//	private bool clicked = false;
//	public GameObject tempObj;
//	private MouseLook mouseInputY;
//	private CharacterMotor charMotorInput;
//	private MouseLook mouseInputX;
	private GameObject object_cam;
	private GameObject player_position;
	private bool clicked = false;
	private float time;
	private GameObject player;
	private GameObject player_cam;

	public int posMultiplier;
	public int rotMultiplier;
	public float lookTime;


	// Use this for initialization
	void Start () {
//		mouseInputX = GameObject.Find ("Player").GetComponent<MouseLook>();
//		mouseInputY = GameObject.Find ("Main Camera").GetComponent<MouseLook>();
//		charMotorInput = GameObject.Find("Player").GetComponent<CharacterMotor>();
		player = GameObject.Find ("Player");
		player_cam = player.transform.FindChild("Player_Cam").gameObject;
		object_cam = transform.FindChild("Object_Cam").gameObject;
		player_position = player.transform.FindChild("Player_Cam_Position").gameObject;
	}

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (clicked) {
			if (time > lookTime) {
				player_cam.transform.rotation = Quaternion.Lerp (player_cam.transform.rotation, player_position.transform.rotation, rotMultiplier * Time.deltaTime);
				player_cam.transform.position = Vector3.Lerp (player_cam.transform.position, player_position.transform.position, posMultiplier * Time.deltaTime);
				if((player_cam.transform.position - player_position.transform.position).magnitude < 0.001){
					clicked = false;
					player.GetComponent<MouseLook>().enabled = true;
					player_cam.GetComponent<MouseLook>().enabled = true;
					player.GetComponent<CharacterMotor>().canControl = true;
					player.GetComponent<FPSInputController>().enabled = true;
					player_cam.transform.position = player_position.transform.position;
					player_cam.transform.rotation = player_position.transform.rotation;
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

	void OnMouseDown() {
		clicked = true;
		time = 0;
	}
}
