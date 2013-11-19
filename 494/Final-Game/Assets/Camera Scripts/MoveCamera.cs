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
	private GameObject object_highlight;
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
		player = GameObject.Find ("Player");
		player_cam = player.transform.FindChild("Player_Cam").gameObject;
		object_cam = transform.FindChild("Object_Cam").gameObject;
		player_position = player.transform.FindChild("Player_Cam_Position").gameObject;
		object_highlight = transform.FindChild("Object_Highlight").gameObject;
	}

	// Update is called once per frame
	void Update () {
		if (activated) {
			object_highlight.GetComponent<Light>().enabled = true;
		} else {
			object_highlight.GetComponent<Light>().enabled = false;
		}

		if(Input.GetButtonDown("A_1") || Input.GetMouseButtonDown(0)){
			Debug.Log("Clicking");
			click();
		}

		if (clicked) {
			time += Time.deltaTime;
			if (time > lookTime) {

				switch (transition_type) {

					case (TransitionType.SCENE_CHANGE): {
						if(newLevel!=null) {
							player_cam.GetComponent<HeadBob>().enabled = true;
							Application.LoadLevel(newLevel);
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

			}

			else {
				player.GetComponent<DisablePlayerInput>().DisableInput();
				player_cam.transform.rotation = Quaternion.Lerp (player_cam.transform.rotation, object_cam.transform.rotation, rotMultiplier * Time.deltaTime);
				player_cam.transform.position = Vector3.Lerp (player_cam.transform.position, object_cam.transform.position, posMultiplier * Time.deltaTime);
			}
		}

		activated = false;
	}

	public void activate() {
		//Use this function to make object glow or change color to indicate that it is selected
		activated = true;
	}

	void click() {
		if (activated) {
			clicked = true;
			time = 0;
			player_position.transform.rotation = player_cam.transform.rotation;
		}
	}
}
