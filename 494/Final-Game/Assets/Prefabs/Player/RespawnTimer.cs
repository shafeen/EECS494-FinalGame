using UnityEngine;
using System.Collections;

public class RespawnTimer : MonoBehaviour {
	private float time;
	public float timeLimit = 10;
	public Transform respawnLocation;
	private bool run = false;
	private float timeLeft;

	public float getTimeLeft(){
		return timeLeft;
	}
	public void respawn(){
		time = timeLimit + 1;
	}
	public float getTimeLimit(){
		return timeLimit;
	}
	void Start() {
		time = 0;
	}
	// Update is called once per frame
	void Update () {
		timeLeft = timeLimit-time;
		if(run){
			time += Time.deltaTime;
		}

		if(time > timeLimit){
			transform.position = respawnLocation.position;
			transform.rotation = respawnLocation.rotation;
			run = false;
			resetTimer();
		}
	}
	public void startTimer(){
		run = true;
	}
	public void stopTimer(){
		run = false;
	}

	public bool getRunning() {
		return run;
	}

	public void addTime(){
		time -= 2*Time.deltaTime;
		if(time <0.0f) time = 0.0f;
	}
	public void resetTimer(){
		time = 0.0f;
	}
}
