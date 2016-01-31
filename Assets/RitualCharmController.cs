using UnityEngine;
using System.Collections;
using matnesis.TeaTime;

public enum CharmTypes{
	DeadBook,
	HyperHorn,
	UltraCharm
}

public class RitualCharmController : MonoBehaviour {

	public AudioClip itemPickupSound;
	public AudioClip wrongPickupSound;
	public GameObject charmBody;
	public CharmTypes charmType;

	// Use this for initialization
	void Start () {

		this.tt ("UpAndDownRoutine").Loop(0.8f, delegate(ttHandler handler) {

			charmBody.transform.localPosition = charmBody.transform.localPosition + (Vector3.up * 0.05f);

		}).Loop(0.8f, delegate(ttHandler handler) {
			
			charmBody.transform.localPosition = charmBody.transform.localPosition + (Vector3.down * 0.05f);
		
		}).Repeat();

		this.tt ("RotationRoutine").Loop(delegate(ttHandler handler) {

			charmBody.transform.Rotate(Vector3.up * 2f);

		});


	}

	void OnTriggerEnter(Collider other) {

		SuperCarController superCar = other.GetComponent<SuperCarController> ();

		if(superCar != null){

			if (superCar.charmsToSearch.Contains (this.charmType)) {
				SoundManager.Get.PlayClip (itemPickupSound, false);
				superCar.addCharm(this.charmType);
			} else {
				superCar.gui.showMessage("Wrong thou you fool!!");
			}



			Destroy(this.gameObject);
		}
	}
}
