using UnityEngine;
using System.Collections;

public class WinScript : MonoBehaviour {
	private GameObject player;
	private RaycastHit hit;
	private Vector3 fwd;
	private bool winning;
	private GUITexture fader;
	void Awake () {
		player = GameObject.Find("Player");
		fader = (GameObject.Find("ScreenFader").GetComponent<GUITexture>()as GUITexture);
		fader.guiTexture.enabled = false;
		fader.guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
	}


	// Update is called once per frame
	void Update () {
		fader.guiTexture.pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
		fwd = player.transform.TransformDirection(Vector3.forward);
		if(winning) {
			fader.guiTexture.enabled = true;
			fader.guiTexture.color = Color.Lerp(fader.guiTexture.color, Color.white, 0.4f*Time.deltaTime);
			print(fader.guiTexture.color.a);
			if(fader.guiTexture.color.a >= 0.70f){
				Application.LoadLevel("Bedroom");
			}
		}
		if((Input.GetButtonDown("A_1") || Input.GetMouseButtonDown(0))){
			if(Physics.Raycast(player.transform.position, fwd, out hit, 3.0f)) {
				if(hit.collider.gameObject.name == name) {
					fader.guiTexture.color = Color.clear;
					winning = true;
				}
			}
		}
	}
}