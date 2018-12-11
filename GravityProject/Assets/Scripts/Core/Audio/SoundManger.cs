using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

namespace Core.Audio
{
	public class SoundManger : MonoBehaviour, IInitializable
	{
		private static readonly string SoundMangerName = typeof(SoundManger).Name;
		private static SoundManger _instance;

		private AudioSource _audioSourceMusic;
		private AudioSource _audioSourceSfx;
		
		//testing
		public enum GameMode
		{
			STARTMENU,
			INGAME,
			PAUSE,
		}
		public enum SoundType
		{
			SFX,
			MUSIC,
			UI,
		}

		[SerializeField] private SoundClip[] _soundSfx;
		[SerializeField] private SoundClip[] _soundMusic;
		[SerializeField] private SoundClip[] _soundUi;
		
		private void Awake()
		{
			Initialize();
		}

		private void Update()
		{
			
		}

		public void Initialize()
		{
			if (_instance == null)
			{
				_instance = this;
			}

			_audioSourceMusic = gameObject.AddComponent<AudioSource>();
			_audioSourceSfx = gameObject.AddComponent<AudioSource>();

			DontDestroyOnLoad(this);
		}

		public void PlaySound(string name, SoundType type)
		{
			SoundClip selectedSound;
			
			switch (type)
			{
					case SoundType.SFX:
						selectedSound = Array.Find(_soundSfx, SoundClip => SoundClip.Name == name);
						_audioSourceSfx.clip = selectedSound.Audio;
						_audioSourceSfx.Play();
						break;
					case SoundType.MUSIC:
						selectedSound = Array.Find(_soundMusic, SoundClip => SoundClip.Name == name);
						_audioSourceMusic.clip = selectedSound.Audio;
						_audioSourceMusic.Play();
						break;
					case SoundType.UI:
						selectedSound = Array.Find(_soundUi, SoundClip => SoundClip.Name == name);
						_audioSourceSfx.clip = selectedSound.Audio;
						_audioSourceSfx.Play();
						break;
					default:
						selectedSound = null;
						LogMessage("Sound Not Found");
						return;
			}	
		}
		
		private static void LogMessage(string message)
		{
			Debug.Log("<color=blue>" + SoundMangerName + "</color> : " + message);
		}
	}
}