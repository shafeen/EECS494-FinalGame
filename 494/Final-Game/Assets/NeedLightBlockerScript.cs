using UnityEngine;
using System.Collections;

public class NeedLightBlockerScript : MonoBehaviour {

	public DialogBox dialogBox;

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player") {
			dialogBox.ShowDialog = true;
		}
	}

	void OnTriggerExit(Collider col) {
		if (col.tag == "Player") {
			dialogBox.ShowDialog = false;
		}
	}
}
