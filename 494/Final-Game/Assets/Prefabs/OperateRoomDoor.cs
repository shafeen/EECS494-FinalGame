using UnityEngine;
using System.Collections;

public class OperateRoomDoor : MonoBehaviour {
	private float closedEulerAngleY = 180.0f;
	private float openedEulerAngleY = 45.0f;
	private float turnSpeed = 50.0f;
	private bool isOpen = false;
	private bool isClosed = true;
	private bool open = false;
	private bool close = false;
	private bool moving = false;

	// Run as the scene is initializing
	void Awake() {
		
	}

	// Use this for initialization
	void Start() {

	}
	
	// Update is called once per frame
	void Update() {
		// open the door
		if(open) {
			if(transform.eulerAngles.y > openedEulerAngleY) {
				transform.Rotate(Vector3.forward, -turnSpeed * Time.deltaTime);
			} else {
				if(moving) {
					moving = false;
					SetToOpen();
				}
				open = false;
				isOpen = true;
				isClosed = false;
			}
		}

		// close the door
		if(close) {
			if(transform.eulerAngles.y < closedEulerAngleY) {
				transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
			} else {
				if(moving) {
					moving = false;
					SetToClose();
				}
				close = false;
				isClosed = true;
				isOpen = false;
			}
		}
	}

	public bool IsOpen() {
		return isOpen;
	}

	public bool IsClosed() {
		return isClosed;
	}

	public void OpenDoor() {
		open = true;
		moving = true;
	}

	public void CloseDoor() {
		close = true;
		moving = true;
	}

	public void SetToOpen() {
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, 
																				openedEulerAngleY, 
																				transform.eulerAngles.z);
	}

	public void SetToClose() {
		transform.eulerAngles = new Vector3(transform.eulerAngles.x, 
																				closedEulerAngleY, 
																				transform.eulerAngles.z);
	}
}
