using UnityEngine;
using System.Collections;

public class KillTorches : MonoBehaviour {

	public TorchSet[] torchSets;
	private float time = 0.0f;
	private bool start_scene = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (start_scene) {
			time += Time.deltaTime;

			foreach (TorchSet ts in torchSets) {
				if (ts.delay <= time) {
					foreach (Transform torch in ts.torches) {
						torch.FindChild("Fire").active = false;
					}
				}
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			start_scene = true;
		}
	}

	[System.Serializable]
	public class TorchSet {

		public Transform[] torches;
		public float delay;
	}
}
