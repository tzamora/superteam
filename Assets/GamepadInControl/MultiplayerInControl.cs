
// @matnesis
// 2015/10/23 11:44 PM


using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using matnesis.TeaTime;
using InControl;



public class MultiplayerInControl : MonoBehaviour
{
	public List<GamepadInControl> players = null; // Players list
	public int deviceCount = 0; // Current controls connected

	[Header("Last Refresh")]
	public List<GamepadInControl> playersWithoutDevice;
	public List<InputDevice> busyDevices;
	public List<InputDevice> freeDevices;
	public GamepadInControl keyboardPlayer = null;


	void Start()
	{
		// When a new usb device is detected, the controls are reassigned
		// for the players without devices
		this.tt("RefreshDevices").Add(1, () =>
		{
			if (InputManager.Devices.Count != deviceCount)
			{
				deviceCount = InputManager.Devices.Count;
				AssignFreeDevicesToFreePlayers();
			}
		})
		.Repeat();


		// On 'Space' or 'Enter', a free tank will be activated for the
		// keyboard.
		this.tt("KeyboardPlayerDetection").Loop((ttHandler t) =>
		{
			if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter))
			{
				keyboardPlayer = players.Where(
				                     p => p.inputDevice == null ||
				                     !InputManager.Devices.Contains(p.inputDevice)).FirstOrDefault();


				// If there is a free lion
				if (keyboardPlayer != null)
				{
					keyboardPlayer.gameObject.SetActive(true);

					keyboardPlayer.useKeyboard = true;
					keyboardPlayer.forceActiveDevice = true;
					keyboardPlayer.SetInputDevice(null, -1);

					AssignFreeDevicesToFreePlayers();
				}
			}
		})
		.Wait();
		
		// Look for all the compatible players, except the active device
		players = FindObjectsOfType<GamepadInControl>().ToList();
	}


	// Assign free devices to free players.
	void AssignFreeDevicesToFreePlayers()
	{
		// Queries
		playersWithoutDevice = 
			players.Where(p => !p.useKeyboard && (p.inputDevice == null || !InputManager.Devices.Contains (p.inputDevice) )).ToList();
		
		busyDevices = players.Where(p => p.inputDevice != null).Select(d => d.inputDevice).ToList();

		freeDevices = InputManager.Devices.Where(d => !busyDevices.Contains(d)).ToList();


		// Players & Devices
		for (int i = 0; i < playersWithoutDevice.Count; i++)
		{
			// Free devices are the limit
			if (i >= freeDevices.Count)
			{
				// Turn off players without device
				if (playersWithoutDevice[i] != keyboardPlayer)
					playersWithoutDevice[i].gameObject.SetActive(false);

				continue;
			}

			playersWithoutDevice[i].gameObject.SetActive(true);
			playersWithoutDevice[i].SetInputDevice(freeDevices[i], i);
		}

		// now reset the cameras

		/// set the camera rect
		List<GamepadInControl> cars = FindObjectsOfType<GamepadInControl>().ToList();

		// if we have one player the rect should be 

		switch (players.Count) {
		case 1:
			cars [0].GetComponent<SuperCarController> ().carCamera.rect = new Rect (0f,0f,1f,1f);
			break;
		case 2:
			cars [0].GetComponent<SuperCarController> ().carCamera.rect = new Rect (0f,0f,1f,0.5f);
			cars [1].GetComponent<SuperCarController> ().carCamera.rect = new Rect (0f,0.5f,1f,0.5f);
			break;
		case 3:
			cars [0].GetComponent<SuperCarController> ().carCamera.rect = new Rect (0f,.5f,.5f,.5f);
			cars [1].GetComponent<SuperCarController> ().carCamera.rect = new Rect (.5f,.5f,.5f,.5f);
			cars [2].GetComponent<SuperCarController> ().carCamera.rect = new Rect (0f,0f,.5f,.5f);
			break;
		case 4:
			cars [0].GetComponent<SuperCarController> ().carCamera.rect = new Rect (0f,.5f,.5f,.5f);
			cars [1].GetComponent<SuperCarController> ().carCamera.rect = new Rect (.5f,.5f,.5f,.5f);
			cars [2].GetComponent<SuperCarController> ().carCamera.rect = new Rect (0f,0f,.5f,.5f);
			cars [3].GetComponent<SuperCarController> ().carCamera.rect = new Rect (.5f,0f,.5f,.5f);
			break;
		}


//		foreach(GamepadInControl player in cars){
//
//			// get the car
//			SuperCarController car = player.GetComponent<SuperCarController>();
//
//			//car.carCamera
//
//		}

		// Focus lions playing
		if (SuperTeamGameContext.mainCamera != null)
		{
			// Clean up the camera focus
//			LionGameContext.camera2D.focus = null;
//			LionGameContext.camera2D.focusGroup.Clear();
//
//			// Focus on players
//			foreach (GamepadInControl gamePad in players)
//			{
//				if (gamePad.gameObject.activeSelf)
//					LionGameContext.camera2D.focusGroup.Add(gamePad.gameObject.transform);
//			}
		}
	}
}
