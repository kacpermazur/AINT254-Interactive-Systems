using System.Collections;
using System.Collections.Generic;
using Camera;
using Camera.Data;
using Core.Input;
using UnityEngine;

namespace Camera
{
	public class CameraController : MonoBehaviour, IInitializable
	{
		private static readonly string CameraControllerName = typeof(CameraController).Name;

		private CameraData _cameraData;

		private bool isInitialized;

		public void Initialize()
		{
			if (!isInitialized)
			{
				_cameraData = CameraManger.CameraDataConfig;
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

			if (InputHandler.FlipGravity())
			{
				CameraManger.CameraPivot.localRotation = Quaternion.Slerp(transform.rotation, CameraManger.GetCameraTarget.transform.rotation, Time.deltaTime * _cameraData.Smoothing);
			}
		}

		private static void LogMessage(string message)
		{
			Debug.Log("<color=silver>" + CameraControllerName + "</color> : " + message);
		}
	}
}