using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using matnesis.TeaTime;
using UnityEngine.UI;

public class PlayerGUIController : MonoBehaviour {

	public Text playerMessage;

	public GameObject messagePanel;

	public List<GameObject> charmPlaceholders;

	// Use this for initialization
	void Start () {



	}

	public void addRitualCharms(List<RitualCharmController> charms){


		int counter = 0;
		foreach(RitualCharmController charm in charms)
		{
			GameObject clone = GameObject.Instantiate (charm.charmObject.gameObject, Vector3.zero, Quaternion.identity) as GameObject;
			//clone.transform.localScale = Vector3.one;
			clone.transform.parent = charmPlaceholders[counter].transform;
			clone.transform.localRotation = Quaternion.identity;
			clone.transform.localPosition = Vector3.zero;
			//clone.transform.localScale = new Vector3(6f,6f,6f);
			//clone.transform.localEulerAngles = new Vector3 (0f, 90f, 0f);

			this.tt ().Loop (delegate(ttHandler obj) {
			
				clone.transform.Rotate(Vector3.up * 17f * Time.deltaTime);

			});


			counter++;
		}

	}

	public void showMessage(string message){
	
		playerMessage.color = new Color (1f, 1f, 1f, 0f);

		playerMessage.text = message;

		messagePanel.SetActive (true);

		Image img = messagePanel.GetComponent<Image>();

		this.tt ("FadeInRoutine").Loop (2f, delegate(ttHandler handler) {
			
			playerMessage.color = new Color (1f, 1f, 1f, handler.t);

		}).Add(4f).Loop(2f, delegate(ttHandler handler) {
			
			playerMessage.color = new Color (1f, 1f, 1f, 1f - handler.t);

			img.color = new Color (1f, 1f, 1f, 1f - handler.t);

		}).Add(delegate() {
			messagePanel.SetActive (false);
		});

	}

}
