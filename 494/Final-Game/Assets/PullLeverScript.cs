using UnityEngine;
using System.Collections;

public class PullLeverScript : MonoBehaviour {

	public Transform portcullis;
	private Transform lever;
	private Transform handle;
	private bool pulled = false;

	// Use this for initialization
	void Start () {
		lever = transform.FindChild("Lever");
		handle = lever.FindChild("Handle");
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetButtonDown("A_1") || Input.GetMouseButtonDown(0)){
			Debug.Log("Clicking");
			click();
		}
	
	}

	void click() {
		if (!pulled && transform.FindChild("Object_Highlight").gameObject.GetComponent<Light>().enabled) {
			handle.animation.Play("Pull Lever Down");
			portcullis.FindChild("Portcullis Model").animation.Play("Raise Portcullis");
			pulled = true;
		}
	}
}
