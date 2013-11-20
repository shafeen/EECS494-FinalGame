using UnityEngine;
using System.Collections;

public class CheckpointScript : MonoBehaviour {

	private bool active = true;
	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col) {
		if (active && col.tag == "Player") {
			Debug.Log("Player reached checkpoint");
			active = false;
			player.GetComponent<RespawnTimer>().respawnLocation = transform;
		}
	}
}
