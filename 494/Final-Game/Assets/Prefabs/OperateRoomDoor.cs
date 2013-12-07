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

	// Run as the scene is initializing
	void Awake() {
		// open bedroom door
		transform.Rotate(Vector3.forward * (openedEulerAngleY - closedEulerAngleY));
	}

	// Use this for initialization
	void Start() {

	}
	
	// Update is called once per frame
	void Update() {
		if(open) {
			if(transform.eulerAngles.y > openedEulerAngleY) {
				transform.Rotate(Vector3.forward, -turnSpeed * Time.deltaTime);
			} else {
				open = false;
				isOpen = true;
				isClosed = false;
			}
		}

		if(close) {
			if(transform.eulerAngles.y < closedEulerAngleY) {
				transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
			} else {
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
	}

	public void CloseDoor() {
		close = true;
	}
}
