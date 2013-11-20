using UnityEngine;
using System.Collections;

public class PickUpFlashlight : MonoBehaviour {

	private GameObject object_highlight;
	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButtonDown("A_1") || Input.GetMouseButtonDown(0)){
			click();
		}
	}

	void click() {
		//if ()GetComponent<HighlightScript>().IsActivated()) {
		if (transform.FindChild("Object_Highlight").gameObject.GetComponent<Light>().enabled) {
			Debug.Log("Clicked on active item");
			Destroy(gameObject);
			player.transform.FindChild("Player_Cam").FindChild("Flashlight").active = true;
		}
	}
}
