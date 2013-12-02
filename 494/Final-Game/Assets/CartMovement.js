#pragma strict

public var FRColl : WheelCollider;
public var FLColl : WheelCollider;
public var BRColl : WheelCollider;
public var BLColl : WheelCollider;

public var FRWheel : Transform;
public var FLWheel : Transform;
public var BRWheel : Transform;
public var BLWheel : Transform;
 
var steer_max = 20;
private var steer = 0;
private var activated:boolean = true;
 
public function activate(){
	activated = true;
}
public function deactivate(){
	activated = false;
}

function FixedUpdate () {
	if(activated) {
		steer = Mathf.Clamp(Input.GetAxis("R_XAxis_1") + Input.GetAxis("Horizontal"),-1,1)*steer_max;
	}
	else {
		steer = 0;
	}
	BRColl.motorTorque = 20;
	BLColl.motorTorque = 20;

	FRColl.steerAngle = steer;
	FLColl.steerAngle = steer;
	BRColl.steerAngle = steer;
	BLColl.steerAngle = steer;

	//rearWheel1.motorTorque = motor_max * motor;
	//rearWheel2.motorTorque = motor_max * motor;
 
	FRWheel.localEulerAngles.x = steer;
	FLWheel.localEulerAngles.x = steer;
 
	FRWheel.Rotate(0, FRColl.rpm * -6 * Time.deltaTime, 0);
	print(FRColl.rpm);print(FLColl.rpm);
	FLWheel.Rotate(0, FLColl.rpm * -6 * Time.deltaTime, 0);
	BRWheel.Rotate(0, BRColl.rpm * -6 * Time.deltaTime, 0);
	BLWheel.Rotate(0, BLColl.rpm * -6 * Time.deltaTime, 0);
 
}