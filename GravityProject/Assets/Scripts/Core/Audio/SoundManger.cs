using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Audio
{
	public class SoundManger : MonoBehaviour, IInitializable
	{
		private static readonly string SoundMangerName = typeof(SoundManger).Name;
		private static  SoundManger _instance;
		
		
		
		private void Awake()
		{
			Initialize();
		}
		
		public void Initialize()
		{
			if (_instance == null)
			{
				_instance = this;
			}
		}

		private static void LogMessage(string message)
		{
			Debug.Log("<color=blue>" + SoundMangerName + "</color> : " + message);
		}
	}
}