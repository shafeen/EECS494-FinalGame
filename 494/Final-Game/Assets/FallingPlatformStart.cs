using UnityEngine;
using System.Collections;

public class FallingPlatformStart : MonoBehaviour {
	private DontDestroyScript spawnPoint;
	private ParticleSystem fire;
	public GameObject platform;
	private bool done = false;
	private float time;
	private bool activated = false;
	void Start () {
		spawnPoint = GameObject.Find("SpawnPointHolder").GetComponent<DontDestroyScript>();
		fire = platform.transform.Find("Torch/Fire").particleSystem;
	}
	void OnTriggerEnter(Collider other) {
		if(!activated) {
			activated = true;
			time = Time.time;
			fire.startColor = Color.blue;
			fire.emissionRate = 90;
			fire.startSpeed = 5;
			fire.startLifetime = 2.5F;
			platform.rigidbody.AddTorque(new Vector3(-50F,30F,100F));
		}
	}
	void FixedUpdate() {
		if(activated) {
			if(Time.time - time > 1.3 && platform && !done) {
				platform.rigidbody.useGravity = true;
				fire.enableEmission = false;
				done = true;
			}
		}
	}
}
