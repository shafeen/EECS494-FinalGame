using UnityEngine;
using System.Collections;

public class InitializeClock : MonoBehaviour {
	
	public GameObject minute0;
	public GameObject minute1;
	public GameObject minute2;
	public GameObject minute3;
	public GameObject minute4;
	public GameObject minute5;
	
	
	
	// Use this for initialization of the drawings and the clock
	void Start () {
		
		if (PlayerPrefs.GetInt("level1", 0) == 1) {
			DisableClockHands();
			minute1.active = true;
		}
		
		if (PlayerPrefs.GetInt("level2", 0) == 1) {
			DisableClockHands();
			minute2.active = true;
		}
		
		if (PlayerPrefs.GetInt("level3", 0) == 1) {
			DisableClockHands();
			minute3.active = true;
		}
		
		if (PlayerPrefs.GetInt("level4", 0) == 1) {
			DisableClockHands();
			minute4.active = true;
		}
		
		if (PlayerPrefs.GetInt("level5", 0) == 1) {
			DisableClockHands();
			minute5.active = true;
		}
		
	}
	
	void DisableClockHands() {
		minute0.active = false;
		minute1.active = false;
		minute2.active = false;
		minute3.active = false;
		minute4.active = false;
		minute5.active = false;
	}
}
