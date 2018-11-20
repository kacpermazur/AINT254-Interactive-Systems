using System.Collections;
using System.Collections.Generic;
using Camera;
using Camera.Data;
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
			LogMessage(_cameraData.FollowSpeed.ToString());
		}

		private void FollowTarget()
		{

		}

		private static void LogMessage(string message)
		{
			Debug.Log("<color=silver>" + CameraControllerName + "</color> : " + message);
		}
	}
}