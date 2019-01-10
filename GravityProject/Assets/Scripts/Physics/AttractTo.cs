using UnityEngine;
using Player;
using Core;
using Physics.Data;

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

		[SerializeField] private destoryBulletCol _dest;
		private Bullet _bullet;

		private Vector3 _direction;
		private float _force;

		[SerializeField] private PhysicsData _data;

		private void Start()
		{
			_playerTransform = GameManger.instance.PlayerManger.PlayerTransform;
			_playerRigidbody = GameManger.instance.PlayerManger.PlayerRigidbody;

			_bullet = GetComponent<Bullet>();
			_dest = GetComponentInChildren<destoryBulletCol>();
			
			_object = GetComponent<Rigidbody>();
			_collider = GetComponent<SphereCollider>();
			
			
			_collider.radius = _data.attractRadius;
		}

		private void Update()
		{
			if (_dest.hasEntered && (_bullet.GetBulletState() == Bullet.BulletState.STOP))
			{
				float deathTimer = 0.3f;
				;
				Destroy(gameObject, deathTimer);
			}
		}
		
		private void OnTriggerStay(Collider other)
		{
			if (other.gameObject.CompareTag("Player"))
			{
				if (_bullet.GetBulletState() == Bullet.BulletState.STOP)
				{
					AttractToObject();
				}
			}
		}
		
		private void AttractToObject()
		{
			_direction = _object.position - _playerTransform.position;
			_force = (_object.mass * _playerRigidbody.mass);

			_playerRigidbody.AddForce(_direction.normalized * _force * _data.forceMultiplier);
		}

		private static void LogMessage(string message)
		{
			Debug.Log("<color=yellow>" + AttractToObjectName + "</color> : " + message);
		}
	}
}