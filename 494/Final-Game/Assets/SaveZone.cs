using UnityEngine;
using System.Collections;

public class SaveZone : MonoBehaviour {

	private RespawnTimer respawn;
	
	void Start() {
		respawn = GameObject.FindWithTag("Player").GetComponent<RespawnTimer>();
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player") {
			respawn.stopTimer();
		}
	}
//	void OnTriggerStay(Collider other) {
//		if(other.gameObject.tag == "Player") {
//			respawn.stopTimer();
//		}
//	}

	void OnTriggerExit(Collider other) {
		if(other.gameObject.tag == "Player") {
			respawn.resetTimer();
			respawn.startTimer();
		}
	}
}
