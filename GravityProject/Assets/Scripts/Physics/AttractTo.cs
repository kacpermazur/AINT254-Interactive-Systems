using System.Collections;
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
		[SerializeField] private float minStopVelocity = 0.1f;
		
		[SerializeField] private float _forceMultiplyer;
		[SerializeField] private float _attractRadius;

		public enum ObjectState
		{
			Spawned,
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

			State = ObjectState.Spawned;
			_object.AddForce(Vector3.forward * 500, ForceMode.Impulse);

			StartCoroutine(CheckAfterForceDecay());
			
			LogMessage(State.ToString());
		}
		
		private void Update()
		{
			CheckAndUpdateStates();
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.CompareTag("Player"))
			{
				if (State == ObjectState.Stop)
				{
					Destroy(gameObject, 0.3f);
				}
			}
		}

		private void OnTriggerStay(Collider other)
		{
			if (other.gameObject.CompareTag("Player"))
			{
				if (State == ObjectState.Stop)
				{
					AttractToObject();
				}
			}
		}

		private void AttractToObject()
		{
			Vector3 direction = _object.position - _playerTransform.position;
			float force = (_object.mass * _playerRigidbody.mass);

			_playerRigidbody.AddForce(direction.normalized * force * _forceMultiplyer);
		}

		private void CheckAndUpdateStates()
		{
			if (State == ObjectState.Spawned)
			{
				State = ObjectState.Moving;
			}

			if (State == ObjectState.Moving)
			{
				LogMessage("Bullet is Moving");
			}
			
			if (State == ObjectState.Stop)
			{
				_object.velocity = Vector3.zero;
				
				LogMessage(State.ToString());
			}

			if (State == ObjectState.Destory)
			{
				Destroy(gameObject);
				
				LogMessage(State.ToString());
			}
		}

		IEnumerator CheckAfterForceDecay()
		{
			yield return new WaitForSeconds(2f);
			
			if (_object.velocity.magnitude < minStopVelocity )
			{
				State = ObjectState.Stop;
			}
		}

		private static void LogMessage(string message)
		{
			Debug.Log("<color=yellow>" + AttractToObjectName + "</color> : " + message);
		}
	}
}