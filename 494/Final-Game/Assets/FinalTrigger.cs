using UnityEngine;
using System.Collections;

public class FinalTrigger : MonoBehaviour {

	public GameObject[] particle_emitters;
	public TorchSet[] torchSets;

	private enum SceneCue{
		WAIT,
		START,
		PUT_OUT_TORCHES,
		GRAB_TEDDY,
		EXPLOSION,
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
		} else if (sceneCue == SceneCue.EXPLOSION) {
			StartCoroutine("ExplodeCrystals");
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
		sceneCue = SceneCue.GRAB_TEDDY;
		Debug.Log("Done with torches");
	}

	IEnumerator FlyAround() {
		sceneCue = SceneCue.WAIT;
		while (sceneCue == SceneCue.WAIT) {
			if (GameObject.FindWithTag("Monster")) {
				GameObject.FindWithTag("Monster").animation.Play("fly_around_monster");
				yield return new WaitForSeconds(1.0f);
			} else {
				sceneCue = SceneCue.EXPLOSION;
			}
		}
	}

	IEnumerator ExplodeCrystals() {
		//Explode crystals from here
		foreach (GameObject o in particle_emitters) {
			o.particleSystem.enableEmission = true;
		}
		yield return new WaitForSeconds(2.0f);
		foreach (GameObject o in particle_emitters) {
			o.particleSystem.enableEmission = false;
		}
		sceneCue = SceneCue.END;
	}

	[System.Serializable]
	public class TorchSet {
		
		public Transform[] torches;
		public float delay;
	}
}
