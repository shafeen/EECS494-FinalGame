using UnityEngine;
using System.Collections;

public class PushScript : MonoBehaviour {
	public float attachRange = 1;
	private GameObject player;
	private GameObject player_cam;
	private RaycastHit hit;
	private Vector3 playerFwd;
	private Vector3 cartFwd;
	private WheelTurn wheelTurn;
	private RespawnTimer respawn;

	void Start () {
		player = GameObject.Find("Player");
		player_cam = GameObject.Find("Player/Player_Cam");
		respawn = player.GetComponent<RespawnTimer>();
		wheelTurn = transform.Find("Wheel Container").GetComponent<WheelTurn>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		cartFwd = transform.TransformDirection(Vector3.forward);
		playerFwd = player.transform.TransformDirection(Vector3.forward);
		if(wheelTurn.isActive() && (Input.GetButtonDown("B_1") || Input.GetMouseButtonDown(1) || respawn.getTimeLeft() < 3)) {
			GameObject.Find("Player/Player_Cam/Flashlight").GetComponent<Light>().enabled = true;
			GameObject.Find("Player/Player_Cam/Flashlight").GetComponent<FlashlightRaycast>().enabled = true;
			GameObject.Find("Player/Player_Cam/Flashlight/Wide_light").GetComponent<Light>().enabled = true;


			player.transform.parent = null;

			player.GetComponent<MouseLook>().sensitivityX = 15.0f;
			player.GetComponent<MouseLook>().sensitivityY = 15.0f;
			player.GetComponent<CharacterMotor>().enabled = true;
			player.GetComponent<CharacterMotor>().canControl = true;
			player_cam.transform.rotation = player.transform.rotation;

			wheelTurn.deactivate();

		}
		if(Input.GetMouseButtonDown(0) || Input.GetButtonDown("A_1") && !wheelTurn.isActive()) {
			attachToCart ();
		}
	}
	void attachToCart(){
		if(Physics.Raycast(player.transform.position, playerFwd, out hit, attachRange)) {
			if(hit.collider.gameObject.name == name) {
				if(Vector3.Angle(playerFwd,cartFwd) < 20){
					transform.rotation = player.transform.rotation;
					player.transform.parent = transform;
					GameObject.Find("Player/Player_Cam/Flashlight").GetComponent<Light>().enabled = false;
					GameObject.Find("Player/Player_Cam/Flashlight").GetComponent<FlashlightRaycast>().enabled = false;
					GameObject.Find("Player/Player_Cam/Flashlight/Wide_light").GetComponent<Light>().enabled = false;


					player.GetComponent<MouseLook>().sensitivityX = 0.0f;
					player.GetComponent<MouseLook>().sensitivityY = 0.0f;
					player.GetComponent<CharacterMotor>().enabled = false;
					player.GetComponent<CharacterMotor>().canControl = false;
					wheelTurn.activate();
				}
			}
		}
	}
}
