﻿using UnityEngine;
using System.Collections;

public class WheelTurn : MonoBehaviour {
	public WheelCollider FRColl;
	public WheelCollider FLColl;
	public WheelCollider BRColl;
	public WheelCollider BLColl;
	public Transform FRWheel;
	public Transform FLWheel;
	public Transform BRWheel;
	public Transform BLWheel;

	private float steer_max = 20;
	private float torque_max = 10;
	private float brake_max = 20;

	private float steer = 0;
	private float torque = 0;
	private float brake = 0;
	private float back = 0;
	private float forward = 0;
	private bool reverse = false;
	private float speed = 0;

	private bool activated = false;
	private Transform cart;

	public void Start(){
		cart = transform.parent;
		Vector3 temp = new Vector3(0,-2,0);
		cart.rigidbody.centerOfMass = temp;
	}
	public void activate(){
		activated = true;
	}
	public void deactivate(){
		activated = false;
	}
	public bool isActive(){
		return activated;
	}
	void FixedUpdate () {

		speed = cart.rigidbody.velocity.sqrMagnitude;

		if(activated) {
			steer = Mathf.Clamp(Input.GetAxis("L_XAxis_1") + Input.GetAxis("Horizontal"),-1,1);
			forward = Mathf.Clamp(Input.GetAxis("Vertical") + Input.GetAxis("L_YAxis_1"), 0, 1);
			back = -1 * Mathf.Clamp(Input.GetAxis("Vertical")+Input.GetAxis("L_YAxis_1"), -1, 0);
			if(speed < 0.01) {
				if(back > 0) {
					reverse = true;
				}
				if(forward > 0) {
					reverse = false;
				}
			}
			
			if(reverse) {
				torque = -1 * back;
				brake = forward;
			}
			else {
				torque = forward;
				brake = back;
			}
		}
		else {
			steer = 0;
			torque = 0;
			if(speed < 0.01) {
				brake = 0;
			}
			else {
				brake = 1;
			}
		}
		FRColl.steerAngle = steer * steer_max;
		FLColl.steerAngle = steer * steer_max;
		BRColl.motorTorque = torque * torque_max;
		BLColl.motorTorque = torque * torque_max;
		BRColl.brakeTorque = brake * brake_max;
		BLColl.brakeTorque = brake * brake_max;

		FRWheel.Rotate(0,FRColl.rpm * -6 * Time.deltaTime,0, Space.Self);
		FLWheel.Rotate(0,FLColl.rpm * -6 * Time.deltaTime,0, Space.Self);
		BRWheel.Rotate(0,BRColl.rpm * -6 * Time.deltaTime,0, Space.Self);
		BLWheel.Rotate(0,BLColl.rpm * -6 * Time.deltaTime,0, Space.Self);
	}
}