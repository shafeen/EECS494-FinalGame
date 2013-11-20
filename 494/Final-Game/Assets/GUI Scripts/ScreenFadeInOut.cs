using UnityEngine;
using System.Collections;

public class ScreenFadeInOut : MonoBehaviour {

	public Texture2D fadeOutTexture;

	private int drawDepth = -1000;
	public float timeLeft;
	public float timeLimit;
	private float alpha = 0.0f; 
	
	private float fadeSpeed = 10;
	
	
	void OnGUI(){
		alpha = timeLeft/timeLimit;
		
		//GUI.color.a = alpha;
		
		GUI.depth = drawDepth;
		
		GUI.DrawTexture(new Rect(0, 0, Screen.width , Screen.height), fadeOutTexture);
	}
}