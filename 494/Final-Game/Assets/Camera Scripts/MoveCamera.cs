using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

	public enum TransitionType {
		SCENE_CHANGE,
		INSPECT }

	public TransitionType transition_type;

	public string newLevel;
	private GameObject player_cam;

	private GameObject object_cam;
	private GameObject player;
	private GameObject player_position;
	private float time;
	private bool clicked = false;
	private bool activated = false;

	private int posMultiplier = 3;
	private int rotMultiplier = 3;
	public float lookTime;
	private Vector3 fwd;
	private RaycastHit hit;
	public float activateDistance = 15;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		player_cam = player.transform.FindChild("Player_Cam").gameObject;
		object_cam = transform.FindChild("Object_Cam").gameObject;
		player_position = player.transform.FindChild("Player_Cam_Position").gameObject;
	}

	// Update is called once per frame
	void Update () {

		//Get the click to start things off
		if((Input.GetButtonDown("A_1") || Input.GetMouseButtonDown(0)) && !clicked){
			Debug.Log("Clicking");
			click();
		}

		if (clicked) {
			if (PlayerResponded()) {

				switch (transition_type) {

					case (TransitionType.SCENE_CHANGE): {

						if (Input.GetButtonDown("A_1") || Input.GetMouseButtonDown(0)) {
							if(newLevel!=null) {
								player_cam.GetComponent<HeadBob>().enabled = true;
								Application.LoadLevel(newLevel);
							}
						}

						if (Input.GetButtonDown("B_1") || Input.GetMouseButtonDown(1)) {
							clicked = false;
							player.GetComponent<EnablePlayerInput>().EnableInput();
							player_cam.transform.position = player_position.transform.position;
							player_cam.transform.rotation = player_position.transform.rotation;
						}
						break;
					}


					case (TransitionType.INSPECT): {
						player_cam.transform.rotation = Quaternion.Lerp (player_cam.transform.rotation, player_position.transform.rotation, rotMultiplier * Time.deltaTime);
						player_cam.transform.position = Vector3.Lerp (player_cam.transform.position, player_position.transform.position, posMultiplier * Time.deltaTime);
						
						if((player_cam.transform.position - player_position.transform.position).magnitude < 0.01){
							clicked = false;
							player.GetComponent<EnablePlayerInput>().EnableInput();
							player_cam.transform.position = player_position.transform.position;
							player_cam.transform.rotation = player_position.transform.rotation;
						}
						break;
					}

					default:

						break;

				}

			} else {
//				player_cam.transform.rotation = Quaternion.Lerp (player_cam.transform.rotation, object_cam.transform.rotation, rotMultiplier * Time.deltaTime);
//				player_cam.transform.position = Vector3.Lerp (player_cam.transform.position, object_cam.transform.position, posMultiplier * Time.deltaTime);
			}
		}

	}

	void click() {
		if (transform.FindChild("Object_Highlight").gameObject.GetComponent<Light>().enabled) {
			clicked = true;
			player_position.transform.rotation = player_cam.transform.rotation;
			player.GetComponent<DisablePlayerInput>().DisableInput();
			StartCoroutine("MoveCameraToObject");
		}
	}

	IEnumerator MoveCameraToObject() {
		while ((player_cam.transform.position - object_cam.transform.position).magnitude > 0.05) {
			player_cam.transform.rotation = Quaternion.Lerp (player_cam.transform.rotation, object_cam.transform.rotation, rotMultiplier * Time.deltaTime);
			player_cam.transform.position = Vector3.Lerp (player_cam.transform.position, object_cam.transform.position, posMultiplier * Time.deltaTime);
			yield return null;
		}
	}

	bool PlayerResponded() {

		switch (transition_type) {

		case TransitionType.INSPECT:
			if(Input.GetButtonDown("B_1") || Input.GetMouseButtonDown(1)) {
				return true;
			}
			return false;
			break;

		case TransitionType.SCENE_CHANGE:
			if(Input.GetButtonDown("A_1") || Input.GetButtonDown("B_1")
			    || Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) {
				return true;
			}
			return false;
			break;
		
		default:
			return false;
			break;
		}
	
	}


}
