using UnityEngine;
using System.Collections;

public class RespawnTimer : MonoBehaviour {
	private float time;
	public float timeLimit = 10;
	public Transform respawnLocation;
	private bool run = false;
	private bool reverse = false;
	private FadeInOut fader;
	public float timeLeft;
	void Start() {
		time = 0;
		fader = transform.Find("Player_Cam").gameObject.GetComponent<FadeInOut>();
		fader.timeLimit = timeLimit;
	}
	// Update is called once per frame
	void Update () {
		timeLeft = timeLimit-time;
		if(run){
			time += Time.deltaTime;
		}
		fader.timeLeft = time;

		if(time > timeLimit){
			transform.position = respawnLocation.position;
			transform.rotation = respawnLocation.rotation;

		}
	}
	public void startTimer(){
		run = true;
	}
	public void stopTimer(){
		run = false;
	}
	public void addTime(){
		time -= 2*Time.deltaTime;
		if(time <0.0f) time = 0.0f;
	}
	public void resetTimer(){
		time = 0.0f;
	}
}
