﻿using Physics.Data;
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

		[SerializeField] private destoryBulletCol _dest;
		private Bullet _bullet;

		private Vector3 _direction;
		private float _force;

		[SerializeField] private float _forceMultiplyer;
		[SerializeField] private float _attractRadius;

		private void Start()
		{
			_playerTransform = PlayerManager.PlayerTransform;
			_playerRigidbody = PlayerManager.PlayerRigidbody;

			_bullet = GetComponent<Bullet>();
			_dest = GetComponentInChildren<destoryBulletCol>();
			
			_object = GetComponent<Rigidbody>();
			_collider = GetComponent<SphereCollider>();
			
			
			_collider.radius = _attractRadius;
		}

		private void Update()
		{
			LogMessage(_dest.hasEntered.ToString());
			
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

			_playerRigidbody.AddForce(_direction.normalized * _force * _forceMultiplyer);
		}

		private static void LogMessage(string message)
		{
			Debug.Log("<color=yellow>" + AttractToObjectName + "</color> : " + message);
		}
	}
}