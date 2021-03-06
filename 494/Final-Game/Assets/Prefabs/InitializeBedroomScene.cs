﻿using UnityEngine;
using System.Collections;

public class InitializeBedroomScene : MonoBehaviour {
	private float time = 0.0f;
	private float time_unpause = 0.0f;
	private float beginningPauseLength = 4.5f;
	private float pauseLength = 1.0f;

	private GameObject player;
	private GameObject playerStart;

	private GameObject door;
	private bool shutDoor = false;

	private bool showedInitialDialog = false;
	
	AnimationState cinematic;
	private float speed = 1.0f;
	private float shutBedroomDoor = 3.5f;
	private float pauseOnClock = 6.0f;
	private float pauseOnFloor = 8.0f;
	private bool playing = false;
	private bool paused = false;
	private bool finished = false;
	private bool done = false;
	private bool performedClockPause = false;
	private bool performedFloorPause = false;
	
	// Run as the scene is initializing
	void Awake() {
		player = GameObject.FindWithTag("Player");
		playerStart = GameObject.Find ("PlayerStart");
		door = GameObject.FindWithTag("BedroomDoor");
		cinematic = player.animation["Beginning_Cinematic"];
	}

	// Use this for initialization
	void Start () {
		// start scene with bedroom door open
		door.GetComponent<OperateRoomDoor>().SetToOpen();
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerPrefs.GetInt("level2",0) != 1) {
			//update time
			time += Time.deltaTime;

			// start dialog at beginning of scene
			if(!showedInitialDialog) {
				showedInitialDialog = true;
				// set the opening dialog
				GetComponent<DialogBox>().dialogString = "\"Time out! Go to your room and don't come out for five minutes.\"";
				// start dialog in the beginning of the scene
				GetComponent<DialogBox>().ShowDialog = true;
			}

			// perform animation control loop if animation is not finished playing
			if(!finished) {
				// start animation after a certain period of time
				if(!playing && time >= beginningPauseLength) {
					playing = true;
					GetComponent<DialogBox>().ShowDialog = false;
					player.animation.Play("Beginning_Cinematic");
				}

				// disable player movement until animation is done playing
				if(!playing || player.animation.isPlaying) {
					player.GetComponent<DisablePlayerInput>().DisableInput();
				}

				// close bedroom door after a set period of time in
				// the animation
				if(!shutDoor && cinematic.time >= shutBedroomDoor) {
					shutDoor = true;
					door.GetComponent<OperateRoomDoor>().CloseDoor();
				}

				if(!performedClockPause) {
					// pause animation while looking at the clock
					if(!paused && cinematic.time >= pauseOnClock) {
						paused = true;
						time_unpause = time + pauseLength;
						cinematic.speed = 0.0f;

						// start child dialogue
						GetComponent<DialogBox>().ResetString();
						GetComponent<DialogBox>().dialogString = "Aw man...";
						GetComponent<DialogBox>().ShowDialog = true;
					}
					// unpause animation after looking at the clock
					if(paused && time >= time_unpause) {
						paused = false;
						performedClockPause = true;
						cinematic.speed = speed;
					}
				}

				if(!performedFloorPause) {
					// pause animation while looking at the floor
					if(!paused && cinematic.time >= pauseOnFloor) {
						paused = true;
						time_unpause = time + pauseLength / 3.0f;
						cinematic.speed = 0.0f;
					}
					// unpause animation after looking at the floor
					if(paused && time >= time_unpause) {
						paused = false;
						performedFloorPause = true;
						cinematic.speed = speed;

						// end child dialogue
						GetComponent<DialogBox>().ShowDialog = false;
					}
				}

				// no longer enter control loop after animation is finished
				if(!player.animation.isPlaying &&
				    time > cinematic.length) {
					finished = true;
					player.GetComponent<EnablePlayerInput>().EnableInput();
					// disable bedroom door movement
					door.GetComponent<OperateRoomDoor>().enabled = false;
					Destroy(gameObject);
				}
			}
		}
		else if(!done) {
			door.GetComponent<OperateRoomDoor>().CloseDoor();
			player.transform.position = playerStart.transform.position;
			done = true;
		}
	}
}
