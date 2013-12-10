using UnityEngine;
using System.Collections;

public class RespawnTimer : MonoBehaviour {
	public GameObject[] listeners;
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
		startTimer();
	}
	// Update is called once per frame
	void Update () {
		timeLeft = timeLimit-time;
		if(run){
			time += Time.deltaTime;
		}

		if(time > timeLimit && respawnLocation){
			InformRespawn();
			transform.position = respawnLocation.position;
			transform.rotation = respawnLocation.rotation;
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

	void InformRespawn() {
		foreach (GameObject o in listeners) {
			IRespawn ir = (IRespawn) o.GetComponent(typeof(IRespawn));
			//o = (IRespawn)GetComponent(typeof(IRespawn));
			if (ir != null) {
				Debug.Log("Calling Respawn on listener");
				ir.Respawn();
			}
		}
	}
}
