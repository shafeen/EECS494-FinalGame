using UnityEngine;
using System.Collections;

public class OperateRoomDoor : MonoBehaviour {
  private float time = 0.0f;

  private GameObject player;
  private Vector3 playerFwd;
  private float hitRange = 3.0f;
  private RaycastHit hit;

  private string openDoorAnimation = "OpenDoor";
  private AnimationState openDoor;
  private string closeDoorAnimation = "CloseDoor";
  private AnimationState closeDoor;
  private bool open = false;
  private bool paused = false;

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
    //update time
    time += Time.deltaTime;

    // get Player's current forward vector
    playerFwd = player.transform.forward;

    // check to see if Player opened or closed the door
    MoveDoor();
  }

  void MoveDoor() {
    if(Physics.Raycast(player.transform.position, playerFwd, out hit, hitRange)) {
      if(hit.collider.gameObject.name == name) {
        if((Input.GetButtonDown("A_1") || Input.GetMouseButtonDown(0))) {
          // close the door if it is open
          if(open) {
            CloseDoor();
          // open the door if it is closed
          } else {
            OpenDoor();
          }
        }
      }
    }
  }

  public bool IsOpen() {
    return open;
  }

  public void OpenDoor() {
    openDoor.speed = 1.0f;
    if (!paused) {
      animation.Play(openDoorAnimation);
    } else {
      paused = false;
    }
    open = true;
  }

  public void PauseOpeningDoor() {
    openDoor.speed = 0.0f;
    if (openDoor.time < openDoor.length) {
      open = false;
      paused = true;
    } else {
      paused = false;
    }
  }

  public void OpenDoorHalfway() {
    float pause = time + 0.5f;
    animation.Play(openDoorAnimation);
    openDoor.speed = 0.0f;
    open = false;
  }

  public void CloseDoor() {
    closeDoor.speed = 1.0f;
    animation.Play(closeDoorAnimation);
    open = false;
  }

  public void SetToOpen() {
    openDoor.time = openDoor.length;
    animation.Play(openDoorAnimation);
    open = true;
  }

  public void SetToClose() {
    closeDoor.time = closeDoor.length;
    animation.Play(closeDoorAnimation);
    open = false;
  }
}
