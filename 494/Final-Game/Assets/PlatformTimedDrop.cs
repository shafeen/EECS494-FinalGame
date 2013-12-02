using UnityEngine;
using System.Collections;

public class PlatformTimedDrop : MonoBehaviour {

	public GameObject linkedFallingPlatform;

	private float startTime;
	public  float dropDelay;

	private bool countdownStart = false;
	private bool gravityOn = false;


	// Use this for initialization
	void Start () {

		dropDelay = 1.5f;

	}
	
	// Update is called once per frame
	void Update () {

		if (countdownStart) 
		{
			if((Time.time - startTime) > dropDelay)
				linkedFallingPlatform.rigidbody.useGravity = true;

		}

	}
	
	void OnTriggerEnter(Collider other) 
	{
		Debug.Log("C O L L I S I O N OCCURRED!");

		if (!countdownStart) 
		{
			countdownStart = true;
			startTime = Time.time;
		}


	}


}
