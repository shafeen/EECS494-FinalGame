using UnityEngine;
using System.Collections;

public class StoneDoorAudioScript : MonoBehaviour {

	AudioSource[] audios;

	void Start() {
		audios = GetComponents<AudioSource>();
	}

	void PlaySound() {
		audios[1].Play();
	}

	void StopSound() {
		audios[1].Stop();
	}
}
