using UnityEngine;
using System.Collections;

public class ReloadRespawn : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		if(other.tag == "Player") {
			//Completely reload level.
			Application.LoadLevel(Application.loadedLevel);
		}
		else {
			Destroy(other.gameObject);
		}
	}
}
