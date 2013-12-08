using UnityEngine;
using System.Collections;

public class LoadSavedGameScript : MonoBehaviour {

	public GameObject level2_drawing;
	public GameObject level3_drawing;
	public GameObject level4_drawing;
	public GameObject level5_drawing;

	// Use this for initialization of the drawings
	void Start () {

		if (PlayerPrefs.GetInt("level1", 0) == 1) {
			level2_drawing.active = true;
		} else {
			level2_drawing.active = false;
		}
	
		if (PlayerPrefs.GetInt("level2", 0) == 1) {
			level2_drawing.active = true;
		} else {
			level2_drawing.active = false;
		}

		if (PlayerPrefs.GetInt("level3", 0) == 1) {
			level3_drawing.active = true;
		} else {
			level3_drawing.active = false;
		}

		if (PlayerPrefs.GetInt("level4", 0) == 1) {
			level4_drawing.active = true;
		} else {
			level4_drawing.active = false;
		}

		if (PlayerPrefs.GetInt("level5", 0) == 1) {
			level5_drawing.active = true;
		} else {
			level5_drawing.active = false;
		}

	}
}
