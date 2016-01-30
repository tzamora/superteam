using UnityEngine;
using System.Collections;
using matnesis.TeaTime;

public class SuperCarController : MonoBehaviour {

	public GamepadInControl gamepad;

	public Rigidbody rigidBody;

	public float motorForce;
	public float motorForceMultiplier;
	public float brakeForce;
	public float steerForce;

	public float jumpForce;

	public WheelCollider frontLeftWheel;
	public WheelCollider frontRightWheel;
	public WheelCollider rearLeftWheel;
	public WheelCollider rearRightWheel;

	public float wheelRPM = 0f;

	public Transform floorSensor;


	// Use this for initialization
	void Start () {

		PullDownRoutine ();

		JumpRoutine ();

		DashRoutine ();

	}

	public void FixedUpdate() {

		float motorTorque =  0;
		float brakeTorque =  0;
		float steerAngle =  0;

		if (gamepad.actions == null){
			return;
		}

		wheelRPM = rearLeftWheel.rpm;

		if (gamepad.actions.Accelerate.IsPressed) {

//			rearLeftWheel.brakeTorque = 0f;
//			rearRightWheel.brakeTorque = 0f;
			motorTorque = motorForce * motorForceMultiplier;
			rearLeftWheel.motorTorque = motorTorque;
			rearRightWheel.motorTorque = motorTorque;

		} else if (gamepad.actions.Break.IsPressed) {

			brakeTorque = brakeForce;

			rearLeftWheel.brakeTorque = brakeTorque;
			rearRightWheel.brakeTorque = brakeTorque;
		}
//		else {
//			rearLeftWheel.brakeTorque = 0.1f;
//			rearRightWheel.brakeTorque = 0.1f;
//		}

//		if(gamepad.actions.Break.IsPressed){
//			
//			rearLeftWheel.brakeTorque = 5f;
//			rearRightWheel.brakeTorque = 5f;
//		}

		steerAngle = Mathf.Clamp(gamepad.actions.Movement.X,-0.5f,0.5f) * steerForce;
		frontLeftWheel.steerAngle = steerAngle;
		frontRightWheel.steerAngle = steerAngle;

	}

	public void PullDownRoutine(){

		bool hitting = false;

		this.tt ("PullDownRoutine").Loop (delegate(ttHandler pullDownRoutineHandler) {

			if(!hitting) // not touching floor
			{
				rigidBody.velocity = Vector3.Lerp(rigidBody.velocity, Physics.gravity * 5f, Time.deltaTime);
			}

			Debug.DrawLine(floorSensor.position, floorSensor.position + Vector3.down, Color.red);

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
