using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class MainTitleViewController : MonoBehaviour {

	public Button startButton;
	public Button creditsButton;

	public AudioClip buttonSound;

	// Use this for initialization
	void Start () {
	
		startButton.onClick.AddListener (delegate() {

			SceneManager.LoadScene("test");

			SoundManager.Get.PlayClip(buttonSound, false);

		});

		creditsButton.onClick.AddListener (delegate() {

			SceneManager.LoadScene("credits");

			SoundManager.Get.PlayClip(buttonSound, false);

		});
	}
}
