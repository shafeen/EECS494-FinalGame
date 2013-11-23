using UnityEngine;
using System.Collections;

public class HighlightScript : MonoBehaviour {
	private GameObject object_highlight;
	private bool activated = false;

	// Use this for initialization
	void Start () {
		object_highlight = transform.FindChild("Object_Highlight").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (activated) {
			object_highlight.GetComponent<Light>().enabled = true;
		} else {
			object_highlight.GetComponent<Light>().enabled = false;
		}

		activated = false;
	}

	public void activate() {
		//Use this function to make object glow or change color to indicate that it is selected
		activated = true;
	}

}
