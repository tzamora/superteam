using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using matnesis.TeaTime;

public class SuperCarController : MonoBehaviour {

	public GamepadInControl gamepad;

	public Rigidbody rigidBody;

	public GameObject trail;

	public float motorForce;
	public float motorForceMultiplier;
	public float brakeForce;
	public float steerForce;
	public float dashImpulse;

	public float jumpForce;

	public AudioClip jumpSound;
	public AudioClip motorSound;

	public WheelCollider frontLeftWheel;
	public WheelCollider frontRightWheel;
	public WheelCollider rearLeftWheel;
	public WheelCollider rearRightWheel;

	public GameObject frontLeftWheelPivot;
	public GameObject frontRightWheelPivot;

	public GameObject frontLeftWheelMesh;
	public GameObject frontRightWheelMesh;

	public List<CharmTypes> charmsToSearch;

	public float brakeTorque =  0;

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
		float steerAngle =  0;

		if (gamepad.actions == null){ 
			return;
		}

		wheelRPM = rearLeftWheel.rpm;

		if (gamepad.actions.Accelerate.IsPressed) {

			rearLeftWheel.brakeTorque = 0f;
			rearRightWheel.brakeTorque = 0f;
			motorTorque = motorForce * motorForceMultiplier;
			rearLeftWheel.motorTorque = motorTorque;
			rearRightWheel.motorTorque = motorTorque;

		} else if (gamepad.actions.Desaccelerate.IsPressed) {

			rearLeftWheel.brakeTorque = 0f;
			rearRightWheel.brakeTorque = 0f;
			motorTorque = -1f * motorForce * motorForceMultiplier;
			rearLeftWheel.motorTorque = motorTorque;
			rearRightWheel.motorTorque = motorTorque;

		}
		else if (gamepad.actions.Break.IsPressed) {

//			brakeTorque = -1f * brakeForce;
//
//			rearLeftWheel.brakeTorque = brakeTorque;
//			rearRightWheel.brakeTorque = brakeTorque;
			rearLeftWheel.brakeTorque = 0.1f;
			rearRightWheel.brakeTorque = 0.1f;
		}
		else {

			this.tt ("brakedelay").Add(0.8f, delegate() {
				rearLeftWheel.brakeTorque = brakeTorque;
				rearRightWheel.brakeTorque = brakeTorque;	
			});

		}

//		if(gamepad.actions.Break.IsPressed){
//			
//			rearLeftWheel.brakeTorque = 5f;
//			rearRightWheel.brakeTorque = 5f;
//		}

		steerAngle = Mathf.Clamp(gamepad.actions.Movement.X,-0.5f,0.5f) * steerForce;
		frontLeftWheel.steerAngle = steerAngle;
		frontRightWheel.steerAngle = steerAngle;

		// change the visuals of the wheel model
		frontLeftWheelPivot.transform.localEulerAngles = new Vector3(
			frontLeftWheelPivot.transform.localEulerAngles.x,
			steerAngle,
			frontLeftWheelPivot.transform.localEulerAngles.z
		);

		frontRightWheelPivot.transform.localEulerAngles = new Vector3(
			frontRightWheelPivot.transform.localEulerAngles.x,
			steerAngle,
			frontRightWheelPivot.transform.localEulerAngles.z
		);

		frontLeftWheelMesh.transform.Rotate (new Vector3 (-1f * motorTorque * Time.deltaTime, 0f, 0f));

		frontRightWheelMesh.transform.Rotate (new Vector3 (-1f * motorTorque * Time.deltaTime, 0f, 0f));

	}

	public void PullDownRoutine(){

		this.tt ("PullDownRoutine").Loop (delegate(ttHandler pullDownRoutineHandler) {

			transform.rotation = Quaternion.Euler(new Vector3 (0f, transform.eulerAngles.y, 0f));

			RaycastHit hit;

//			bool hitting = Physics.Raycast(floorSensor.position,Vector3.down,out hit,1.5f);
//
//			print("hitting");

//			if(!hitting) // not touching floor
//			{
//				rigidBody.velocity = Vector3.Lerp(rigidBody.velocity, Physics.gravity * 1f, Time.deltaTime);
//			}
//
//			Debug.DrawLine(floorSensor.position, floorSensor.position + Vector3.down, Color.red);

		});
	}

	public void JumpRoutine(){
		this.tt ("JumpRoutine").Loop (delegate(ttHandler moveRoutineHandler) {

			if (gamepad.actions == null){
				return;
			}

			if (gamepad.actions.Jump.WasPressed) {
				SoundManager.Get.PlayClip(jumpSound, false);
				this.rigidBody.AddForce(Vector3.up * jumpForce);
			}

		});
	}

	public void DashRoutine(){

		this.motorForceMultiplier = 1;

		this.tt ("DashRoutine").Loop (delegate(ttHandler moveRoutineHandler) {
			
			if (gamepad.actions == null){
				return;
			}

			if(gamepad.actions.Dash.WasPressed){
				print("esto solo va a ocurrir una vez por presionada");
				trail.SetActive(true);

				this.rigidBody.AddForce(transform.forward * dashImpulse,ForceMode.Impulse);

				this.tt("brakedash").Add(0.6f, delegate() {
					this.rigidBody.AddForce(-transform.forward,ForceMode.Impulse);
					trail.SetActive(false);
				});
			}

		});
	}
}
