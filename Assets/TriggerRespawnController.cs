using UnityEngine;
using System.Collections;

public class TriggerRespawnController : MonoBehaviour {

	public Transform respawnPoint;

	public AudioClip song;

	// Use this for initialization
	void Start () {
	

		SoundManager.Get.PlayClip (song, true);
	}

	void OnTriggerEnter(Collider other){
		if (other.GetComponent<SuperCarController> () != null) {
			other.transform.position = respawnPoint.position;
		}
	}
}
