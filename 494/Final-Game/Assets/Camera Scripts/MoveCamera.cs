using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

	public enum TransitionType {
		SCENE_CHANGE,
		INSPECT }

	public TransitionType transition_type;

	public string newLevel;

	private GameObject object_cam;
	private GameObject player;
	private GameObject player_cam;
	private GameObject player_position;
	private float time;
	private bool clicked = false;
	private bool activated = false;

	public int posMultiplier;
	public int rotMultiplier;
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
	}

	// Update is called once per frame
	void Update () {
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
							Application.LoadLevel(newLevel);
						}
						break;
					}
					case (TransitionType.INSPECT): {
						player_cam.transform.rotation = Quaternion.Lerp (player_cam.transform.rotation, player_position.transform.rotation, rotMultiplier * Time.deltaTime);
						player_cam.transform.position = Vector3.Lerp (player_cam.transform.position, player_position.transform.position, posMultiplier * Time.deltaTime);
						
						if((player_cam.transform.position - player_position.transform.position).magnitude < 0.01){
							clicked = false;
							player.GetComponent<MouseLook>().enabled = true;
							player_cam.GetComponent<MouseLook>().enabled = true;
							player.GetComponent<CharacterMotor>().canControl = true;
							player.GetComponent<FPSInputController>().enabled = true;
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
				player.GetComponent<MouseLook>().enabled = false;
				player_cam.GetComponent<MouseLook>().enabled = false;
				player.GetComponent<CharacterMotor>().canControl = false;
				player.GetComponent<FPSInputController>().enabled = false;
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
		}
	}
}
