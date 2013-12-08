using UnityEngine;
using System.Collections;

public class InitializeLevel : MonoBehaviour {
	private GameObject player;
	private GameObject spawnPoint;
	void Start () {
		player = GameObject.FindWithTag("Player");
		spawnPoint = GameObject.Find("SpawnPointHolder");
		player.transform.position = spawnPoint.transform.position;
		player.transform.rotation = spawnPoint.transform.rotation;
	}
}
