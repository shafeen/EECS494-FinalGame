using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	// Use this for initialization
	private Rect pauseMenu;
	private bool paused = false;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Escape)) {
			if(paused) {
				paused = false;
				Time.timeScale = 1;
			}
			else {
				paused = true;
				Time.timeScale = 0;
			}
		}	
	}
	void OnGUI() {
		Screen.showCursor = false;

		if(paused) {
			Screen.showCursor = true;
			pauseMenu = new Rect(Screen.width/4, Screen.height/4, Screen.width/2, Screen.height/2);
			pauseMenu = GUI.Window(0, pauseMenu, windowFunc, "PAUSED - Press ESC to resume");
		}
	}
	void windowFunc(int windowID) {
		if (GUI.Button(new Rect(pauseMenu.width/2-50, 50, 100, 40), "Back to Menu")) {
			Application.LoadLevel("MainMenu");
		}
		if (GUI.Button(new Rect(pauseMenu.width/2-50, 100, 100, 40), "Quit")) {
			Application.Quit();
		}
	}
}
