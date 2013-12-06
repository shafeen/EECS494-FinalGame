using UnityEngine;
using System.Collections;

public class HighlightScript : MonoBehaviour {
	private GameObject object_highlight;
	private GameObject object_sparkle;
	private bool activated = false;
	public Texture a_button;
	public Texture left_click;

	// Use this for initialization
	void Start () {
		object_highlight = transform.FindChild("Object_Highlight").gameObject;
		object_sparkle = transform.FindChild("Sparkle").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (activated) {
			object_highlight.GetComponent<Light>().enabled = true;
			object_sparkle.active = true;
		} else {
			object_highlight.GetComponent<Light>().enabled = false;
			object_sparkle.active = false;
		}

		activated = false;
	}

	void OnGUI() {
		if (object_sparkle.active) {
			GUI.DrawTexture(new Rect(Screen.width / 2 - 20, Screen.height - Screen.height * 0.3f, 64, 64), a_button, ScaleMode.ScaleToFit, true, 0);
			GUI.DrawTexture(new Rect(Screen.width / 2 + 20, Screen.height - Screen.height * 0.3f, 100, 100), left_click, ScaleMode.ScaleToFit, true, 0);
		}

	}

	public void activate() {
		//Use this function to make object glow or change color to indicate that it is selected
		activated = true;
	}

}
