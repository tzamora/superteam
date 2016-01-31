using UnityEngine;
using System.Collections;

public class TriggerRespawnController : MonoBehaviour {

	public Transform respawnPoint;


	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.GetComponent<SuperCarController> () != null) {
			other.transform.position = respawnPoint.position;
		}
	}
}
