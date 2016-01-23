using UnityEngine;
using System.Collections;
using matnesis.TeaTime;


public class BallActor : MonoBehaviour {

	public Rigidbody rigidBody;
	public float gravityFactor = 3;

	// Use this for initialization
	void Start () {

		this.tt ("ApplyGravityRoutine").Loop (delegate(ttHandler handler) {

			rigidBody.velocity = Vector3.Lerp(rigidBody.velocity, Physics.gravity * gravityFactor, Time.deltaTime);	

		});
	
	}
}
