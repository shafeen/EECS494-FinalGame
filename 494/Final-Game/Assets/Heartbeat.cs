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
		timer = GameObject.Find("Player").GetComponent<RespawnTimer>();
	}
	
	// Update is called once per frame
	void Update () {
		delay -= Time.deltaTime;
		if (timer.timeLeft < timer.timeLimit && timer.timeLeft > 0) {
			if (delay <= 0) {
				heartbeats.Play();
				delay =	Mathf.Max((timer.timeLeft/timer.timeLimit) * 1.0f, 0.4f);
				heartbeats.volume = 1.0f - 0.8f * (timer.timeLeft/timer.timeLimit);
				Debug.Log("Heartbeat delay is " + delay);
			}
		} else if (timer.timeLeft < timer.timeLimit && timer.timeLeft <= 0) {
			if (delay <= 0) {
				last_heartbeat.Play();
				delay = 100000;
			}
		}
	}
}
