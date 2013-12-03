using UnityEngine;
using System.Collections;

public class CrystalBridgeScript : MonoBehaviour {

	private bool bridge_raised = false;

	public Transform[] crystals;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (transform.Find("light").GetComponent<Light>().intensity > 3.0) {
			RaiseBridge();
		} else if (AllCrystalsLit()) {
			RaiseBridge();
		} else {
			LowerBridge();
		}

	}

	void RaiseBridge() {
		if (!bridge_raised) {
			transform.Find("Bridge/Bridge_beam").animation.Play("Raise_Bridge");
			bridge_raised = true;
		}
	}

	void LowerBridge() {
		if (bridge_raised) {
			transform.Find("Bridge/Bridge_beam").animation.Play("Lower_Bridge");
			bridge_raised = false;
		}
	}

	bool AllCrystalsLit() {
		if (crystals.Length == 0) {
			return false;
		}

		foreach (Transform t in crystals) {
			if (t.GetComponent<Light>().intensity < 3.0) {
				return false;
			}
		}
		return true;
	}
}
