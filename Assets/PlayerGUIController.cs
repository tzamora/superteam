using UnityEngine;
using System.Collections;
using matnesis.TeaTime;
using UnityEngine.UI;

public class PlayerGUIController : MonoBehaviour {

	public Text playerMessage;

	// Use this for initialization
	void Start () {

	}

	void showMessage(string message){
	
		playerMessage.canvasRenderer.SetAlpha (0);

		playerMessage.text = message;

		this.tt ("FadeInRoutine").Loop (2f, delegate(ttHandler handler) {
		
			playerMessage.canvasRenderer.SetAlpha (handler.t);

		}).Add(4f).Loop(2f, delegate(ttHandler handler) {

			playerMessage.canvasRenderer.SetAlpha (1 - handler.t);

		});

	}

}
