using UnityEngine;
using System.Collections;

public class WindScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			if (!audio.isPlaying) {
				audio.Play();
			}
		}
	}
}
