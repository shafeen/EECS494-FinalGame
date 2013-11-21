using UnityEngine;
using System.Collections;

public class CrystalDoorOpen : MonoBehaviour {

	private bool is_open = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (transform.FindChild("door_light").GetComponent<Light>().intensity > GetComponent<CrystalLightScript>().GetMixedColorThreshold() && !is_open) {

			GameObject.Find("Crystal_Green_Door").animation.Play("cave door open");
			is_open = true;
		}
	}
}
