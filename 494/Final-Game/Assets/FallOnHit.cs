using UnityEngine;
using System.Collections;

public class FallOnHit : MonoBehaviour {
	private ParticleSystem fire;
	void Start() {
		fire = transform.Find("Torch/Fire").gameObject.particleSystem;
	}
	void OnCollisionEnter(Collision other) {
		print("Ok");
		if(other.rigidbody) {
			rigidbody.useGravity = true;
			fire.enableEmission = false;
		}
	}
}
