using System.Collections;
using System.Collections.Generic;
using Camera;
using Camera.Data;
using Core.Input;
using Player;
using UnityEngine;

namespace Camera
{
	public class CameraController : MonoBehaviour, IInitializable
	{
		private static readonly string CameraControllerName = typeof(CameraController).Name;

		private PlayerController _pc;
		private CameraData _cameraData;

		private bool isInitialized;
		
		public void Initialize()
		{
			if (!isInitialized)
			{
				_cameraData = CameraManger.CameraDataConfig;
				_pc = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
				isInitialized = true;
			}
		}

		void Update()
		{
			if (isInitialized)
			{
				FollowTarget();
				PlayerRotate();
			}
		}

		private void FollowTarget()
		{
			Vector3 moveToTarget = Vector3.Lerp(transform.position, CameraManger.GetCameraTarget.position,
				_cameraData.FollowSpeed * Time.deltaTime);
			
			transform.position = moveToTarget;
		}

		void PlayerRotate()
		{
			CameraManger.CameraPivot.localRotation = Quaternion.Euler(0, CameraManger.GetCameraTarget.transform.eulerAngles.y, 0);
			float rotNewZ = CameraManger.CameraPivotZ.localEulerAngles.z;
			float posNewZ = 1.92f;
			
			if (_pc.isGravityFlipped)
			{
				rotNewZ = Mathf.Lerp(rotNewZ, 180, Time.deltaTime * _cameraData.Smoothing);
				posNewZ = -1.92f;
			}
			else
			{
				rotNewZ = Mathf.Lerp(rotNewZ, 0, Time.deltaTime * _cameraData.Smoothing);
				posNewZ = 1.92f;
			}
		
			CameraManger.CameraPivotZ.localEulerAngles = new Vector3(0,0, rotNewZ);
			CameraManger.CameraPivotZ.transform.localPosition = new Vector3(0 , posNewZ, -3.452f);
		}

		private static void LogMessage(string message)
		{
			Debug.Log("<color=silver>" + CameraControllerName + "</color> : " + message);
		}
	}
}