using UnityEngine;
using System.Collections;

public class OperateRoomDoor : MonoBehaviour {
  private GameObject player;
  private Vector3 playerFwd;
  private float hitRange = 3.0f;
  private RaycastHit hit;

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
    player = GameObject.FindWithTag("Player");
    // initialize the angles and turn speed used when closing and opening the 
    // door from the door's current angles
    closedEulerAngleY = transform.eulerAngles.y;
    if(closedEulerAngleY <= 180.0f) {
      openedEulerAngleY = closedEulerAngleY - 135.0f;
    } else {
      openedEulerAngleY = closedEulerAngleY - 235.0f;
      turnSpeed *= -1.0f;
    } 
  }

  // Use this for initialization
  void Start() {

  }
  
  // Update is called once per frame
  void Update() {
    // get Player's current forward vector
    playerFwd = player.transform.forward;

    // check to see if Player opened or closed the door
    MoveDoor();

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

  void MoveDoor() {
    if(Physics.Raycast(player.transform.position, playerFwd, out hit, hitRange)) {
      if(hit.collider.gameObject.name == name) {
        if(Input.GetButtonDown("A_1") || Input.GetMouseButtonDown(0)) {
          // close the door if it is open
          if(isOpen) {
            CloseDoor();
          }

          // open the door if it is closed
          if(isClosed) {
            OpenDoor();
          }
        }
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
