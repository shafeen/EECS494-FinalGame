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
		player = GameObject.FindWithTag("Player");
		player_cam = player.Find("Player_Cam");
		respawn = player.GetComponent<RespawnTimer>();
		wheelTurn = transform.Find("Wheel Container").GetComponent<WheelTurn>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		cartFwd = transform.TransformDirection(Vector3.forward);
		playerFwd = player.transform.TransformDirection(Vector3.forward);
		if(wheelTurn.isActive() && (Input.GetButtonDown("B_1") || Input.GetMouseButtonDown(1) || respawn.getTimeLeft() < 3)) {
			//PUT FLASHLIGHT UP

			player.transform.parent = null;

			player.GetComponent<MouseLook>().sensitivityX = 15.0f;
			player.GetComponent<MouseLook>().sensitivityY = 15.0f;
			player.GetComponent<CharacterMotor>().enabled = true;
			player.GetComponent<CharacterMotor>().canControl = true;

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
					//PUT FLASHLIGHT DOWN


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
