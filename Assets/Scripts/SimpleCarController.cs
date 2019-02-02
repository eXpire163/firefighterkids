using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SimpleCarController : MonoBehaviour {
	public List<AxleInfo> axleInfos; // the information about each individual axle
	public float maxMotorTorque; // maximum torque the motor can apply to wheel
	public float maxSteeringAngle; // maximum steer angle the wheel can have


	public Transform minimapCamera;

	public Vector3 temp ;

	public void FixedUpdate()
	{
		float motor = maxMotorTorque * Input.GetAxis("Vertical");
		float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

		foreach (AxleInfo axleInfo in axleInfos) {
			if (axleInfo.steering) {
				axleInfo.leftWheel.steerAngle = steering;
				axleInfo.rightWheel.steerAngle = steering;
			}
			if (axleInfo.motor) {
				axleInfo.leftWheel.motorTorque = motor;
				axleInfo.rightWheel.motorTorque = motor;
			}

			axleInfo.leftWheel.transform.Rotate (0,-axleInfo.leftWheel.rpm, 0);
			axleInfo.rightWheel.transform.Rotate (0,-axleInfo.rightWheel.rpm, 0);

		}
		if (minimapCamera != null) {
			minimapCamera.transform.rotation = Quaternion.Euler (new Vector3 (90, this.transform.parent.eulerAngles.y, 0));
		}
		if (Input.GetKey (KeyCode.R)) {
			transform.parent.rotation = Quaternion.Euler( new Vector3 (transform.parent.rotation.eulerAngles.x, transform.parent.rotation.eulerAngles.y, 0));
		
		}

	}

}

[System.Serializable]
public class AxleInfo {
	public WheelCollider leftWheel;
	public WheelCollider rightWheel;
	public bool motor; // is this wheel attached to motor?
	public bool steering; // does this wheel apply steer angle?
}