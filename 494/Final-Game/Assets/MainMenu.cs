using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public GUIStyle titleStyle;
	void Start() {
	}
	void OnGUI () {
		GUI.Label (new Rect (Screen.width/2-50, 40, 100, 100), "Time Out!", titleStyle);
		if(GUI.Button(new Rect(Screen.width/2-50,120,100,30), "Start")) {
			Application.LoadLevel("Bedroom");
		}
		if(GUI.Button(new Rect(Screen.width/2-50,150,100,30), "Settings")) {
			Application.LoadLevel("Settings");
		}
		if(GUI.Button(new Rect(Screen.width/2-50,180,100,30), "Quit")) {
			Application.Quit();
		}
	}
}
