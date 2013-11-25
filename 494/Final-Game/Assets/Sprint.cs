using UnityEngine;
using System.Collections;

public class Sprint : MonoBehaviour {

	private float base_speed;
	private float sprint_speed;
	private float max_sprint_time = 5.0f;
	private float remaining_sprint_time = 5.0f;
	private float recharge_delay = 4.0f;
	private float recharge_time = 0.0f;

	// Use this for initialization
	void Start () {
		base_speed = GetComponent<CharacterMotor>().movement.maxForwardSpeed;
		sprint_speed = base_speed + 4;
	}
	
	// Update is called once per frame
	void Update () {

		if (recharge_time > 0) {
			recharge_time -= Time.deltaTime;
		}
	
		if (Input.GetKey("left shift") && remaining_sprint_time > 0) {
			GetComponent<CharacterMotor>().movement.maxForwardSpeed = sprint_speed;
			remaining_sprint_time -= Time.deltaTime;
			recharge_time = recharge_delay;
		} else {
			GetComponent<CharacterMotor>().movement.maxForwardSpeed = base_speed;
		}

		if (recharge_time <= 0 && remaining_sprint_time < max_sprint_time) {
			remaining_sprint_time += Time.deltaTime;
		}

	}
}
