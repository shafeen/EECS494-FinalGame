using UnityEngine;
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
	private float torque_max = 20;
	private float steer = 1;
	private float torque = 1;
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
		if(activated) {
			steer = Mathf.Clamp(Input.GetAxis("L_YAxis_1") + Input.GetAxis("Horizontal"),-1,1);
			//torque = Mathf.Clamp(Input.GetAxis("Vertical") + Input.GetAxis("L_YAxis_1"),-1,1);
		}
		else {
			steer = 0;
			//torque_max = 0;
		}
		FRColl.steerAngle = steer * steer_max;
		FLColl.steerAngle = steer * steer_max;
		//BRColl.motorTorque = torque * torque_max;
		//BLColl.motorTorque = torque * torque_max;

		FRWheel.Rotate(0,FRColl.rpm * 6 * Time.deltaTime,0, Space.Self);
		FLWheel.Rotate(0,FLColl.rpm * -6 * Time.deltaTime,0, Space.Self);
		BRWheel.Rotate(0,BRColl.rpm * -6 * Time.deltaTime,0, Space.Self);
		BLWheel.Rotate(0,BLColl.rpm * -6 * Time.deltaTime,0, Space.Self);
	}
}