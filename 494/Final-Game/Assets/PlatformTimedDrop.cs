using UnityEngine;
using System.Collections;

public class PlatformTimedDrop : MonoBehaviour {

	private float startTime;
	public  float dropDelay;
	private bool done = false;
	private bool countdownStart = false;
	private bool gravityOn = false;
	private ParticleSystem fire;

	void Start() {
		fire = transform.parent.Find("Torch/Fire").gameObject.particleSystem;
	}
	// Update is called once per frame
	void Update () {

		if (countdownStart) 
		{	
			if((Time.time - startTime) > dropDelay && !done) {
				transform.parent.rigidbody.useGravity = true;
				transform.parent.rigidbody.AddTorque(new Vector3(randomNum()*Random.Range(30F,100F), randomNum()*Random.Range(30F,50F), randomNum()*Random.Range(30F,100F)));
				fire.enableEmission = false;
				done = true;
			}
			else if((Time.time - startTime) > (dropDelay - 2.5) && !transform.parent.rigidbody.useGravity) {
				fire.startColor = Color.blue;
				fire.emissionRate = 90;
				fire.startSpeed = 5;
				fire.startLifetime = 2.5F;
				fire.simulationSpace = ParticleSystemSimulationSpace.World;
			}
		}

	}
	
	void OnTriggerEnter(Collider other) 
	{
		if(other.tag == "Player") {

			if (!countdownStart) 
			{
				countdownStart = true;
				startTime = Time.time;
			}
		}
	}
	private int randomNum () { 
		if (Random.value >= 0.5) {	
			return 1;
		}
		return -1;
	}

}
