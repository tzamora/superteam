using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class SuperTeamGameContext : MonoSingleton<SuperTeamGameContext>
{
//	private static LevelGUIController _levelGUI;
//
//	public static LevelGUIController LevelGUI {
//		get{
//			if(_levelGUI == null){
//
//				_levelGUI = FindObjectOfType(typeof(LevelGUIController)) as LevelGUIController;
//
//				DontDestroyOnLoad(_levelGUI);
//			}
//
//			return _levelGUI;
//		}
//	}
//
//	private static SpawnPointController[] _spawnPoints;
//	public static SpawnPointController[] spawnPoints
//	{
//		get
//		{
//			_spawnPoints = FindObjectsOfType(typeof(SpawnPointController)) as SpawnPointController[];
//
//			return _spawnPoints;
//		}
//	}
//
//	private static LionData[] _players;
//	public static LionData[] players
//	{
//		get
//		{
//
//			_players = FindObjectsOfType(typeof(LionData)) as LionData[];
//
//			return _players;
//		}
//	}
//
//	// Camera2D
//	private static Camera2D _camera2d;
//	public static Camera2D camera2D
//	{
//		get
//		{
//			if (_camera2d == null){
//				_camera2d = GameObject.FindObjectOfType<Camera2D>();
//			}
//
//			return _camera2d;
//		}
//	}
//
//	// Sound library
//	private static Sounds _sounds;
//	public static Sounds sounds
//	{
//		get
//		{
//			if (_sounds == null)
//			{
//				_sounds = GameObject.FindObjectOfType<Sounds>();
//			}
//
//			return _sounds;
//		}
//	}
//
//
//	private static LevelManagerController _levelManager;
//	public static LevelManagerController LevelManager
//	{
//		get
//		{
//			if (_levelManager == null){
//				_levelManager = GameObject.FindObjectOfType<LevelManagerController>();
//				DontDestroyOnLoad (_levelManager);
//			}
//
//				
//
//			return _levelManager;
//		}
//	}

	void Start(){
		// main
	}
}
