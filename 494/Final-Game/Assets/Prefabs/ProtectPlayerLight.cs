using UnityEngine;
using System.Collections;

public class ProtectPlayerLight : MonoBehaviour {

	private const float MIN_BRIGHTNESS_THRESHOLD = 0.5f;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		ProtectPlayer();
	}

	public void ProtectPlayer() {
		
		//Get a list of all objects within our light radius
		Collider[] colliders = Physics.OverlapSphere(transform.position, GetComponent<Light>().range);
		
		//If the player is within our light radius, protect him from baddies
		foreach (Collider col in colliders) {
			if (col.tag == "Player" && GetComponent<Light>().intensity > MIN_BRIGHTNESS_THRESHOLD) {
				//Notify the player that he is safe
				col.transform.GetComponent<RespawnTimer>().addTime();
			}
		}
	}
}
