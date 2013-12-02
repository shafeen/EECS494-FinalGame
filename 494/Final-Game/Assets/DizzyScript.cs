using UnityEngine;
using System.Collections;

public class DizzyScript : MonoBehaviour {

	private RespawnTimer timer;
	private MotionBlur blur;
	public float blurLimit;
	private float timeLimit;
	private float timeLeft;
	void Start() {
		blur = GameObject.Find("Player_Cam").GetComponent<MotionBlur>();
		timer = GameObject.FindWithTag("Player").GetComponent<RespawnTimer>();
		timeLimit = timer.getTimeLimit();
	}
	void Update() {
		timeLeft = timer.getTimeLeft();
		blur.setBlurAmount((1-timeLeft/timeLimit) * blurLimit);
	}
}
