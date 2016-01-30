using UnityEngine;
using System.Collections;
using matnesis.TeaTime;

public class SuperCarController : MonoBehaviour {

	public GamepadInControl gamepad;

	public float motorForce;
	public float steerForce;

	public WheelCollider frontLeftWheel;
	public WheelCollider frontRightWheel;
	public WheelCollider rearLeftWheel;
	public WheelCollider rearRightWheel;


	// Use this for initialization
	void Start () {

		MoveRoutine ();

		// JumpRoutine ();

	}

	public void MoveRoutine(){
		this.tt ("MoveRoutine").Loop (delegate(ttHandler moveRoutineHandler) {

			float motorTorque =  0;
			float steerAngle =  0;

			if (gamepad.actions == null){
				return;
			}

			motorTorque = gamepad.actions.Movement.Y * motorForce;
			steerAngle = gamepad.actions.Movement.X * steerForce;


			frontLeftWheel.motorTorque = motorTorque;
			frontRightWheel.motorTorque = motorTorque;

			frontLeftWheel.steerAngle = steerAngle;
			frontRightWheel.steerAngle = steerAngle;

		});
	}
}
