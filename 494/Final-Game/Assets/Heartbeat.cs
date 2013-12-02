using UnityEngine;
using System.Collections;

public class Heartbeat : MonoBehaviour {
	private RespawnTimer timer;
	private float delay = 1.0f;
	private bool play;

	public AudioSource heartbeats;
	public AudioSource last_heartbeat;

	// Use this for initialization
	void Start () {
		timer = GameObject.FindWithTag("Player").GetComponent<RespawnTimer>();
	}
	
	// Update is called once per frame
	void Update () {
		delay -= Time.deltaTime;
		if (timer.getTimeLeft() < timer.getTimeLimit() && timer.getTimeLeft() > 0) {
			if (delay <= 0) {
				heartbeats.Play();
				delay =	Mathf.Max((timer.getTimeLeft()/timer.getTimeLimit()) * 1.0f, 0.4f);
				heartbeats.volume = 1.0f - 0.8f * (timer.getTimeLeft()/timer.getTimeLimit());
			}
		} else if (timer.getTimeLeft() < timer.getTimeLimit() && timer.getTimeLeft() <= 0) {
			if (delay <= 0) {
				//last_heartbeat.Play();
				delay = 100000;
			}
		}
	}
}
