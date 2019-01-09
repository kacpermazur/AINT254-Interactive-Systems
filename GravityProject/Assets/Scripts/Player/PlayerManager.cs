using UnityEngine;
using Player.Data;
using UnityStandardAssets.Characters.FirstPerson;

namespace Player
{
	[RequireComponent(typeof(Rigidbody), typeof(PlayerController))]
	public class PlayerManager : MonoBehaviour, IInitializable
	{
		private static readonly string PlayerMangerObjectName = typeof(PlayerManager).Name;

		[SerializeField] private PlayerData _playerDataConfig;
		[SerializeField] private Transform _shootLocation;
		[SerializeField] private Transform _playerSpawn;

		private Rigidbody _rigidbody;
		private PlayerController _playerController;
		private RigidbodyFirstPersonController _controller;

		public PlayerData PlayerDataConfig
		{
			get
			{
				if (_playerDataConfig == null)
				{
					LogMessage("PlayDataConfig Not Set Up");
					return null;
				}
				else
				{
					return _playerDataConfig;
				}
			}
		}
		
		public Transform PlayerTransform => transform;
		public Transform BulletSpawn => _shootLocation;
		public Transform PlayerSpawn => _playerSpawn;

		public Rigidbody PlayerRigidbody => _rigidbody;
		
		public PlayerController PlayerController => _playerController;
		public RigidbodyFirstPersonController FirstPersonController => _controller;

		public void Initialize()
		{
			_rigidbody = GetComponent<Rigidbody>();
			_playerController = GetComponent<PlayerController>();
			_controller = GetComponent<RigidbodyFirstPersonController>();
			
			_playerController.Initialize();
		}
		
		private static void LogMessage(string message)
		{
			Debug.Log("<color=red>" + PlayerMangerObjectName + "</color> : " + message);
		}
	}
}

