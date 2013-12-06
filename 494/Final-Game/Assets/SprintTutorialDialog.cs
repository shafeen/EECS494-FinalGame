using UnityEngine;
using System.Collections;

public class SprintTutorialDialog : MonoBehaviour {

	public DialogBox dialogBox;
	private bool showing_dialog = false;

	void Update() {
		if (Input.GetButtonDown("RB_1") || Input.GetKey("left shift")) {
			dialogBox.ShowDialog = false;
		}
	}

	void OnTriggerEnter(Collider col) {
		if (col.tag == "Player") {
			// disable this if just using the C# property to activate
			StartCoroutine("DelayDialog");
		}
	}

	IEnumerator DelayDialog() {
		yield return new WaitForSeconds(5.0f);
		dialogBox.ShowDialog = true;
	}
}
