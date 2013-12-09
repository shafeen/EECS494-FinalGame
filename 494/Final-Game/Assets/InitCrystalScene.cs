using UnityEngine;
using System.Collections;

public class InitCrystalScene : MonoBehaviour {

	public GameObject player_cam;
	public GameObject flashlight;

	public Texture2D fadeTexture;
	private float fade_time = 6.0f;
	private float fade_amt = 6.0f;

	void Awake() {

	}

	// Use this for initialization
	void Start () {
		flashlight.collider.enabled = false;
		GameObject.FindWithTag("Player").GetComponent<DisablePlayerInput>().DisableInput();
		StartCoroutine("FadeIn");
		StartCoroutine("PlayWakeUp");
	}

	IEnumerator FadeIn() {
		while (fade_amt > 0) {
			fade_amt -= Time.deltaTime;
			yield return null;
		}
	}

	IEnumerator PlayWakeUp() {
		player_cam.animation.Play("wake_up");
		while (player_cam.animation.IsPlaying("wake_up")) {
			yield return null;
		}
		Debug.Log("Done with animation");
		GameObject.FindWithTag("Player").GetComponent<EnablePlayerInput>().EnableInput();
		flashlight.collider.enabled = true;
	}

	void OnGUI() {
		float alpha = fade_amt / fade_time;
		
		Color color = GUI.color;
		
		color.a = alpha;
		
		GUI.color = color;
		
		GUI.depth = -1000;
		
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
	}
}
