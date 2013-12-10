using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

	public GameObject greencrys;
	public GameObject purplecrys;
	public GameObject orangecrys;
	public GameObject whitecrys;
	private bool scene_lock = false;

	// Update is called once per frame
	void Update () {
		if (!scene_lock &&
		    greencrys.GetComponent<Light>().intensity > 3.0f &&
		    purplecrys.GetComponent<Light>().intensity > 3.0f &&
		    orangecrys.GetComponent<Light>().intensity > 3.0f) {
			StartCoroutine("LightWhiteCrystal");
			scene_lock = true;
		}
	}

	IEnumerator LightWhiteCrystal() {
		while (whitecrys.GetComponent<Light>().intensity < 6.0f) {
			whitecrys.GetComponent<Light>().intensity += Time.deltaTime;
			yield return null;
		}

		whitecrys.GetComponent<Light>().intensity = 0.5f;


	}
}
