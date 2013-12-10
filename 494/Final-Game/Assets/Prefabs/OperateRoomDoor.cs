using UnityEngine;
using System.Collections;

public class OperateRoomDoor : MonoBehaviour {
  private GameObject player;
  private Vector3 playerFwd;
  private float hitRange = 3.0f;
  private RaycastHit hit;

  private string openDoorAnimation = "OpenDoor";
  private string closeDoorAnimation = "CloseDoor";

  private AnimationState openDoor;
  private AnimationState closeDoor;

  private float currentTime = 0.0f;

  // OBSOLETE
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
    openDoor = animation[openDoorAnimation];
    closeDoor = animation[closeDoorAnimation];
  }

  // Use this for initialization
  void Start() {
    player = GameObject.FindWithTag("Player");
  }
  
  // Update is called once per frame
  void Update() {
    // get Player's current forward vector
    playerFwd = player.transform.forward;

    // check to see if Player opened or closed the door
    MoveDoor();
  }

  void MoveDoor() {
    if(Physics.Raycast(player.transform.position, playerFwd, out hit, hitRange)) {
      if(hit.collider.gameObject.name == name) {
        if((Input.GetButtonDown("A_1") || Input.GetMouseButtonDown(0)) &&
            !animation.isPlaying) {
          // close the door if it is open
          if(open) {
            open = false;
            CloseDoor();
          // open the door if it is closed
          } else {
            open = true;
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
    openDoor.time = 0.0f;
    animation.Play(openDoorAnimation);
  }

  public void CloseDoor() {
    closeDoor.time = 0.0f;
    animation.Play(closeDoorAnimation);
  }

  public void SetToOpen() {
    openDoor.time = 1.0f;
    animation.Play(openDoorAnimation);
  }

  public void SetToClose() {
    closeDoor.time = 1.0f;
    animation.Play(closeDoorAnimation);
  }
}
