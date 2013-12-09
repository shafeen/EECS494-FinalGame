using UnityEngine;
using System.Collections;

public class KillTorches : MonoBehaviour {

	private enum SceneCue{
		WAIT,
		START,
		FADE_WIND,
		SCENE_CHANGE };

	private SceneCue sceneCue;

	public TorchSet[] torchSets;
	public Texture2D fadeTexture;
	public float fade_time = 1.0f;
	public float fade_amt = 0.0f;
	private float time = 0.0f;
	private bool start_scene = false;
	private bool fade_out = false;
	private string newLevel = "Crystal_To_Crystal_Puzzle";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (sceneCue == SceneCue.START) {
			StartCoroutine("PutOutTorches");
		} else if (sceneCue == SceneCue.FADE_WIND) {
			StartCoroutine("FadeOut");
			StartCoroutine("FadeToBlack");
		} else if (sceneCue == SceneCue.SCENE_CHANGE) {
			StartCoroutine("SceneChange");
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			sceneCue = SceneCue.START;
			if (!audio.isPlaying) {
				audio.Play();
			}
		}
	}

	IEnumerator PutOutTorches() {
		sceneCue = SceneCue.WAIT;
		GameObject.FindWithTag("Monster").animation.Play("PutOutTorches");
		foreach (TorchSet ts in torchSets) {
			yield return new WaitForSeconds(ts.delay);
			Debug.Log("Turning off some torches");
			foreach (Transform torch in ts.torches) {
				torch.FindChild("Fire").gameObject.active = false;
			}
		}
		sceneCue = SceneCue.FADE_WIND;
		Debug.Log("Done with torches");
	}

	IEnumerator FadeOut() {
		sceneCue = SceneCue.WAIT;
		while (audio.volume > 0.0f) {
			audio.volume -= Time.deltaTime * 0.1f;
			Debug.Log(audio.volume);
			yield return null;
		}
		sceneCue = SceneCue.SCENE_CHANGE;
	}

	IEnumerator FadeToBlack() {
		while (fade_amt < fade_time) {
			fade_amt += Time.deltaTime;
			yield return null;
		}
	}

	IEnumerator SceneChange() { 
		yield return new WaitForSeconds(5.0f);
		Application.LoadLevel(newLevel);
	}

	[System.Serializable]
	public class TorchSet {

		public Transform[] torches;
		public float delay;
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
