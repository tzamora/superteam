using UnityEngine;
using System.Collections;
using matnesis.TeaTime;

public class SuperCarController : MonoBehaviour {

	public GamepadInControl gamepad;

	public Rigidbody rigidBody;

	public float motorForce;
	public float motorForceMultiplier;
	public float steerForce;

	public float jumpForce;

	public WheelCollider frontLeftWheel;
	public WheelCollider frontRightWheel;
	public WheelCollider rearLeftWheel;
	public WheelCollider rearRightWheel;

	public float wheelRPM = 0f;


	// Use this for initialization
	void Start () {

		MoveRoutine ();

		JumpRoutine ();

		DashRoutine ();

	}

	public void FixedUpdate() {

		float motorTorque =  0;
		float steerAngle =  0;

		if (gamepad.actions == null){
			return;
		}

		wheelRPM = rearLeftWheel.rpm;

		if (gamepad.actions.Accelerate.IsPressed) {

			rearLeftWheel.brakeTorque = 0f;
			rearRightWheel.brakeTorque = 0f;
			motorTorque = gamepad.actions.Accelerate.Value * motorForce * motorForceMultiplier;
			rearLeftWheel.motorTorque = motorTorque;
			rearRightWheel.motorTorque = motorTorque;

		} else if (gamepad.actions.Desaccelerate.IsPressed) {

			rearLeftWheel.brakeTorque = 0f;
			rearRightWheel.brakeTorque = 0f;
			motorTorque = (-1 * gamepad.actions.Desaccelerate.Value) * motorForce * motorForceMultiplier;
			rearLeftWheel.motorTorque = motorTorque;
			rearRightWheel.motorTorque = motorTorque;

		} else {
			rearLeftWheel.brakeTorque = 0.1f;
			rearRightWheel.brakeTorque = 0.1f;
		}

		if(gamepad.actions.Break.IsPressed){
			
			rearLeftWheel.brakeTorque = 5f;
			rearRightWheel.brakeTorque = 5f;
		}

		steerAngle = Mathf.Clamp(gamepad.actions.Movement.X,-0.5f,0.5f) * steerForce;
		frontLeftWheel.steerAngle = steerAngle;
		frontRightWheel.steerAngle = steerAngle;

	}

	public void MoveRoutine(){
		this.tt ("MoveRoutine").Loop (delegate(ttHandler moveRoutineHandler) {

		});
	}

	public void JumpRoutine(){
		this.tt ("JumpRoutine").Loop (delegate(ttHandler moveRoutineHandler) {

			if (gamepad.actions == null){
				return;
			}

			if (gamepad.actions.Jump.WasPressed) {
				this.rigidBody.AddForce(Vector3.up * jumpForce);
			}

		});
	}

	public void DashRoutine(){
		this.tt ("DashRoutine").Loop (delegate(ttHandler moveRoutineHandler) {

			if (gamepad.actions == null){
				return;
			}

			if (gamepad.actions.Dash.IsPressed) {
				print("vamos a ver si saltamos");
				this.motorForceMultiplier = 3;
			}else{
				this.motorForceMultiplier = 1;
			}


		});
	}
}
