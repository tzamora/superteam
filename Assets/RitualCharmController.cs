using UnityEngine;
using System.Collections;
using matnesis.TeaTime;
using System.Linq;

public enum CharmTypes{
	GreenBook,
	HyperHorn,
	BlueBook,
	RareSkull,
	RubyPentagram,
	RebornEgg,
	Pentagram,
	HybrydPotion
}

public class RitualCharmController : MonoBehaviour {

	public AudioClip itemPickupSound;
	public AudioClip wrongPickupSound;
	public GameObject charmBody;
	public GameObject charmObject;
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

			if (superCar.charmsToSearch.Where(c=>c.charmType == this.charmType).Any()) {
				SoundManager.Get.PlayClip (itemPickupSound, false);
				superCar.addCharm(this.charmType);
			} else {
				SoundManager.Get.PlayClip (wrongPickupSound, false);
				superCar.gui.showMessage("Wrong thou you fool!!");
			}

			Destroy(this.gameObject);
		}
	}
}
