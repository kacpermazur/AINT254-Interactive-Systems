﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Data;

namespace Player
{
	[RequireComponent(typeof(Rigidbody), typeof(PlayerController))]
	public class PlayerManager : MonoBehaviour,Initializable
	{
		private static readonly string PlayerMangerObjectName = typeof(PlayerManager).Name;
		private static PlayerManager _instance;

		[SerializeField] private PlayerData _playerDataConfig;

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
		public static Rigidbody PlayerRigidbody{ get { return _instance._rigidbody; }}

		public PlayerController PlayerController{ get { return _instance._playerController; }}

		void Awake()
		{
			if (_instance == null)
			{
				_instance = this;
			}
			
			Initialize();
		}


		public void Initialize()
		{
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

