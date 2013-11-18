using UnityEngine;
using System.Collections;

public class RespawnTimer : MonoBehaviour {
	private float time;
	public float timeLimit = 10;
	public Transform respawnLocation;
	private bool run = false;
	void Start() {
		time = 0;
	}
	// Update is called once per frame
	void Update () {
		print((time));

		if(run){
			time += Time.deltaTime;
		}
		if(time > timeLimit){
			transform.position = respawnLocation.position;
			transform.rotation = respawnLocation.rotation;

		}
	}
	public void startTimer(){
		run = true;
		print("start");
	}
	public void stopTimer(){
		run = false;
		print("stop");
	}
	public void resetTimer(){
		time = 0;
		print("reset");
	}
}
