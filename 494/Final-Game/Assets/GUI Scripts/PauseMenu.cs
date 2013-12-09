using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	// Use this for initialization
	private Rect pauseMenu;
	private bool paused = false;
	public float hSliderValue = 0.0F;

	void Start () {
		hSliderValue = PlayerPrefs.GetFloat("ambient", 40.0f);
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

			hSliderValue = GUI.HorizontalSlider(new Rect(Screen.width/2 - 50, Screen.height / 2 + 50, 100, 40), hSliderValue, 0.0F, 70.0F);
			GUI.Label(new Rect(Screen.width/2 + 60, Screen.height / 2 + 50, 100, 40), hSliderValue.ToString());
			GUI.Label(new Rect(Screen.width/2 - 50, Screen.height / 2 + 70, 100, 40),"Brightness");
			
			PlayerPrefs.SetFloat("ambient", hSliderValue);
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
