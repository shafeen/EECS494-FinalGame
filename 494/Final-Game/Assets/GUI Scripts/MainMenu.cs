using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public GUIStyle titleStyle;
	public GUIStyle buttonStyle;


	public float menuButtonSeparation;
	public float menuTitleOffset;
	public float menuTitleLeftMarginOffset;
	public float menuOptionsOffset;
	public float menuLeftMarginOffset;

	public GameObject flickerLightObject;
	public float lightIntensity;

	//private MenuCursor cursor;
	void Start() {
	//	cursor = GameObject.Find("cursor").GetComponent<MenuCursor>();
	}
	void OnGUI () {
		GUI.Label (new Rect (Screen.width/2-50+menuTitleLeftMarginOffset, 40+menuTitleOffset, 100, 100), 
		           "Time Out!", titleStyle);
		if(GUI.Button(new Rect(Screen.width/2-50+menuLeftMarginOffset,120+menuOptionsOffset,100,30),
		              "Start New Game", buttonStyle)){
			PlayerPrefs.DeleteKey("level1");
			PlayerPrefs.DeleteKey("level2");
			PlayerPrefs.DeleteKey("level3");
			PlayerPrefs.DeleteKey("level4");
			PlayerPrefs.DeleteKey("level5");
			Application.LoadLevel("BedroomLevel");
		}
		/*if(GUI.Button(new Rect(Screen.width/2-50+menuLeftMarginOffset,150+1*menuButtonSeparation + menuOptionsOffset,100,30), 
		              "Settings", buttonStyle)){
			Application.LoadLevel("Settings");
		}*/
		if(GUI.Button(new Rect(Screen.width/2-50+menuLeftMarginOffset,150+1*menuButtonSeparation + menuOptionsOffset,100,30), 
		              "Quit", buttonStyle)){
			Application.Quit();
		}

		if (PlayerPrefs.HasKey("level2")) {
			if(GUI.Button(new Rect(Screen.width/2-50+menuLeftMarginOffset,180+2*menuButtonSeparation + menuOptionsOffset,100,30), "Resume", buttonStyle)) {
				Application.LoadLevel("BedroomLevel");
			}
		}

		if(GUI.Button(new Rect(Screen.width/2-50+menuLeftMarginOffset,210+3*menuButtonSeparation + menuOptionsOffset,100,30), "Start Showcase", buttonStyle)) {
			PlayerPrefs.SetInt("level1", 1);
			PlayerPrefs.SetInt("level2", 1);
			PlayerPrefs.SetInt("level3", 1);
			PlayerPrefs.SetInt("level4", 1);
			PlayerPrefs.SetInt("level5", 1);
			Application.LoadLevel("BedroomLevel");
		}

	}





	void Update() {
		flickerLightObject.light.intensity = Random.Range(1,80);
	}
}