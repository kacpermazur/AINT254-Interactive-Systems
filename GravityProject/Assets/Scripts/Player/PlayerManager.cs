using UnityEngine;
using Player.Data;
using UnityStandardAssets.Characters.FirstPerson;

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
		private RigidbodyFirstPersonController _controller;

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
		
		public static PlayerManager instance { get { return _instance; } }
		
		public Transform PlayerTransform{ get { return transform; }}
		public Transform BulletSpawn{ get { return _shootLocation; }}
		
		public Rigidbody PlayerRigidbody{ get { return _rigidbody; }}
		
		public PlayerController PlayerController { get { return _playerController; } }
		public RigidbodyFirstPersonController FirstPersonController { get { return _controller; } }

		public void Initialize()
		{
			_instance = this;
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

