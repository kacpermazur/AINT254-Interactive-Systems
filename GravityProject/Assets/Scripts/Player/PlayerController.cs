using Core;
using Core.Audio;
using Core.Input;
using Player.Data;

namespace Player
{
	using UnityEngine;
	
	public class PlayerController : MonoBehaviour, IInitializable
	{
		private static readonly string PlayerControllerObjectName = typeof(PlayerController).Name;
		
		private PlayerData _playerData;
		
		private bool isInitialized;

		[SerializeField] private GameObject _blackHoleBullet;	
		
		private GameObject bullet;
		private bool canSpawn = false;
		private bool canShoot = false;

		public void Initialize()
		{
			
			if (!isInitialized)
			{
				_playerData = GameManger.instance.PlayerManger.PlayerDataConfig;
				isInitialized = true;
			}
		}

		private void Update()
		{
			if (isInitialized)
			{
				Shoot();
				CheckBulletDestoryed();
				PauseMenu();
			}
		}

		private void PauseMenu()
		{
			if (InputHandler.Escape())
			{
				GameManger.instance.SetGameState(GameManger.GameState.PAUSED);

				if (bullet)
				{
					bullet.GetComponent<Bullet>().SetBulletState(Bullet.BulletState.DESTROY);
				}
				
			}
		}
		
		private void Shoot()
		{
			if (InputHandler.Shoot() && canShoot)
			{
				if (canSpawn)
				{
					bullet = Instantiate(_blackHoleBullet, GameManger.instance.PlayerManger.BulletSpawn.position, GameManger.instance.PlayerManger.BulletSpawn.rotation);
					GameManger.instance.SoundManger.PlaySound("shoot", SoundManger.SoundType.SFX);
					
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

		public void CanShoot(bool condition)
		{
			canShoot = condition;
		}
		
		private static void LogMessage(string message)
		{
			Debug.Log("<color=green>" + PlayerControllerObjectName + "</color> : " + message);
		}
	}
}
