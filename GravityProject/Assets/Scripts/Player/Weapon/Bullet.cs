using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
	public class Bullet : MonoBehaviour
	{
		private static readonly string BulletClassName = typeof(Bullet).Name;
		
		private Rigidbody _bullet;

		//ToDo Move This To Scriptable Object
		[SerializeField] private float _shootForce;

		private float _checkTimer = 2f;
		private float _minStopVelocity = 0.1f;
		
		public enum State
		{
			MOVING,
			STOP,
			DESTROY
		}

		private State _currentState;

		public State GetState(){ return _currentState; }
		public void SetState(State state) { _currentState = state; }

		private void BulletStates()
		{
			switch (_currentState)
			{
				case State.MOVING:
					gameObject.SetActive(true);
					StartCoroutine(StopBulletAfter());
					_bullet = GetComponent<Rigidbody>();
					_bullet.AddRelativeForce(Vector3.forward  * _shootForce, ForceMode.Impulse);
					LogMessage(_currentState.ToString());
					break;
				case State.STOP:
					_bullet.velocity = Vector3.zero;
					LogMessage(_currentState.ToString());
					break;
				case State.DESTROY:
					LogMessage(_currentState.ToString());
					gameObject.SetActive(false);
					break;	
				default:
					LogMessage("States Change Error");
					break;
					
			}
		}
		
		private IEnumerator StopBulletAfter()
		{
			yield return new WaitForSeconds(_checkTimer);

			_currentState = State.STOP;
		}
		
		private static void LogMessage(string message)
		{
			Debug.Log("<color=red>" + BulletClassName + "</color> : " + message);
		}
	}
}