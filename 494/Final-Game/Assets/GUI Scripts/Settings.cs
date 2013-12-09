using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour {
	public GUIStyle settingsStyle;
	public float hSliderValue = 0.0F;

	void Start() {
		hSliderValue = PlayerPrefs.GetFloat("ambient", 40.0f);
	}

	void OnGUI () {
		GUI.Label (new Rect (Screen.width/2-50, 40, 100, 100), "There will be settings here, lots of them.", settingsStyle);
		if(GUI.Button(new Rect(Screen.width/2-50,120,100,30), "Go Back")) {
			Application.LoadLevel("MainMenu");
		}

		hSliderValue = GUI.HorizontalSlider(new Rect(25, 25, 100, 30), hSliderValue, 0.0F, 70.0F);
		GUI.Label(new Rect(10, 10, 100, 20), hSliderValue.ToString());

		PlayerPrefs.SetFloat("ambient", hSliderValue);
	}
}
