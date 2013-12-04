using UnityEngine;
using System.Collections;

public class MoveClosetDoor : MonoBehaviour {

	private GameObject player;
	private Vector3 playerFwd;
	private Vector3 closedEulerAngle;

	private float hitRange = 3.0f;
	private RaycastHit hit;
	private bool open = false;

	private float openedEulerAngleY = 125.0f;
	private float turnSpeed = 50.0f;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindWithTag("Player");
		// angle of the door initially when closed
		closedEulerAngle = transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () 
	{
		playerFwd = player.transform.forward;

		moveDoor();

		// open the door if not opened all the way
		if(open) {
			if((transform.eulerAngles.y - closedEulerAngle.y) < openedEulerAngleY) {
				transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
			}
		// close the door if not shut all the way
		} else {
			if(transform.eulerAngles.y > closedEulerAngle.y) {
				transform.Rotate(Vector3.forward, -turnSpeed * Time.deltaTime);
			}
		}
	}
	
	void moveDoor() {
		if(Physics.Raycast(player.transform.position, playerFwd, out hit, hitRange)) {
			if(hit.collider.gameObject.name == name) {
				if(Input.GetButtonDown("A_1") || Input.GetMouseButtonDown(0)) {
					open = !open;
				}
			}
		}
	}
}
