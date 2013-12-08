using UnityEngine;
using System.Collections;

public class EnableCrystals : MonoBehaviour {

	public GameObject crystals;

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player") {
			crystals.active = true;
		}
	}
}
