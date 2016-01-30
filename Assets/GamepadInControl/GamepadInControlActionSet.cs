
// Generic InControl PlayerActionSet.

// 2015/10/19 04:41 PM


using InControl;


public class GamepadInControlActionSet : PlayerActionSet
{
	// Joystick
	public PlayerAction Left;
	public PlayerAction Right;
	public PlayerAction Up;
	public PlayerAction Down;
	public PlayerTwoAxisAction Movement;

	// Basic actions
	public PlayerAction Jump;
	public PlayerAction Break;

	public PlayerAction Accelerate;
	public PlayerAction Desaccelerate;

	// Menu
	public PlayerAction Command;


	public GamepadInControlActionSet()
	{
		// Joystick
		Left = CreatePlayerAction("MoveLeft");
		Right = CreatePlayerAction("MoveRight");
		Up = CreatePlayerAction("MoveUp");
		Down = CreatePlayerAction("MoveDown");

		Movement = CreateTwoAxisPlayerAction(Left, Right, Down, Up);

		// Actions
		Jump = CreatePlayerAction("Jump");

		Break = CreatePlayerAction("Break");

		Accelerate = CreatePlayerAction("Accelerate");

		Desaccelerate = CreatePlayerAction("desaccelerate");


		// Menu
		Command = CreatePlayerAction("Command");
	}
}
