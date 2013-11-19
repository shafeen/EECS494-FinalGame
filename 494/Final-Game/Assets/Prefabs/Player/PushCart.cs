using UnityEngine;
using System.Collections;

public class PushCart : MonoBehaviour {
	private bool attached = false;
	private RaycastHit hit;
	private RaycastHit hit2;
	private Vector3 fwd;
	private Vector3 fwdC;
	public float attachRange = 1;
	private GameObject player;
	private GameObject player_cam;
	void Start() {
		player = GameObject.Find("Player");
		player_cam = GameObject.Find("Player/Player_Cam");
	}

	void cartCheck(){
		if(attached){
			print("GOTHEEM3");
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
			//GameObject.FindWithTag("MainCamera").GetComponent<MouseLook>().sensitivityY = 10.0f;
		}
		else if(Physics.Raycast(player.transform.position, fwd, out hit, attachRange)) {
			print("GOTHEEM2");
			if(hit.collider.gameObject.tag == "cart") {
				print("GOTHEEM2.1");
				if(Vector3.Angle(fwd,fwdC) < 5){
					print("GOTHEEM2.2");
					attached = true;
					transform.rotation = player.transform.rotation;
					player.transform.parent = transform;
				}
			}
		}
	}

	void Update(){
		fwd = player.transform.TransformDirection(Vector3.forward);
		fwdC = transform.TransformDirection(Vector3.forward);
		Debug.DrawRay(player.transform.position, fwd, Color.red, 0.0f, false);
		Debug.DrawRay(transform.position, fwdC*20, Color.red, 0.0f, false);
		if(Input.GetButtonDown("A_1") || Input.GetMouseButtonDown(0)) {
			print("GOTHEEM1");
			cartCheck();
		}
		if(attached){
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