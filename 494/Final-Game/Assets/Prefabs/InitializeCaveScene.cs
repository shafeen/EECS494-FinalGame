using UnityEngine;
using System.Collections;

public class InitializeCaveScene : MonoBehaviour {

	private float lookTime = 3.0f;
	private float time = 0.0f;
	private int posMultiplier = 3;
	private int rotMultiplier = 3;
	private bool starting = true;
	private bool done = false;

	private GameObject player;
	private GameObject player_cam;
	private GameObject player_position;

	private GameObject inspectable_drawing;
	private GameObject object_cam;
	private GameObject closet_cam;

	private GameObject inspectable_closet_door;
	private Vector3 closedEulerAngle;
	private float openedEulerAngleY = 60.0f;
	private float turnSpeed = 50.0f;

	//Run as the scene is initializing
	void Awake() {
		player = GameObject.FindWithTag("Player");
		player_cam = player.transform.FindChild("Player_Cam").gameObject;
		player_position = player.transform.FindChild("Player_Cam_Position").gameObject;

		inspectable_drawing = GameObject.Find("Inspectable_Drawing");
		object_cam = inspectable_drawing.transform.FindChild("Object_Cam").gameObject;
		closet_cam = inspectable_drawing.transform.FindChild("Closet_Cam").gameObject;

		inspectable_closet_door = GameObject.Find("Inspectable_Closet_Door");
		closedEulerAngle = inspectable_closet_door.transform.eulerAngles;
	}

	// Use this for initialization
	void Start () {
		// open the closet door for the monster scene
		while((inspectable_closet_door.transform.eulerAngles.y - closedEulerAngle.y) < openedEulerAngleY) {
			inspectable_closet_door.transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
		}

		GameObject.FindWithTag("Monster").animation.Play("Steal Bear");
	}
	
	// Update is called once per frame	
	void Update () {
		if (!done) {

			if (starting) {
				player_cam.transform.position = object_cam.transform.position;
				player_cam.transform.rotation = object_cam.transform.rotation;
				starting = false;
			}

			time += Time.deltaTime;
			if (time > lookTime) {
				player_cam.transform.rotation = Quaternion.Lerp (player_cam.transform.rotation, player_position.transform.rotation, rotMultiplier * Time.deltaTime);
				player_cam.transform.position = Vector3.Lerp (player_cam.transform.position, player_position.transform.position, posMultiplier * Time.deltaTime);
				
				if((player_cam.transform.position - player_position.transform.position).magnitude < 0.01){
					player.GetComponent<EnablePlayerInput>().EnableInput();
					player_cam.transform.position = player_position.transform.position;
					player_cam.transform.rotation = player_position.transform.rotation;
					done = true;
				}
			}
			
			else {
				player.GetComponent<DisablePlayerInput>().DisableInput();
				player_cam.transform.rotation = Quaternion.Lerp (player_cam.transform.rotation, closet_cam.transform.rotation, rotMultiplier * Time.deltaTime);
				player_cam.transform.position = Vector3.Lerp (player_cam.transform.position, closet_cam.transform.position, posMultiplier * Time.deltaTime);
			}
		}
	}
}
