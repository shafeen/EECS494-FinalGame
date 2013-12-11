	using UnityEngine;
using System.Collections;

public class MixedCrystalBridgeScript : MonoBehaviour {

	private bool bridge_raised = false;

	public CrystalSet[] Crystal_Sets;
	public Transform Mixed_Crystal_Light;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Mixed_Crystal_Light && Mixed_Crystal_Light.GetComponent<Light>().intensity > 3.0) {
			RaiseBridge();
		} else if (HasChargedSet()) {
			RaiseBridge();
		} else {
			LowerBridge();
		}

	}

	void RaiseBridge() {
		if (!bridge_raised && !transform.Find("Bridge/Bridge_beam").animation.IsPlaying("Lower_Bridge")) {
			transform.Find("Bridge/Bridge_beam").animation.Play("Raise_Bridge");
			bridge_raised = true;
		}
	}

	void LowerBridge() {
		if (bridge_raised && !transform.Find("Bridge/Bridge_beam").animation.IsPlaying("Raise_Bridge")) {
			transform.Find("Bridge/Bridge_beam").animation.Play("Lower_Bridge");
			bridge_raised = false;
		}
	}

	bool HasChargedSet() {
		if (Crystal_Sets.Length == 0) {
			return false;
		}

		foreach (CrystalSet cs in Crystal_Sets) {
			if (SetIsCharged(cs)) {
				return true;
			}
		}

		return false;
	}

	bool SetIsCharged(CrystalSet cs) {

		if (cs.crystals.Length == 0) {
			return false;
		}

		foreach (Transform t in cs.crystals) {
			if (t.GetComponent<Light>().intensity < 3.0) {
				return false;
			}
		}

		return true;
	}

	[System.Serializable]
	public class CrystalSet {
		public Transform[] crystals;
	}
}
