using UnityEngine;
using System.Collections;

public class ImmediateRespawn : MonoBehaviour {
	private RespawnTimer respawn;

	void Start() {
		respawn = GameObject.FindWithTag("Player").GetComponent<RespawnTimer>();
	}
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Player") {
			respawn.respawn();
		}
	}
}
