using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Input;

namespace Player.Weapon
{
	public class Shoot : MonoBehaviour, IInitializable
	{
		[SerializeField] private GameObject _prefab;
		[SerializeField] private Transform _shootLocation;
		
		private GameObject _instance;
		private Bullet _bullet;
		
		private bool isInitialized;
		
		public void Initialize()
		{
			if (!isInitialized)
			{
				_instance = Instantiate(_prefab, _shootLocation.position, transform.rotation);
				_bullet = _instance.GetComponent<Bullet>();
				
				_bullet.SetState(Bullet.State.DESTROY);
				isInitialized = true;
			}
		}

		public void ShootBullet(bool playerInput)
		{
			if (_bullet.GetState() == Bullet.State.DESTROY)
			{
				_instance.transform.position = _shootLocation.position;
				_bullet.SetState(Bullet.State.MOVING);
			}
			else if (_bullet.GetState() == Bullet.State.MOVING)
			{
				_bullet.SetState(Bullet.State.STOP);
			}
			else
			{
				_bullet.SetState(Bullet.State.DESTROY);
			}
		}
		
		
	}
}
