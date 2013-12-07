using UnityEngine;
using System.Collections;

public class InitializeBedroomScene : MonoBehaviour {
	private GameObject player;
	private float time = 0.0f;
	private float time_unpause = 0.0f;
	private float pauseLength = 1.0f;

	AnimationState cinematic;
	private float speed = 1.0f;
	private float pauseOnClock = 6.0f;
	private float pauseOnFloor = 8.0f;
	private bool playing = false;
	private bool paused = false;
	private bool finished = false;
	private bool performedClockPause = false;
	private bool performedFloorPause = false;
	
	//Run as the scene is initializing
	void Awake() {

	}

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		cinematic = player.animation["Beginning_Cinematic"];
		speed = cinematic.speed;
	}
	
	// Update is called once per frame
	void Update () {
		//update time
		time += Time.deltaTime;

		// enable player movement
		//player.GetComponent<EnablePlayerInput>().EnableInput();

		// perform animation control loop if animation is not finished playing
		if (!finished) {
			// start animation after a certain period of time
			if (!playing && time >= pauseLength) {
				playing = true;
				player.animation.Play("Beginning_Cinematic");
			}

			// disable player movement until animation is done playing
			if (!playing || player.animation.isPlaying) {
				player.GetComponent<DisablePlayerInput>().DisableInput();
			}

			if (!performedClockPause) {
				// pause animation while looking at the clock
				if (!paused && cinematic.time >= pauseOnClock) {
					paused = true;
					time_unpause = time + pauseLength;
					cinematic.speed = 0.0f;
				}
				// unpause animation after looking at the clock
				if (paused && time >= time_unpause) {
					paused = false;
					performedClockPause = true;
					cinematic.speed = speed;
				}
			}

			if (!performedFloorPause) {
				// pause animation while looking at the floor
				if (!paused && cinematic.time >= pauseOnFloor) {
					paused = true;
					time_unpause = time + pauseLength / 3.0f;
					cinematic.speed = 0.0f;
				}
				// unpause animation after looking at the floor
				if (paused && time >= time_unpause) {
					paused = false;
					performedFloorPause = true;
					cinematic.speed = speed;
				}
			}

			// no longer enter control loop after animation is finished
			if (!player.animation.isPlaying &&
			    time > cinematic.length) {
				finished = true;
				player.GetComponent<EnablePlayerInput>().EnableInput();
				Destroy(gameObject);
			}
		}
	}
}
