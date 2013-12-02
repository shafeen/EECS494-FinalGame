using UnityEngine;
using System.Collections;

public class LevelChange : MonoBehaviour {

	public string new_level;

	void OnTriggerEnter() {
		Application.LoadLevel(new_level);
	}


}
