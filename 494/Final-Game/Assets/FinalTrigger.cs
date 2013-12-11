using UnityEngine;
using System.Collections;

public class FinalTrigger : MonoBehaviour {

	public ParticleSystem[] particle_emitters;
	public TorchSet[] torchSets;
	public GameObject Teddy_placeholder;

	private bool follow_monster = false;

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

		if (GameObject.FindWithTag("Monster") && follow_monster) {
			GameObject.FindWithTag("Teddy").transform.position = GameObject.FindWithTag("Monster").transform.position;
		}
		
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
				follow_monster = true;
				GameObject.FindWithTag("Monster").animation.Play("fly_around_monster");
				yield return new WaitForSeconds(1.0f);
			} else {
				sceneCue = SceneCue.EXPLOSION;
			}
		}
	}

	IEnumerator ExplodeCrystals() {
		//Explode crystals from here
		follow_monster = false;
		foreach (ParticleSystem o in particle_emitters) {
			o.enableEmission = true;
		}
//		yield return new WaitForSeconds(2.0f);
//		foreach (GameObject o in particle_emitters) {
//			o.particleSystem.enableEmission = false;
//		}
		sceneCue = SceneCue.END;
		GameObject.FindWithTag("Teddy").transform.position = Teddy_placeholder.transform.position;
		//GameObject.FindWithTag("Teddy").transform.GetChild(0).animation.Play("float_down");
		return null;
	}

	[System.Serializable]
	public class TorchSet {
		
		public Transform[] torches;
		public float delay;
	}
}
