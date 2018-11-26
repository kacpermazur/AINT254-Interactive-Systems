using System.Runtime.InteropServices.WindowsRuntime;
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

		public bool isGravityFlipped = false;

		private bool isInitialized;
		
		private int _currentSelection = 0;
		private AttractTo _currentSelectedBullet = null;

		[SerializeField] private GameObject _shootLocation;
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
			if (InputHandler.FlipGravity())
			{
				Physics.gravity *= -1;
				PlayerManager.PlayerTransform.Rotate(180, 180, 0);
				
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
		/*
			if (InputHandler.Shoot())
			{
				if (_currentSelection == 0)
				{
					LogMessage("selection : " + _currentSelection.ToString());
					
					_currentSelection += 1;
					Instantiate(_blackHoleBullet, _shootLocation.transform.position, Quaternion.identity);
					_currentSelectedBullet = GameObject.FindWithTag("Bullet").GetComponent<AttractTo>();
					
					LogMessage(_currentSelectedBullet.ToString());
				}
				else if (_currentSelection == 1)
				{
					LogMessage("selection : " + _currentSelection.ToString());

					_currentSelection += 1;
					_currentSelectedBullet.State = AttractTo.ObjectState.Stop;
				}
				else if (_currentSelection == 2)
				{
					LogMessage("selection : " + _currentSelection.ToString());

					_currentSelection = 0;
					_currentSelectedBullet.State = AttractTo.ObjectState.Destory;
					_currentSelectedBullet = null;
				}
				else
				{
					LogMessage("Shoot : Checking Shooting");
				}
			}
			*/
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
