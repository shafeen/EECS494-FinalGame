using UnityEngine;
using System.Collections;

public class CheckpointScript : MonoBehaviour {

	private bool active = true;
	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col) {
		if (active && (col.tag == "Player" || col.tag == "cart")) {
			Debug.Log("Player reached checkpoint");
			active = false;
			player.GetComponent<RespawnTimer>().respawnLocation = transform;
		}
	}
}
