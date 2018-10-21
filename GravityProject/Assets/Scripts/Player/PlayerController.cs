using UnityEngine;
using Core.Input;
using Player.Data;

namespace Player
{
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

			if (InputHandler.Jump() && IsGrounded())
			{
				PlayerManager.PlayerRigidbody.AddForce(Vector3.up * _playerData.JumpPower * Time.deltaTime);
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
