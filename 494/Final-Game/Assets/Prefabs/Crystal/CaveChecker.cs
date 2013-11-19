using UnityEngine;
using System.Collections;

public class CaveChecker : MonoBehaviour {
	private RespawnTimer respawn;

	void Start() {
		respawn = GameObject.FindWithTag("Player").GetComponent<RespawnTimer>();
	}
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player") {
			respawn.stopTimer();
			respawn.resetTimer();
			print("NOT IN CAVE");
		}
	}
	void OnTriggerExit(Collider other) {
		if(other.gameObject.tag == "Player") {
			respawn.startTimer();
			print("INCAVE");

		}
	}
}
