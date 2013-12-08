using UnityEngine;
using System.Collections;

public class DontDestroyScript : MonoBehaviour {
	static int instance_count = 0;
	private GameObject player;
	void Awake () {
		if(instance_count == 0) {
			DontDestroyOnLoad(gameObject);
			player = GameObject.FindWithTag("Player");
			transform.position = player.transform.position;
			transform.rotation = player.transform.rotation;
			instance_count++;
		}
		else {
			Destroy(gameObject);
		}
	}
}
