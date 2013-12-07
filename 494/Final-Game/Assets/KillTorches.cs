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

	IEnumerator SceneChange() { 
		yield return new WaitForSeconds(5.0f);
		Application.LoadLevel(newLevel);
	}

	[System.Serializable]
	public class TorchSet {

		public Transform[] torches;
		public float delay;
	}
}
