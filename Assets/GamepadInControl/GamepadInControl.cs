
// Manager that holds the connection between InControl and Action events.

// 2015/10/19 03:47 PM


using UnityEngine;
using InControl;
using System;


public class GamepadInControl : MonoBehaviour
{
	public bool update = true;

	[Header("Options")]
	public bool useKeyboard = false;
	public bool forceActiveDevice = false; // This component will use the active device

	[Header("Info")]
	public InputDevice inputDevice; // if null, InControl will use the current active device
	public int inputDeviceOrder = 0; // InControl device index

//	// Actions
//	public Action OnJump;
//	public Action OnActivate;
//	public Action OnDash;
//	public Action OnDashRelease;
//	public Action OnAttack;
//	public Action OnAttackRelease;
//	public Action OnCommand;
//
//	public Action onAccelerate;

	public GamepadInControlActionSet actions;

	// Movement vector
	public Vector2 Movement
	{
		get
		{
			return actions != null ? actions.Movement.Value : Vector2.zero;
		}
	}


	void Start()
	{
		if (forceActiveDevice)
			SetInputDevice(inputDevice, -1);
	}


//	void Update()
//	{
//		if (!update)
//			return;
//
//		if (actions == null)
//			return;
//
//
//		// My Actions
//		if (actions.Dash.WasPressed && OnDash != null){
//			OnDash();
//		}
//
//		// Actions
//		if (actions.Jump.WasPressed && OnJump != null)
//			OnJump();
//
//		if (actions.Activate.WasPressed && OnActivate != null)
//			OnActivate();
//
//		if (actions.Dash.WasPressed && OnDash != null)
//			OnDash();
//
//		if (actions.Dash.WasReleased && OnDashRelease != null)
//			OnDashRelease();
//
//		if (actions.Attack.WasPressed && OnAttack != null)
//			OnAttack();
//
//		if (actions.Attack.WasReleased && OnAttackRelease != null)
//			OnAttackRelease();
//
//
//		// Main menu
//		if (actions.Command.WasPressed && OnCommand != null)
//			OnCommand();
//
//
//		// QuickInputTest();
//	}


	public void SetInputDevice(InputDevice newInputDevice, int order)
	{
		actions = new GamepadInControlActionSet();

		// Movement (Axis + Dpad + WASD + Keys)
		if (useKeyboard)
		{
			actions.Left.AddDefaultBinding(Key.A);
			actions.Left.AddDefaultBinding(Key.LeftArrow);

			actions.Right.AddDefaultBinding(Key.D);
			actions.Right.AddDefaultBinding(Key.RightArrow);

			actions.Accelerate.AddDefaultBinding(Key.W);
			actions.Accelerate.AddDefaultBinding(Key.UpArrow);

			actions.Down.AddDefaultBinding(Key.S);
			actions.Down.AddDefaultBinding(Key.DownArrow);

			actions.Command.AddDefaultBinding(Key.Escape);
		}
		else
		{
			actions.Left.AddDefaultBinding(InputControlType.DPadLeft);
			actions.Left.AddDefaultBinding(InputControlType.LeftStickLeft);

			actions.Right.AddDefaultBinding(InputControlType.DPadRight);
			actions.Right.AddDefaultBinding(InputControlType.LeftStickRight);

			actions.Up.AddDefaultBinding(InputControlType.DPadUp);
			actions.Up.AddDefaultBinding(InputControlType.LeftStickUp);

			actions.Down.AddDefaultBinding(InputControlType.DPadDown);
			actions.Down.AddDefaultBinding(InputControlType.LeftStickDown);

			// Actions
			actions.Accelerate.AddDefaultBinding(InputControlType.RightTrigger);

			actions.Desaccelerate.AddDefaultBinding(InputControlType.LeftTrigger);

			actions.Break.AddDefaultBinding(InputControlType.Action2);

			actions.Jump.AddDefaultBinding(InputControlType.Action1);

			actions.Dash.AddDefaultBinding(InputControlType.Action3);

			// Menu
			actions.Command.AddDefaultBinding(InputControlType.Command);
		}


		// Force the input device
		if (newInputDevice != null)
		{
			actions.Device = newInputDevice;

			inputDevice = newInputDevice;
			inputDeviceOrder = order;

			// Debug.Log(newInputDevice.GetHashCode());
			// Debug.Log(order);
		}
	}


	void QuickInputTest()
	{
		// Movement
		if (actions.Left.WasPressed)
			Debug.Log("Left " + Time.time);

		if (actions.Right.WasPressed)
			Debug.Log("Right " + Time.time);

		if (actions.Up.WasPressed)
			Debug.Log("Up " + Time.time);

		if (actions.Down.WasPressed)
			Debug.Log("Down " + Time.time);


		// Actions
		if (actions.Jump.WasPressed)
			Debug.Log("Jump " + Time.time);

		// Menu
		if (actions.Command.WasPressed)
			Debug.Log("Command " + Time.time);
	}
}
