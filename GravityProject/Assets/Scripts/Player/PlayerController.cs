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
