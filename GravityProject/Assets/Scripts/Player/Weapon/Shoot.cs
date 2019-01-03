using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Input;

namespace Player.Weapon
{
	public class Shoot : MonoBehaviour, IInitializable
	{
		private Bullet _shootingBullet;
		
		public void Initialize()
		{
			_shootingBullet = GetComponent<Bullet>();
		}
	
	}
}
