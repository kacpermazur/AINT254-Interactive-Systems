using System.Runtime.InteropServices.WindowsRuntime;
using Core.Input;
using Player.Data;

namespace Player
{
	using UnityEngine;
	
	public class PlayerController : MonoBehaviour, Initializable
	{
		private PlayerData _playerData;

		private bool isInitialized;
		
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
			}
		}
		
		void FixedUpdate()
		{
			if (isInitialized)
			{
				Movement();
				GravityFlip();
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
				isGravityFlipped = true;
				Physics.gravity *= -1;
			}
			else
			{
				isGravityFlipped = false;
			}
		}

		private bool IsGrounded()
		{
			RaycastHit distanceFromPlayer;
			Ray underPlayerFeet = new Ray(transform.position.normalized, -transform.up);

			Physics.Raycast(underPlayerFeet, out distanceFromPlayer);

			float floorThreshold = 1.1F;
			
			return distanceFromPlayer.distance < floorThreshold && distanceFromPlayer.distance != 0;
		}
			
	}
}
