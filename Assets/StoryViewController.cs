using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using matnesis.TeaTime;
using UnityEngine.SceneManagement;

public class StoryViewController : MonoBehaviour {

	public Button play;
	public AudioClip buttonSound;

	// Use this for initialization
	void Start () {

		play.onClick.AddListener (delegate(){

			SoundManager.Get.PlayClip(buttonSound, false);
			this.tt("delay").Add(0.4f, delegate() {
				SceneManager.LoadScene("main-gameBackUp");
			});

		});

	}
}
