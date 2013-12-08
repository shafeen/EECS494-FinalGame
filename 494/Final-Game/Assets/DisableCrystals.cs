using UnityEngine;
using System.Collections;

public class DisableCrystals : MonoBehaviour {
	public GameObject crystals;
	
	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player") {
			crystals.active = false;
		}
	}
}
