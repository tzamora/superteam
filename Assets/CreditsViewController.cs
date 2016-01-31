using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditsViewController : MonoBehaviour {

	public Button backButon;

	// Use this for initialization
	void Start () {
	
		backButon.onClick.AddListener (delegate() {

			SceneManager.LoadScene("main-title");

		});

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
