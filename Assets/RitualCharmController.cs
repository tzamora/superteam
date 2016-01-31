using UnityEngine;
using System.Collections;

public enum CharmTypes{
	DeadBook,
	HyperHorn,
	UltraCharm
}

public class RitualCharmController : MonoBehaviour {

	public AudioClip itemPickupSound;
	public AudioClip wrongPickupSound;

	public CharmTypes charmType;

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider other) {

		SuperCarController superCar = other.GetComponent<SuperCarController> ();

		if(superCar != null){

			if(superCar.charmsToSearch.Contains(this.charmType))

			SoundManager.Get.PlayClip (itemPickupSound, false);

			Destroy(this.gameObject);
		}
	}
}
