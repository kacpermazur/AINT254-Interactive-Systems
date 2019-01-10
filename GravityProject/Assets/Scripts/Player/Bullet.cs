using System.Collections;
using Core;
using Core.Audio;
using Physics;
using Player.Data;
using UnityEngine;

namespace Player
{
	public class Bullet : MonoBehaviour
	{
		private static readonly string BulletClassName = typeof(Bullet).Name;
		
		private Rigidbody _bullet;
		private Collider _bulletColider;

		[SerializeField] private BulletData _data;

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
			
			if (_bullet == null)
			{
				_bullet = GetComponent<Rigidbody>();
			}
			
			GameManger.instance.SoundManger.PlayOutSideSFX("bulletHum", gameObject);
			
			_currentState = BulletState.MOVING;
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
					_bullet.AddRelativeForce(Vector3.forward  * _data.shootForce, ForceMode.Impulse);
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
		
		private static void LogMessage(string message)
		{
			Debug.Log("<color=red>" + BulletClassName + "</color> : " + message);
		}
	}
}