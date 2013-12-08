using UnityEngine;
using System.Collections;

public class ActivateLook : MonoBehaviour {

	private bool clicked = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("A_1") || Input.GetMouseButtonDown(0)){
			Debug.Log("Clicking");
			click();
		}
	}

	void click() {
		if (!clicked && transform.FindChild("Object_Highlight").gameObject.GetComponent<Light>().enabled) {
			gameObject.GetComponent<cutScene>().Activate();
			clicked = true;
		}
	}
}
