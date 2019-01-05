using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;
using Player.Data;

namespace Player
{
	[RequireComponent(typeof(Rigidbody), typeof(PlayerController))]
	public class PlayerManager : MonoBehaviour, IInitializable
	{
		private static readonly string PlayerMangerObjectName = typeof(PlayerManager).Name;
		private static PlayerManager _instance;

		[SerializeField] private PlayerData _playerDataConfig;
		[SerializeField] private Transform _shootLocation;

		private Rigidbody _rigidbody;
		private PlayerController _playerController;
		

		public static PlayerData PlayerDataConfig
		{
			get
			{
				if (_instance._playerDataConfig == null)
				{
					LogMessage("PlayDataConfig Not Set Up");
					return null;
				}
				else
				{
					return _instance._playerDataConfig;
				}
			}
		}

		
		public static Transform PlayerTransform{ get { return _instance.transform; }}
		public static Transform BulletSpawn{ get { return _instance._shootLocation; }}
		
		public static Rigidbody PlayerRigidbody{ get { return _instance._rigidbody; }}

		public static PlayerController PlayerController{ get { return _instance._playerController; }}

		public void Initialize()
		{
			_instance = this;
			_rigidbody = GetComponent<Rigidbody>();
			_playerController = GetComponent<PlayerController>();
			
			_playerController.Initialize();
		}
		
		private static void LogMessage(string message)
		{
			Debug.Log("<color=red>" + PlayerMangerObjectName + "</color> : " + message);
		}
	}
}

