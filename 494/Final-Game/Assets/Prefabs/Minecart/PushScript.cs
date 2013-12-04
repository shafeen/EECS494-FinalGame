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
	private GameObject handle1;
	private GameObject handle2;

	void Start () {
		player = GameObject.FindWithTag("Player");
		player_cam = player.transform.Find("Player_Cam").gameObject;
		respawn = player.GetComponent<RespawnTimer>();
		wheelTurn = transform.Find("Wheel Container").GetComponent<WheelTurn>();
		handle1 = transform.Find("Handle1").gameObject;
		handle2 = transform.Find("Handle2").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		cartFwd = transform.TransformDirection(Vector3.forward);
		playerFwd = player.transform.TransformDirection(Vector3.forward);
		if(Input.GetButtonDown("A_1") || Input.GetMouseButtonDown(0)) {
			//PUT FLASHLIGHT UP
			if(wheelTurn.isActive()) {
				player_cam.transform.Find("Flashlight").gameObject.GetComponent<PutAwayFlashlight>().RaiseFlashlight();
				transform.Find("Flashlight").active = false;
				player.transform.parent = null;

				player.GetComponent<MouseLook>().sensitivityX = 15.0f;
				player.GetComponent<MouseLook>().sensitivityY = 15.0f;
				player.GetComponent<CharacterMotor>().enabled = true;
				player.GetComponent<CharacterMotor>().canControl = true;

				handle1.transform.Find("HandleCollider1").gameObject.active = true;
				handle2.transform.Find("HandleCollider2").gameObject.active = true;

				wheelTurn.deactivate();
			}
			else {
				attachToCart();
			}
		}
	}
	void attachToCart(){
		if(Physics.Raycast(player.transform.position, playerFwd, out hit, attachRange)) {
			//From the front
			if(hit.collider.gameObject == handle1.transform.Find("HandleCollider1").gameObject) {
				if(Mathf.Abs(Vector3.Angle(playerFwd,cartFwd)-180) < 10){
					//transform.rotation = player.transform.rotation;
					player.transform.parent = transform;
					//PUT FLASHLIGHT DOWN
					player_cam.transform.Find("Flashlight").gameObject.GetComponent<PutAwayFlashlight>().LowerFlashlight();
					transform.Find("Flashlight").active = true;
					handle1.transform.Find("HandleCollider1").gameObject.active = false;
					handle2.transform.Find("HandleCollider2").gameObject.active = false;

					player.GetComponent<MouseLook>().sensitivityX = 0.0f;
					player.GetComponent<MouseLook>().sensitivityY = 0.0f;
					player.GetComponent<CharacterMotor>().enabled = false;
					player.GetComponent<CharacterMotor>().canControl = false;
					wheelTurn.activate(-1);
				}
			}

			//From the back
			else if(hit.collider.gameObject == handle2.transform.Find("HandleCollider2").gameObject) {
				if(Vector3.Angle(playerFwd,cartFwd) < 10){
					//transform.rotation = player.transform.rotation;
					player.transform.parent = transform;
					//PUT FLASHLIGHT DOWN
					player_cam.transform.Find("Flashlight").gameObject.GetComponent<PutAwayFlashlight>().LowerFlashlight();
					transform.Find("Flashlight").active = true;
					handle1.transform.Find("HandleCollider1").gameObject.active = false;
					handle2.transform.Find("HandleCollider2").gameObject.active = false;

					player.GetComponent<MouseLook>().sensitivityX = 0.0f;
					player.GetComponent<MouseLook>().sensitivityY = 0.0f;
					player.GetComponent<CharacterMotor>().enabled = false;
					player.GetComponent<CharacterMotor>().canControl = false;
					wheelTurn.activate(1);
				}
			}
		}
	}
}
