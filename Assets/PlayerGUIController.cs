using UnityEngine;
using System.Collections;
using matnesis.TeaTime;
using UnityEngine.UI;

public class PlayerGUIController : MonoBehaviour {

	public Text playerMessage;
	public GameObject messagePanel;

	// Use this for initialization
	void Start () {

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
