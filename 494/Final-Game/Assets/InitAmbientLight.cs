using UnityEngine;
using System.Collections;

public class InitAmbientLight : MonoBehaviour {

	float ambient_level;

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}

	// Use this for initialization
	void Start () {
		ambient_level = PlayerPrefs.GetFloat("ambient", 40.0f) / 255;
		Color color = new Color(ambient_level, ambient_level, ambient_level, 1.0f);
		RenderSettings.ambientLight = color;
	}

	void Update() {
		if (ambient_level != PlayerPrefs.GetFloat("ambient", 40.0f) / 255) {
			ambient_level = PlayerPrefs.GetFloat("ambient", 40.0f) / 255;
			Color color = new Color(ambient_level, ambient_level, ambient_level, 1.0f);
			RenderSettings.ambientLight = color;
		}
	}
}
