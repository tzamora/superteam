using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using matnesis.TeaTime;

public class MainTitleViewController : MonoBehaviour {

	public Button startButton;
	public Button creditsButton;

	public AudioClip buttonSound;

	// Use this for initialization
	void Start () {
	
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
