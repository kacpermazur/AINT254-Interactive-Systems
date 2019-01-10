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
		
		private GameObject _bullet;

		private bool _canSpawn = false;
		private bool _canShoot = false;

		private bool _canPause;
		public void SetCanPause(bool conditonOverride)
		{
			_canPause = conditonOverride;
			
		}

		public void Initialize()
		{
			
			if (!isInitialized)
			{
				_playerData = GameManger.instance.PlayerManger.PlayerDataConfig;
				isInitialized = true;
			}
		}

		public void CanShoot(bool condition)
		{
			_canShoot = condition;
		}

		public void SpawnPlayer()
		{
			GameManger.instance.PlayerManger.PlayerTransform.position = GameManger.instance.PlayerManger.PlayerSpawn.position;
		}

		public void DestoryBullet()
		{
			if (_bullet)
			{
				_bullet.GetComponent<Bullet>().SetBulletState(Bullet.BulletState.DESTROY);
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
			if (InputHandler.Escape() && _canPause)
			{
				GameManger.instance.SetGameState(GameManger.GameState.PAUSED);

				if (_bullet)
				{
					_bullet.GetComponent<Bullet>().SetBulletState(Bullet.BulletState.DESTROY);
				}
				
			}
		}
		
		private void Shoot()
		{
			if (InputHandler.Shoot() && _canShoot)
			{
				if (_canSpawn)
				{
					_bullet = Instantiate(_blackHoleBullet, GameManger.instance.PlayerManger.BulletSpawn.position, GameManger.instance.PlayerManger.BulletSpawn.rotation);
					GameManger.instance.SoundManger.PlaySound("shoot", SoundManger.SoundType.SFX);

					_canSpawn = false;
				}
				
				if (_bullet.GetComponent<Bullet>().GetBulletState() == Bullet.BulletState.MOVING)
				{
					_bullet.GetComponent<Bullet>().SetBulletState(Bullet.BulletState.STOP);
				}
				else if (_bullet.GetComponent<Bullet>().GetBulletState() == Bullet.BulletState.STOP)
				{
					_bullet.GetComponent<Bullet>().SetBulletState(Bullet.BulletState.DESTROY);
					_canSpawn = true;
				}
			}
		}

		private void CheckBulletDestoryed()
		{
			if (_bullet == null)
			{
				_canSpawn = true;
			}
		}

		private static void LogMessage(string message)
		{
			Debug.Log("<color=green>" + PlayerControllerObjectName + "</color> : " + message);
		}
	}
}
