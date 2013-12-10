using UnityEngine;
using System.Collections;

public class FallOnHit : MonoBehaviour {
	private ParticleSystem fire;
	public AudioSource thump;
	void Start() {
		fire = transform.Find("Torch/Fire").gameObject.particleSystem;
	}
	void OnCollisionEnter(Collision other) {
		print("Ok");
		if(other.rigidbody) {
			thump.pitch = Random.Range(0.5F,2.0F);
			thump.PlayOneShot(thump.clip);
			rigidbody.useGravity = true;
			fire.enableEmission = false;
		}
	}
}
