using System.Runtime.InteropServices.WindowsRuntime;
using Core.Audio;
using Core.Input;
using Physics;
using Player.Data;
using UnityEditor;

namespace Player
{
	using UnityEngine;
	
	public class PlayerController : MonoBehaviour, IInitializable
	{
		private static readonly string PlayerControllerObjectName = typeof(PlayerController).Name;
		
		private PlayerData _playerData;
		
		private bool isInitialized;

		[SerializeField] private GameObject _blackHoleBullet;	
		
		//temp
		public GameObject bullet;
		public bool canSpawn = false;

		public void Initialize()
		{
			
			if (!isInitialized)
			{
				_playerData = PlayerManager.PlayerDataConfig;
				isInitialized = true;
			}
		}

		void Update()
		{
			if (isInitialized)
			{
				Shoot();
				CheckBulletDestoryed();

			}
		}
		
		private void Shoot()
		{
			//ToDo: Move This Out
			
			
			if (InputHandler.Shoot())
			{
				//SoundManger.instance.PlaySound("dabb", SoundManger.SoundType.SFX);
				if (canSpawn)
				{
					bullet = Instantiate(_blackHoleBullet, PlayerManager.BulletSpawn.position, PlayerManager.BulletSpawn.rotation);
					
					canSpawn = false;
				}
				
				if (bullet.GetComponent<Bullet>().GetBulletState() == Bullet.BulletState.MOVING)
				{
					bullet.GetComponent<Bullet>().SetBulletState(Bullet.BulletState.STOP);
				}
				else if (bullet.GetComponent<Bullet>().GetBulletState() == Bullet.BulletState.STOP)
				{
					bullet.GetComponent<Bullet>().SetBulletState(Bullet.BulletState.DESTROY);
					canSpawn = true;
				}
			}
		}

		private void CheckBulletDestoryed()
		{
			if (bullet == null)
			{
				canSpawn = true;
			}
		}
		
		private static void LogMessage(string message)
		{
			Debug.Log("<color=green>" + PlayerControllerObjectName + "</color> : " + message);
		}
	}
}
