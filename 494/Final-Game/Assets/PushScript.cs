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
		if(wheelTurn.isActive() && (Input.GetButtonDown("B_1")||Input.GetMouseButtonDown(0) || respawn.getTimeLeft() < 3)) {
			wheelTurn.deactivate();
		}
	}
	void OnCollisionStay(){
		if(Physics.Raycast(player.transform.position, playerFwd, out hit, attachRange)) {
			if(hit.collider.gameObject.name == name) {
				if(Vector3.Angle(playerFwd,cartFwd) < 20){
					//audio.Play();
					//audio.loop = true;
					wheelTurn.activate();
				}
			}
		}
	}
}
