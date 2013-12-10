using UnityEngine;
using System.Collections;

public class FinalTrigger : MonoBehaviour {

	public TorchSet[] torchSets;

	private enum SceneCue{
		WAIT,
		START,
		PUT_OUT_TORCHES,
		GRAB_TEDDY,
		END };
	
	private SceneCue sceneCue;
	
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			sceneCue = SceneCue.START;
		}
	}

	// Update is called once per frame
	void Update () {
		
		if (sceneCue == SceneCue.START) {
			StartCoroutine("PutOutTorches");
		} else if (sceneCue == SceneCue.GRAB_TEDDY) {
			StartCoroutine("FlyAround");
		}
	}

	IEnumerator PutOutTorches() {
		sceneCue = SceneCue.WAIT;
		GameObject.FindWithTag("Monster").animation.Play("grab_teddy");
		foreach (TorchSet ts in torchSets) {
			yield return new WaitForSeconds(ts.delay);
			Debug.Log("Turning off some torches");
			foreach (Transform torch in ts.torches) {
				torch.FindChild("Fire").gameObject.active = false;
			}
		}
//		while (GameObject.FindWithTag("Monster").animation.IsPlaying("grab_teddy") && GameObject.FindWithTag("Teddy").animation.IsPlaying("fly_up")) {
//			yield return null;
//		}
		sceneCue = SceneCue.GRAB_TEDDY;
		Debug.Log("Done with torches");
	}

	IEnumerator FlyAround() {
		sceneCue = SceneCue.WAIT;
		while (sceneCue == SceneCue.WAIT) {
//			GameObject.FindWithTag("Monster").animation.wrapMode = WrapMode.Loop;
//			GameObject.FindWithTag("Teddy").animation.wrapMode = WrapMode.Loop;
			GameObject.FindWithTag("Monster").animation.Play("fly_around_monster");
			yield return new WaitForSeconds(1.0f);
		}
		//sceneCue = SceneCue.END;
		;
	}

	[System.Serializable]
	public class TorchSet {
		
		public Transform[] torches;
		public float delay;
	}
}
