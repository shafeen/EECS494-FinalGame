using UnityEngine;
using System.Collections;

public class PushCart : MonoBehaviour {
	public bool attached = false;
	private RaycastHit hit;
	private RaycastHit hit2;
	private Vector3 fwd;
	private Vector3 fwdC;
	public float attachRange = 1;
	private GameObject player;
	private GameObject player_cam;
	private RespawnTimer respawn;
	void Start() {
		player = GameObject.Find("Player");
		player_cam = GameObject.Find("Player/Player_Cam");
		respawn = player.GetComponent<RespawnTimer>();
	}

	void cartCheck(){
		if(attached){
			//unattaching
			GameObject.Find("Player/Player_Cam/Flashlight").GetComponent<Light>().enabled = true;
			//GetComponent<SFXFadeInOut>().StopSFX = true;
			//audio.Stop();
			attached = false;
			player.transform.parent = null;
			GetComponent<MouseLook>().enabled = false;
			GetComponent<CharacterMotor>().enabled = false;
			GetComponent<CharacterMotor>().canControl = false;
			player.GetComponent<MouseLook>().sensitivityX = 15.0f;
			player.GetComponent<MouseLook>().sensitivityY = 15.0f;
			player.GetComponent<CharacterMotor>().enabled = true;
			player.GetComponent<CharacterMotor>().canControl = true;
			player_cam.GetComponent<MouseLook>().sensitivityX = 10.0f;
		}
		else if(Physics.Raycast(player.transform.position, fwd, out hit, attachRange)) {
			if(hit.collider.gameObject.name == "Minecart") {
				if(Vector3.Angle(fwd,fwdC) < 15){
					//attaching
					attached = true;
					//audio.Play();
					//audio.loop = true;
					transform.rotation = player.transform.rotation;
					player.transform.parent = transform;
				}
			}
		}
	}

	void Update(){
		if(attached && respawn.timeLeft < 3){
			cartCheck ();
		}
		fwd = player.transform.TransformDirection(Vector3.forward);
		fwdC = transform.TransformDirection(Vector3.forward);
		//Debug.DrawRay(transform.position,fwdC*5, Color.red, 0.0f, false);
		if(Input.GetButtonDown("A_1") || Input.GetMouseButtonDown(0)) {
			cartCheck();
		}
		if(attached){
			//GetComponent<SFXFadeInOut>().StartSFX = true;
			GameObject.Find("Player/Player_Cam/Flashlight").GetComponent<Light>().enabled = false;

			GetComponent<MouseLook>().enabled = true;
			GetComponent<CharacterMotor>().enabled = true;
			GetComponent<CharacterMotor>().canControl = true;
			player.GetComponent<MouseLook>().sensitivityX = 0.0f;
			player.GetComponent<MouseLook>().sensitivityY = 0.0f;
			player.GetComponent<CharacterMotor>().enabled = false;
			player.GetComponent<CharacterMotor>().canControl = false;
			player_cam.GetComponent<MouseLook>().sensitivityX = 0.0f;
			//GameObject.FindWithTag("MainCamera").GetComponent<MouseLook>().sensitivityY = 0.0f;
		}
	}

}