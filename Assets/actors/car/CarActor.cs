using UnityEngine;
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

	// Use this for initialization
	void Start () {

		MoveRoutine ();

		JumpRoutine ();
	}

	void MoveRoutine(){

		//globals to routine
		float xAxis = 0f;
		float yAxis = 0f;

		//Vector3 downMovementVector = new Vector3(0f,-10f,0f);
		//float oldY = 0f;
		this.tt ("acc").If (() => Input.GetAxis ("accelerate") > 0f).Loop(delegate(ttHandler accelerateRoutineHandler) {

			if(Input.GetAxis ("accelerate") > 0f){
				
				yAxis = Mathf.InverseLerp(0f,.3f,accelerateRoutineHandler.timeSinceStart);
				//print("yaxis wtf: " + yAxis);
				magnitude = yAxis * currentSpeed;

				//rigidBody.velocity = (yAxis * (transform.forward) * moveSpeed);

				rigidBody.velocity = Vector3.Lerp(rigidBody.velocity, movement, Time.deltaTime);

				//oldY = rigidBody.velocity.y;

				//transform.Translate(yAxis * Vector3.forward * moveSpeed * Time.deltaTime);
			}
			else {
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

			print("current speed " + currentSpeed);

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

			//print("la magnitud deberia de ser cero : " + magnitude );

			//print("que putas tiene yaxis: " + yAxis );

			Debug.DrawLine(floorSensor.position, floorSensor.position + Vector3.down, Color.red);

		});

	}

	void JumpRoutine(){
	
		this.tt ("JumpRoutine").Loop (delegate(ttHandler loopHandler) {

			if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown ("joystick 1 button 0")){

				//print("we jump");

				this.rigidBody.AddForce(Vector3.up * jumpForce);

			}

		});

	}
}
