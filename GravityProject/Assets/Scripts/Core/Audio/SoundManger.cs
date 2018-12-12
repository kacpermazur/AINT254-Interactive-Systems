using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.Audio;

namespace Core.Audio
{
	public class SoundManger : MonoBehaviour, IInitializable
	{
		private static readonly string SoundMangerName = typeof(SoundManger).Name;
		public static SoundManger instance;

		[SerializeField] private AudioSource _audioSourceMusic;
		[SerializeField] private AudioSource _audioSourceSfx;
		
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
		
		// Static: Sound can be played from any location
		// Dynamic: Sound can be played from specific location
		public enum SoundMode
		{
			STATIC,
			DYANMIC
		}

		[SerializeField] private SoundClip[] _soundSfx;
		[SerializeField] private SoundClip[] _soundMusic;
		[SerializeField] private SoundClip[] _soundUi;
		
		private void Awake()
		{
			Initialize();
		}

		public void Initialize()
		{
			if (instance == null)
			{
				instance = this;
			}
			
			DontDestroyOnLoad(this);
			
			
		}

		public void PlaySound(string name, SoundType type)
		{
			SoundClip selectedSound;
			
			switch (type)
			{
					case SoundType.SFX:
						selectedSound = Array.Find(_soundSfx, SoundClip => SoundClip.Name == name);
						SetAudioSettings(ref _audioSourceSfx, selectedSound);
						_audioSourceSfx.Play();
						break;
					case SoundType.MUSIC:
						selectedSound = Array.Find(_soundMusic, SoundClip => SoundClip.Name == name);
						SetAudioSettings(ref _audioSourceMusic, selectedSound);
						_audioSourceMusic.Play();
						break;
					case SoundType.UI:
						selectedSound = Array.Find(_soundUi, SoundClip => SoundClip.Name == name);
						SetAudioSettings(ref _audioSourceSfx, selectedSound);
						_audioSourceSfx.Play();
						break;
					default:
						selectedSound = null;
						LogMessage("Sound Not Found");
						return;
			}	
		}

		private void SetAudioSettings(ref AudioSource source, SoundClip sound) 
		{ 
			source.clip = sound.Audio; 
			source.loop = sound.Loop; 
			source.volume = sound.Volume; 
			sound.Pitch = sound.Pitch; 
			source.spatialBlend = sound.SpacialBlend; 
		} 
		
		
		private static void LogMessage(string message)
		{
			Debug.Log("<color=blue>" + SoundMangerName + "</color> : " + message);
		}
	}
}