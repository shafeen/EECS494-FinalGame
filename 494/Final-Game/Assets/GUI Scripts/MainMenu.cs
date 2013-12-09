using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public GUIStyle titleStyle;
	public GUIStyle buttonStyle;

	public float menuButtonSeparation;
	public float menuTitleOffset;
	public float menuOptionsOffset;

	//private MenuCursor cursor;
	void Start() {
	//	cursor = GameObject.Find("cursor").GetComponent<MenuCursor>();
	}
	void OnGUI () {
		GUI.Label (new Rect (Screen.width/2-50, 40+menuTitleOffset, 100, 100), 
		           "Time Out!", titleStyle);
		if(GUI.Button(new Rect(Screen.width/2-50,120+menuOptionsOffset,100,30),
		              "Start", buttonStyle)){
			Application.LoadLevel("BedroomLevel");
		}
		if(GUI.Button(new Rect(Screen.width/2-50,150+1*menuButtonSeparation+menuOptionsOffset,100,30), 
		              "Settings", buttonStyle)){
			Application.LoadLevel("Settings");
		}
		if(GUI.Button(new Rect(Screen.width/2-50,180+2*menuButtonSeparation+menuOptionsOffset,100,30), 
		              "Quit", buttonStyle)){
			Application.Quit();
		}

	}
	void Update() {
		/*if(Input.GetButtonDown("A_1") || Input.GetMouseButtonDown(0)) {
			if(startButton.HitTest(new Vector3(cursor.position.x + cursor.position.width/2,cursor.position.y + cursor.position.height/2,0))) {
				Application.LoadLevel("Bedroom");
			}
			if(settingsButton.HitTest(new Vector3(cursor.position.x + cursor.position.width/2,cursor.position.y + cursor.position.height/2,0))) {
				Application.LoadLevel("Settings");
			}
			if(quitButton.HitTest(new Vector3(cursor.position.x + cursor.position.width/2,cursor.position.y + cursor.position.height/2,0))) {
				Application.Quit();
			}
		}*/
	}
}