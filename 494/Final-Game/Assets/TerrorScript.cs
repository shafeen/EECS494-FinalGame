using UnityEngine;
using System.Collections;

public class TerrorScript : MonoBehaviour {
	private const float MAX_TERROR = 1.0f;
	private const float MIN_TERROR = 0.0f;
	private float terror_level = 0.0f;
	public const float TERROR_STEP = 0.1f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (terror_level < MAX_TERROR) {
			terror_level += (TERROR_STEP * Time.deltaTime);
		}
		Debug.Log("Terror level is: " + terror_level);
	}

	public void ReduceTerror() {
		//Function for reducing the terror level
	}

	public void ResetTerror() {
		//Function for fully resetting the terror level
		terror_level = MIN_TERROR;
	}
}
