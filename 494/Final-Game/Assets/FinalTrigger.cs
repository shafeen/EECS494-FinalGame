using UnityEngine;
using System.Collections;

public class FinalTrigger : MonoBehaviour {
	private bool done = false;
	private Transform[] allchidren;
	void OnTriggerEnter(Collider other){
		if(other.tag == "Player" && !done) {
			allchidren = transform.parent.gameObject.GetComponentsInChildren<Transform>();
			foreach(Transform child in allchidren) {
				if(child.name == "Torch") {
					child.gameObject.SetActive(false);
				}
			}
			done = true;
		}
	}
}
