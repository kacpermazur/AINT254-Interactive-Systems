using System.Collections;
using System.Collections.Generic;
using Core;
using Core.Audio;
using UnityEngine;

namespace Player
{
	public class Bullet : MonoBehaviour
	{
		private static readonly string BulletClassName = typeof(Bullet).Name;
		
		private Rigidbody _bullet;
		private Collider _bulletColider;

		//ToDo Move This To Scriptable Object
		[SerializeField] private float _shootForce;

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
		public void SetBulletState(BulletState state) { _currentState = state; }

		private void Start()
		{
			_bulletColider = GetComponent<SphereCollider>();
			
			StartCoroutine(CheckVelocity());
			
			if (_bullet == null)
			{
				_bullet = GetComponent<Rigidbody>();
			}

			_currentState = BulletState.MOVING;
			
			GameManger.instance.SoundManger.PlayOutSideSFX("bulletHum", gameObject);
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
					_bulletColider.enabled = false;
					_bullet.AddRelativeForce(Vector3.forward  * _shootForce, ForceMode.Impulse);
					break;
				case BulletState.STOP:
					_bulletColider.enabled = true;
					_bullet.velocity = Vector3.zero;
					break;
				case BulletState.DESTROY:
					Destroy(gameObject);
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
			Debug.Log("<color=red>" + BulletClassName + "</color> : " + message);
		}
	}
}