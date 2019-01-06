using Core;
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
				_playerData = PlayerManager.PlayerDataConfig;
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
			}
		}
		
		private void Shoot()
		{
			if (InputHandler.Shoot() && canShoot)
			{
				//SoundManger.instance.PlaySound("dabb", SoundManger.SoundType.SFX);
				if (canSpawn)
				{
					bullet = Instantiate(_blackHoleBullet, PlayerManager.instance.BulletSpawn.position, PlayerManager.instance.BulletSpawn.rotation);
					
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
