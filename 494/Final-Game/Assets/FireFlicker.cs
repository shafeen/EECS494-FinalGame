using UnityEngine;
using System.Collections;

public class FireFlicker : MonoBehaviour {

	private float max_light_intensity;
	private float min_light_intensity;
	private Vector3 light_position;
	private float light_variance = 1.0f;
	private bool change = false;
	private float lerp_time = 0.0f;
	private float random;

	// Use this for initialization
	void Start () {
		light_position = transform.position;
		max_light_intensity = GetComponent<Light>().intensity;
		min_light_intensity = max_light_intensity - light_variance;
		random = Random.Range(0.0f, 1000.0f);
	}
	
	// Update is called once per frame
	void Update () {

//		if (lerp_time <= 0) {
//			lerp_time = Random.Range(0.1f, 0.5f);
//			Debug.Log(lerp_time);
//			change = true;
//		}
//
//		lerp_time -= Time.deltaTime;
//
//		if (change) { 
//			if (GetComponent<Light>().intensity == max_light_intensity) {
//				GetComponent<Light>().intensity = min_light_intensity;
//			} else {
//				GetComponent<Light>().intensity = max_light_intensity;
//			}
//			change = false;
		float noise = Mathf.PerlinNoise(random, Time.time);
		//float noise = Random.Range(0.8f, 1.5f);
		Vector3 new_light_position = new Vector3(light_position.x + GetRandom(), light_position.y + GetRandom(), light_position.z + GetRandom());
		GetComponent<Light>().intensity = Mathf.Lerp(min_light_intensity, max_light_intensity, noise);
		transform.position = Vector3.Lerp(light_position, new_light_position, noise);
	}

	private float GetRandom() {
		return Random.Range(-0.2f, 0.2f);
	}
}
