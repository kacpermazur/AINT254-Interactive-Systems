using System.Runtime.InteropServices.WindowsRuntime;
using Camera;
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

		[SerializeField] private Transform playerSpawn;

		public bool isGravityFlipped = false;
		
		private bool isInitialized;

		[SerializeField] private GameObject _shootLocation;
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
				Jump();
				GravityFlip();
				Shoot();
				CheckBulletDestoryed();
				
				CameraManger.CameraController.CameraFollow(PlayerManager.PlayerTransform.transform, CameraController.CameraPerspective.THIRDPERSON);
				CameraManger.CameraController.FlipCamera(isGravityFlipped);

			}
		}
		
		void FixedUpdate()
		{
			if (isInitialized)
			{
				Movement();
			}
		}

		public void SpawnPlayer()
		{
			transform.position = playerSpawn.position;
		}
		
		private void Movement()
		{
			transform.Translate(0, 0, InputHandler.Vertical() * _playerData.MoveSpeed * Time.deltaTime);
			transform.Rotate(0, InputHandler.Horizontal() * _playerData.RotateSpeed * Time.deltaTime, 0);	
		}

		private void Jump()
		{
			if (InputHandler.Jump() && IsGrounded())
			{
				PlayerManager.PlayerRigidbody.AddForce(transform.up * _playerData.JumpPower * Time.deltaTime);
			}
		}

		private void GravityFlip()
		{
			if (InputHandler.FlipGravity())
			{
				Physics.gravity *= -1;
				
				if (!isGravityFlipped)
				{
					isGravityFlipped = true;
					
				}
				else
				{
					isGravityFlipped = false;
				}
				
			}
			
		}

		private void Shoot()
		{
			//ToDo: Move This Out
			
			
			if (InputHandler.Shoot())
			{
				if (canSpawn)
				{
					bullet = Instantiate(_blackHoleBullet, _shootLocation.transform.position,
						transform.rotation);
					
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
		
		private bool IsGrounded()
		{
			RaycastHit distanceFromPlayer;
			Ray underPlayerFeet = new Ray(transform.position, -transform.up);

			Physics.Raycast(underPlayerFeet, out distanceFromPlayer);

			float floorThreshold = 1.1f;
			
			LogMessage(distanceFromPlayer.distance.ToString());
			
			return distanceFromPlayer.distance < floorThreshold && distanceFromPlayer.distance != 0;
		}
			
		private static void LogMessage(string message)
		{
			Debug.Log("<color=green>" + PlayerControllerObjectName + "</color> : " + message);
		}
	}
}
