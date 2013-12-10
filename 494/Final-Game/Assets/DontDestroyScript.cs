using UnityEngine;
using System.Collections;

public class DontDestroyScript : MonoBehaviour {
	static int instance_count = 0;
	private bool cutsceneDone;
	public void setCutscene(bool _cut) {
		cutsceneDone = _cut;
	}
	public bool getCutscene() {
		return cutsceneDone;
	}
	private GameObject player;

	void Awake () {
		if(instance_count == 0) {
			DontDestroyOnLoad(gameObject);
			player = GameObject.FindWithTag("Player");
			transform.position = player.transform.position;
			transform.rotation = player.transform.rotation;
			cutsceneDone = false;
			instance_count++;
		}
		else {
			Destroy(gameObject);
		}
	}
}
