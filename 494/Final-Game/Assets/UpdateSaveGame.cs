using UnityEngine;
using System.Collections;

public class UpdateSaveGame : MonoBehaviour {

	public enum Level {
		Level_2,
		Level_3,
		Level_4,
		Level_5 };

	public Level my_level;

	// Use this for initialization
	void Start () {
	
		switch (my_level) {
		case Level.Level_2:
			PlayerPrefs.SetInt("level2", 1);
			PlayerPrefs.Save();
			break;

		case Level.Level_3:
			PlayerPrefs.SetInt("level3", 1);
			PlayerPrefs.Save();
			break;

		case Level.Level_4:
			PlayerPrefs.SetInt("level4", 1);
			PlayerPrefs.Save();
			break;

		case Level.Level_5:
			PlayerPrefs.SetInt("level5", 1);
			PlayerPrefs.Save();
			break;
		}

	}

}
