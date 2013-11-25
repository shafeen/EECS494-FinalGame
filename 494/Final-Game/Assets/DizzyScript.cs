using UnityEngine;
using System.Collections;

public class DizzyScript : MonoBehaviour {

	private RespawnTimer timer;
	private MotionBlur blur;
	public float blurLimit;
	void Start() {
		blur = GameObject.Find("Player_Cam").GetComponent<MotionBlur>();
		timer = GameObject.Find("Player").GetComponent<RespawnTimer>();
	}
	void Update() {
		blur.blurAmount = (1-timer.timeLeft/timer.timeLimit) * blurLimit;
	}
}
