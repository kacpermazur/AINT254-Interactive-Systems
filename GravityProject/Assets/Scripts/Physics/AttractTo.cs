using Physics.Data;
using UnityEngine;
using Player;

namespace Physics
{
	[RequireComponent(typeof(Rigidbody),typeof(SphereCollider))]
	public class AttractTo : MonoBehaviour
	{
		private static readonly string AttractToObjectName = typeof(AttractTo).Name;

		private Transform _playerTransform;
		private Rigidbody _playerRigidbody;

		private Rigidbody _object;
		private SphereCollider _collider;


		[SerializeField] private float _shootForce;
		[SerializeField] private float _currentVelcoity;
		
		[SerializeField] private float _forceMultiplyer;
		[SerializeField] private float _attractRadius;

		public enum ObjectState
		{
			Moving,
			Stop,
			Destory
		}

		public ObjectState State;

		private void Start()
		{
			_playerTransform = PlayerManager.PlayerTransform;
			_playerRigidbody = PlayerManager.PlayerRigidbody;

			_object = GetComponent<Rigidbody>();
			_collider = GetComponent<SphereCollider>();

			_collider.radius = _attractRadius;

			State = ObjectState.Moving;
			_object.AddForce(transform.forward * 500, ForceMode.Impulse);
		}

		private void FixedUpdate()
		{
			_currentVelcoity = _object.velocity.magnitude;
		}

		private void Update()
		{
			float maximumLowestSpeed = 0.1f; 
			
			if (_currentVelcoity < maximumLowestSpeed)
			{
				
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.CompareTag("Player"))
			{
				Destroy(gameObject, 1);
			}
		}

		private void OnTriggerStay(Collider other)
		{
			if (other.gameObject.CompareTag("Player"))
			{
				AttractToObject();
			}
		}

		private void AttractToObject()
		{
			Vector3 direction = _object.position - _playerTransform.position;
			float force = (_object.mass * _playerRigidbody.mass);

			_playerRigidbody.AddForce(direction.normalized * force * _forceMultiplyer);
		}

		private static void LogMessage(string message)
		{
			Debug.Log("<color=yellow>" + AttractToObjectName + "</color> : " + message);
		}
	}
}