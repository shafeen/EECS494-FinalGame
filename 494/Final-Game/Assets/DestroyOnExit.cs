using UnityEngine;
using System.Collections;

public class DestroyOnExit : MonoBehaviour {

	void OnTriggerExit(Collider col) {
		if (col.tag == "Player") {
			Destroy(gameObject);
		}
	}
}
