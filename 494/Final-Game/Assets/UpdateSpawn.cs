using UnityEngine;
using System.Collections;

public class UpdateSpawn : MonoBehaviour {
	private GameObject spawnPoint;
	void Start() {
		spawnPoint = GameObject.Find("SpawnPointHolder");
	}
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player") {
			spawnPoint.transform.position = transform.position;
			spawnPoint.transform.rotation = transform.rotation;
		}
	}
}
