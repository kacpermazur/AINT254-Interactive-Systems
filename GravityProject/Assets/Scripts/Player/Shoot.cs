using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
	public class Shoot : MonoBehaviour
	{
		private static readonly string PlayerShootName = typeof(Shoot).Name;
		
		private Rigidbody _bullet;

		//ToDo Move This To Scriptable Object
		private float _shootForce;
		private float _currentVelocity;

		private float _checkTimer = 2f;
		private float _minStopVelocity = 0.1f;
		
		public enum BulletState
		{
			MOVING,
			STOP,
			DESTROY
		}

		private BulletState _currentState;

		public BulletState GetBulletState(){ return _currentState; }


		private void Start()
		{
			StartCoroutine(CheckVelocity());
			
			if (_bullet == null)
			{
				_bullet = GetComponent<Rigidbody>();
			}

			_currentState = BulletState.MOVING;
			_bullet.AddForce(Vector3.forward * 500, ForceMode.Impulse);
		}

		private void Update()
		{
			UpdateStates();
		}

		void UpdateStates()
		{
			switch (_currentState)
			{
				case BulletState.MOVING:
					_currentState = BulletState.MOVING;
					LogMessage(_currentState.ToString());
					break;
				case BulletState.STOP:
					_bullet.velocity = Vector3.zero;
					LogMessage(_currentState.ToString());
					break;
				case BulletState.DESTROY:
					LogMessage(_currentState.ToString());
					Destroy(this);
					break;
				default:
					LogMessage("States Change Error");
					break;
					
			}
		}

		private IEnumerator CheckVelocity()
		{
			yield return new WaitForSeconds(_checkTimer);
			
			if (_bullet.velocity.magnitude < _minStopVelocity)
			{
				_currentState = BulletState.STOP;
			}
		}
		
		
		private static void LogMessage(string message)
		{
			Debug.Log("<color=red>" + PlayerShootName + "</color> : " + message);
		}
	}
}



/*
private Rigidbody _object;
		
		[SerializeField] private float _shootForce;
		[SerializeField] private float _currentVelcoity;
		[SerializeField] private float minStopVelocity = 0.1f;

		
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
			StartCoroutine(CheckAfterForceDecay());
			
			LogMessage(State.ToString());
			
			State = ObjectState.Spawned;
			_object.AddForce(Vector3.forward * 500, ForceMode.Impulse);
		}

		private void Update()
		{
			CheckAndUpdateStates();
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
		
		*/