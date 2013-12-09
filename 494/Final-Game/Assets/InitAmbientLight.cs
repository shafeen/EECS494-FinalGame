using UnityEngine;
using System.Collections;

public class InitAmbientLight : MonoBehaviour {

	float ambient_level;
	Color color;

	void Awake() {

	}

	// Use this for initialization
	void Start () {
		ambient_level = PlayerPrefs.GetFloat("ambient", 40.0f) / 255;
		color = new Color(ambient_level, ambient_level, ambient_level, 1.0f);
		RenderSettings.ambientLight = color;
	}

	void Update() {
		if (CheckForChange()) {
			ambient_level = PlayerPrefs.GetFloat("ambient", 40.0f) / 255;
			color = new Color(ambient_level, ambient_level, ambient_level, 1.0f);
			RenderSettings.ambientLight = color;
		}
	}

	bool CheckForChange() {
		ambient_level = PlayerPrefs.GetFloat("ambient", 40.0f) / 255;
		color = new Color(ambient_level, ambient_level, ambient_level, 1.0f);
		if (RenderSettings.ambientLight != color) {
			return true;
		}
		return false;
	}
}
