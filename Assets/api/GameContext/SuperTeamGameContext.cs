using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class SuperTeamGameContext : MonoSingleton<SuperTeamGameContext>
{

	private static RitualCharmManager _ritualCharmManager;
	
	public static RitualCharmManager RitualCharmManager {
		get{
			if(_ritualCharmManager == null){

				_ritualCharmManager = FindObjectOfType(typeof(RitualCharmManager)) as RitualCharmManager;

				DontDestroyOnLoad(_ritualCharmManager);
			}

			return _ritualCharmManager;
		}
	}

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
	// Camera2D
	private static Camera _mainCamera;
	public static Camera mainCamera
	{
		get
		{
			if (_mainCamera == null){
				_mainCamera = GameObject.FindObjectOfType<Camera>();
			}

			return _mainCamera;
		}
	}
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
