using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour {
	public GUIStyle settingsStyle;
	void OnGUI () {
		GUI.Label (new Rect (Screen.width/2-50, 40, 100, 100), "There will be settings here, lots of them.", settingsStyle);
		if(GUI.Button(new Rect(Screen.width/2-50,120,100,30), "Go Back")) {
			Application.LoadLevel("MainMenu");
		}
	}
}
