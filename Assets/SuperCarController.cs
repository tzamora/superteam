using UnityEngine;
using System.Collections;
using matnesis.TeaTime;

public class SuperCarController : MonoBehaviour {

	public GamepadInControl gamepad;

	public float motorForce;

	public WheelCollider frontLeftWheel;
	public WheelCollider frontRightWheel;
	public WheelCollider rearLeftWheel;
	public WheelCollider rearRightWheel;


	// Use this for initialization
	void Start () {
		
		SetGamepad ();

		MoveRoutine ();

		// JumpRoutine ();

	}

	void SetGamepad (){

		gamepad = GetComponent<GamepadInControl> ();
	}

	public void MoveRoutine(){
		this.tt ("MoveRoutine").Loop (delegate(ttHandler moveRoutineHandler) {
			
			float torqueForce =  0;

			if(gamepad.actions.Accelerate.IsPressed){
				torqueForce = motorForce;
			}

			frontLeftWheel.motorTorque = torqueForce;

			frontRightWheel.motorTorque = torqueForce;

		});
	}
}
