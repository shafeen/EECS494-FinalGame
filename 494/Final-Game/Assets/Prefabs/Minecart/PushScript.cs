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
		player_cam = player.transform.Find("Player_Cam").gameObject;
		respawn = player.GetComponent<RespawnTimer>();
		wheelTurn = transform.Find("Wheel Container").GetComponent<WheelTurn>();
	}
	
	// Update is called once per frame
	void Update () {
		cartFwd = transform.TransformDirection(Vector3.forward);
		playerFwd = player.transform.TransformDirection(Vector3.forward);
		if(Input.GetButtonDown("A_1") || Input.GetMouseButtonDown(0)) {
			//PUT FLASHLIGHT UP
			if(wheelTurn.isActive()) {
				player_cam.transform.Find("Flashlight").gameObject.GetComponent<PutAwayFlashlight>().RaiseFlashlight();
				player.transform.parent = null;

				player.GetComponent<MouseLook>().sensitivityX = 15.0f;
				player.GetComponent<MouseLook>().sensitivityY = 15.0f;
				player.GetComponent<CharacterMotor>().enabled = true;
				player.GetComponent<CharacterMotor>().canControl = true;

				wheelTurn.deactivate();
			}
			else {
				attachToCart();
			}

		}
	}
	void attachToCart(){
		if(Physics.Raycast(player.transform.position, playerFwd, out hit, attachRange)) {
			if(hit.collider.gameObject.name == name) {
				if(Vector3.Angle(playerFwd,cartFwd) < 20){
					transform.rotation = player.transform.rotation;
					player.transform.parent = transform;
					//PUT FLASHLIGHT DOWN
					player_cam.transform.Find("Flashlight").gameObject.GetComponent<PutAwayFlashlight>().LowerFlashlight();


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
