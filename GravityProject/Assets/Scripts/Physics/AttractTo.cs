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

		private Shoot _shoot;

		private Vector3 _direction;
		private float _force;

		[SerializeField] private float _forceMultiplyer;
		[SerializeField] private float _attractRadius;

		private void Start()
		{
			_playerTransform = PlayerManager.PlayerTransform;
			_playerRigidbody = PlayerManager.PlayerRigidbody;

			_shoot = GetComponent<Shoot>();
			
			_object = GetComponent<Rigidbody>();
			_collider = GetComponent<SphereCollider>();

			
			
			_collider.radius = _attractRadius;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.CompareTag("Player"))
			{
				if (_shoot.GetBulletState() == Shoot.BulletState.STOP)
				{
					float deathTimer = 1f;
					Destroy(gameObject, deathTimer);
				}
			}
		}

		private void OnTriggerStay(Collider other)
		{
			if (other.gameObject.CompareTag("Player"))
			{
				if (_shoot.GetBulletState() == Shoot.BulletState.STOP)
				{
					AttractToObject();
				}
			}
		}

		private void AttractToObject()
		{
			_direction = _object.position - _playerTransform.position;
			_force = (_object.mass * _playerRigidbody.mass);

			_playerRigidbody.AddForce(_direction.normalized * _force * _forceMultiplyer);
		}

		private static void LogMessage(string message)
		{
			Debug.Log("<color=yellow>" + AttractToObjectName + "</color> : " + message);
		}
	}
}