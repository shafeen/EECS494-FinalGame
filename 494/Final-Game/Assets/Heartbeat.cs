using UnityEngine;
using System.Collections;

public class Heartbeat : MonoBehaviour {
	private RespawnTimer timer;
	private float delay = 0.0f;
	private bool play;

	// Use this for initialization
	void Start () {
		timer = GameObject.Find("Player").GetComponent<RespawnTimer>();
	}
	
	// Update is called once per frame
	void Update () {
		delay -= Time.deltaTime;
		if (timer.timeLeft < timer.timeLimit) {
			if (delay <= 0) {
				audio.Play();
				delay =	Mathf.Max((timer.timeLeft/timer.timeLimit) * 1.0f, 0.4f);
//				delay = 0;
				Debug.Log("Heartbeat delay is " + delay);
			}
		}
	}
}
