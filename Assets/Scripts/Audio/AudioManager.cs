using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
	public AudioMixerGroup mixerGroup;
	public Sound[] sounds;

	private string currentTheme;

	// Theme constants
	private const string MENU_THEME = "MenuTheme";
	private const string SOMBER_THEME = "SomberTheme";
	private const string THERAPY_ROOM_THEME = "TherapyRoomTheme";
	private const string SUPERMARKET_REGULAR_THEME = "SupermarketRegularTheme";
	private const string SUPERMARKET_BOSS_THEME = "SupermarketBossTheme";
	private const string CLASSROOM_REGULAR_THEME = "ClassroomRegularTheme";
	private const string CLASSROOM_BOSS_THEME = "ClassroomBossTheme";
	private const string HOUSE_REGULAR_THEME = "HouseRegularTheme";
	private const string HOUSE_BOSS_THEME = "HouseBossTheme";

	void Awake()
	{
		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;

			s.source.outputAudioMixerGroup = mixerGroup;
		}
	}
	
	void OnEnable()
	{
		Debug.Log("OnEnable called");
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{	
		string currentScene = SceneManager.GetActiveScene().name;
		Debug.Log(currentScene);

		if (currentScene.Contains("Menu")) Play(MENU_THEME);
		else if (currentScene.Contains("Shop_Creation")) Play(THERAPY_ROOM_THEME);
		else if (currentScene.Contains("utscene") && !currentScene.Contains("Opening") && !currentScene.Contains("Prologue")) Play(SOMBER_THEME);
		else if (currentScene.Contains("Supermarket 1")) Play(SUPERMARKET_REGULAR_THEME);
		else if (currentScene.Contains("Supermarket 2") || currentScene.Contains("Supermarket 3")) Play(SUPERMARKET_BOSS_THEME);
		else if (currentScene.Contains("Classroom 1")) Play(CLASSROOM_REGULAR_THEME);
		else if (currentScene.Contains("Classroom 2")) Play(CLASSROOM_BOSS_THEME);
		else if (currentScene.Contains("House 1") || currentScene.Contains("House 2")) Play(HOUSE_REGULAR_THEME);	
		else if (currentScene.Contains("House 3")) Play(HOUSE_BOSS_THEME);
	}

	public void Play(string sound)
	{
		if (sound == currentTheme) return;

		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		if (sound.Contains("Theme"))
		{
			Debug.Log(sound);
			StopCurrentTheme();
			currentTheme = sound;	
		}

		s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

		if (s.source.enabled) s.source.Play();
	}

	private void StopCurrentTheme()
	{
		if (String.IsNullOrEmpty(currentTheme)) return;
		Sound s = Array.Find(sounds, item => item.name == currentTheme);
		if (s.source.enabled) s.source.Stop();
	}		

}
