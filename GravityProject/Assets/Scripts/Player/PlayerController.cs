using System.Runtime.InteropServices.WindowsRuntime;
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

		[SerializeField] private Transform _shootLocation;
		[SerializeField] private GameObject _blackHoleBullet;
		
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
			}
		}
		
		void FixedUpdate()
		{
			if (isInitialized)
			{
				Movement();
			}
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
				PlayerManager.PlayerRigidbody.AddForce(Vector3.up * _playerData.JumpPower * Time.deltaTime);
			}
		}

		private void GravityFlip()
		{
			bool isGravityFlipped = false;
			
			if (InputHandler.FlipGravity() && isGravityFlipped == false)
			{

				Physics.gravity *= -1;
				
				PlayerManager.PlayerTransform.Rotate(180, 180, 0);
			}
			else
			{
				isGravityFlipped = false;
			}
		}

		private void Shoot()
		{
			if (InputHandler.Shoot())
			{
				Instantiate(_blackHoleBullet, _shootLocation);
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
