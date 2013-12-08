using UnityEngine;
using System.Collections;

public class movePlatformScript : MonoBehaviour {
	private enum MOVINGSTATE {wait, start, moving, ended};
	private float startTime;
	private MOVINGSTATE state = MOVINGSTATE.wait;
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player" && state == MOVINGSTATE.wait) {
			state = MOVINGSTATE.start;
			startTime = Time.time;
		}
	}
	void Update() {
		switch(state) {
		case MOVINGSTATE.start:
			if((Time.time - startTime) > 1.5) {
				transform.parent.animation.Play("MovingPlatform");
				state = MOVINGSTATE.moving;
			}
			break;
		case MOVINGSTATE.moving:
			if(!transform.parent.animation.isPlaying) {
				print("done");
				startTime = Time.time;
				state = MOVINGSTATE.ended;
			}
			break;
		case MOVINGSTATE.ended:
			if((Time.time - startTime) > 1) {
				transform.parent.rigidbody.useGravity = true;
			}
			break;
		}
	}
}
