using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using matnesis.TeaTime;

public class MainTitleViewController : MonoBehaviour {

	public Button startButton;
	public Button creditsButton;


	public AudioClip buttonSound;
	public AudioClip song;

	// Use this for initialization
	void Start () {

		SoundManager.Get.PlayClip (song, true);
	
		startButton.onClick.AddListener (delegate() {

			SoundManager.Get.PlayClip(buttonSound, false);
			this.tt("delay").Add(0.4f,delegate() {
				SceneManager.LoadScene("history");
			});

		});

		creditsButton.onClick.AddListener (delegate() {
			
			SoundManager.Get.PlayClip(buttonSound, false);
			this.tt("delay").Add(0.4f, delegate() {
				SceneManager.LoadScene("credits");	
			});

		});
	}
}
