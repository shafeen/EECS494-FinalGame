using UnityEngine;
using System.Collections;

public class CaveChecker : MonoBehaviour {
	public bool inCave = false;
	//private RespawnTimer respawn;

	void Start() {
		//respawn = GameObject.FindWithTag("Player").GetComponent<RespawnTimer>;
	}
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player") {
			inCave = false;
			print("NOT IN CAVE");
		}
	}
	void OnTriggerExit(Collider other) {
		if(other.gameObject.tag == "Player") {
			inCave = true;
			print("INCAVE");

		}
	}
}
