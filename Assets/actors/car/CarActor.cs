﻿using UnityEngine;
using System.Collections;
using matnesis.TeaTime;

public class CarActor : MonoBehaviour {

	public float moveSpeed = 10f;
	public float rotationSpeed = 20f;
	public Rigidbody rigidBody;
	public float jumpForce = 10f;
	public float speedMultiplier = 1f;

	//
	public Vector3 movement = Vector3.zero;
	public Vector3 direction;
	public float magnitude;

	float currentSpeed = 0; // cambiar estos nombres por unos bien bonitos, los de andres estan cool tratar de ponerle a este currentmagnitude

	public Transform floorSensor;

	public AudioClip jumpSound;

	public GamepadInControl gamepad;

	// Use this for initialization
	void Start () {

		SetGamepad ();

		MoveRoutine ();

		JumpRoutine ();
	}

	void SetGamepad (){
	
		gamepad = GetComponent<GamepadInControl> ();
	}

	void MoveRoutine(){

		//globals to routine
		float xAxis = 0f;
		float yAxis = 0f;

		//this.tt ("acc").If (() => Input.GetAxis ("accelerate") > 0f).Loop(delegate(ttHandler accelerateRoutineHandler) {
		this.tt ("acc").Loop(delegate(ttHandler accelerateRoutineHandler) {

			if(gamepad.actions == null){
				return;
			}

			print("cuantas veces se esta llamando esto?" + gamepad.actions.Accelerate);

			if(Input.GetAxis ("accelerate") > 0f || gamepad.actions.Accelerate.IsPressed){
				
				yAxis = Mathf.InverseLerp(0f,.3f,accelerateRoutineHandler.timeSinceStart);
				rigidBody.velocity = Vector3.Lerp(rigidBody.velocity, movement, Time.deltaTime);

			} else {

				print("el mae se salio");
				//accelerateRoutineHandler.self.Restart();

			}
		}).Repeat();

		// des acc
		this.tt ("desaccelerate").If (() => Input.GetAxis ("desaccelerate") > 0f).Loop(delegate(ttHandler accelerateRoutineHandler) {

			if(Input.GetAxis ("desaccelerate") > 0f){

				print("entramos aca al suave");

				yAxis = -1 * Mathf.InverseLerp(0f,.3f,accelerateRoutineHandler.timeSinceStart);

				print("yaxis: " + yAxis);

				//print("la magnitud deberia de irse a zero: " + magnitude);

				//rigidBody.velocity = (yAxis * (transform.forward) * moveSpeed);

				rigidBody.velocity = Vector3.Lerp(rigidBody.velocity, movement, Time.deltaTime);

				//oldY = rigidBody.velocity.y;

				//transform.Translate(yAxis * Vector3.forward * moveSpeed * Time.deltaTime);
			}
			else {
				print("se fue en el else");
				accelerateRoutineHandler.self.Restart();
			}
		}).Repeat();


		this.tt ("MoveRoutine").Loop (delegate(ttHandler moveRoutineHandler) {

			//if(Time.timeSinceLevelLoad )

			xAxis = Input.GetAxis("Horizontal");

			//yAxis = Input.GetAxis("Vertical");

			//print();

			currentSpeed = moveSpeed;

			if(Input.GetKey(KeyCode.LeftShift ) || Input.GetAxis ("dash") > 0){
				currentSpeed = moveSpeed * speedMultiplier;
			}else{
				currentSpeed = moveSpeed;
			}

			movement = transform.forward;//transform.TransformDirection(direction.normalized);

			movement *= magnitude;

			//movement +=  Physics.gravity;

			//transform.Translate(yAxis * Vector3.forward * currentSpeed * Time.deltaTime);

			//transform.Rotate(Vector3.0up, xAxis * rotationSpeed * 15f * Time.deltaTime);

			transform.Rotate(xAxis * 10F * Vector3.up);

			//direction *= Quaternion.AngleAxis(xAxis * rotationSpeed * 15f * Time.deltaTime, Vector3.up);

			//print("euler " + direction);

			//rigidBody.AddForce(yAxis * direction.eulerAngles * 50000f);

			//transform.rotation = direction;

			//print("---> x" + movement);

			RaycastHit hit;

			bool hitting = Physics.Raycast(floorSensor.position,Vector3.down,out hit,1);

			//print("hitting - " + hitting);

			if(!hitting) // not touching floor
			{
				rigidBody.velocity = Vector3.Lerp(rigidBody.velocity, Physics.gravity * 5f, Time.deltaTime);	
			}

			magnitude = yAxis * currentSpeed;

			//print("la magnitud deberia de ser cero : " + magnitude );

			//print("que putas tiene yaxis: " + yAxis );

			Debug.DrawLine(floorSensor.position, floorSensor.position + Vector3.down, Color.red);

		});

	}

	void JumpRoutine(){
	
		this.tt ("JumpRoutine").Loop (delegate(ttHandler loopHandler) {

			if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown ("joystick 1 button 0")){

				print("we jump");

				this.rigidBody.AddForce(Vector3.up * jumpForce);

				SoundManager.Get.PlayClip(jumpSound, false);

			}

		});

	}
}
