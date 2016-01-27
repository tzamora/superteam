using UnityEngine;
using System.Collections;
using matnesis.TeaTime;

public class CameraActor : MonoBehaviour {

	public Transform player;

	// Use this for initialization
	void Start () {
	
		this.tt ("FollowRoutine").Loop (delegate(ttHandler handler) {

			transform.position = new Vector3(Mathf.Lerp(transform.position.x, player.position.x,Time.deltaTime * 2f),transform.position.y,transform.position.z);

		});

	}
}
