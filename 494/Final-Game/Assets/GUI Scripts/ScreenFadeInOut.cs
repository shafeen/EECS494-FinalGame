using UnityEngine;
using System.Collections;

public class ScreenFadeInOut : MonoBehaviour {

	public float fadeBlackSpeed;
	public float fadeClearSpeed;
	public bool dying = false;
	private GameObject player;
	private Texture2D tempTex;
	void Awake ()
	{
		guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
		Color tempColor = Color.clear;
		guiTexture.color = tempColor;
	}
	void Start() {
		tempTex = new Texture2D(1,1);
		tempTex.SetPixel(0,0,Color.clear);
	}
	void Update() {
		Color textureColor = guiTexture.color;
		print(dying);
		if(dying) {
			print("fading");
			textureColor.a += fadeBlackSpeed*Time.deltaTime;
			textureColor.a = Mathf.Clamp(textureColor.a,0,1);
			print(textureColor.a);
		}
		else {
			Mathf.Clamp(textureColor.a -= fadeClearSpeed*Time.deltaTime,0,1);
		}
		guiTexture.color = textureColor;
	}

}
