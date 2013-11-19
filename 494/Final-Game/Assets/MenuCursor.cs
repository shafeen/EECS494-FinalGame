using UnityEngine;
using System.Collections;

public class MenuCursor : MonoBehaviour {
	public Texture2D crosshairTexture;
	public Rect position;
	public float sensitivity = 20;
	private float deltaX = 0;
	private float deltaY = 0;
	// Use this for initialization
	void Start () {
		position = new Rect((Screen.width - crosshairTexture.width) / 2, (Screen.height - crosshairTexture.height) /2, crosshairTexture.width, crosshairTexture.height);
	}
	
	// Update is called once per frame
	void Update () {
		deltaY = Mathf.Clamp(Input.GetAxis("L_YAxis_1") + Input.GetAxis("Mouse Y"),-1,1) * sensitivity;
		deltaX = Mathf.Clamp(Input.GetAxis("L_XAxis_1") + Input.GetAxis("Mouse X"),-1,1) * sensitivity;
		position.x += deltaX;
		position.y -= deltaY;
		Screen.showCursor = false;
		print(sensitivity);
	}
	void OnGUI()
	{
		GUI.DrawTexture(position, crosshairTexture);
	}
}
