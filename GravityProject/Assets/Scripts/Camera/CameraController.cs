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
		
		private CameraData _cameraData;
		
		private bool isInitialized;
		
		public enum CameraPerspective 
		{
			FIRSTPERSON,
			THIRDPERSON
		}
		
		public void Initialize()
		{
			if (!isInitialized)
			{
				_cameraData = CameraManger.CameraDataConfig;
				isInitialized = true;
			}
		}

		public void CameraFollow(Transform target)
		{
			Vector3 moveToTarget = Vector3.Lerp(transform.position, target.position,
				_cameraData.FollowSpeed * Time.deltaTime);
			
			transform.position = moveToTarget;
		}

		//public void 
		
		/*
		void PlayerRotate()
		{
			CameraManger.CameraPivot.localRotation = Quaternion.Euler(0, CameraManger.GetCameraTarget.transform.eulerAngles.y, 0);
			float rotNewZ = CameraManger.CameraPivotZ.localEulerAngles.z;
			float posNewZ = 1.92f;
			
			if (PlayerManager.PlayerController.isGravityFlipped)
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
		*/

		private static void LogMessage(string message)
		{
			Debug.Log("<color=silver>" + CameraControllerName + "</color> : " + message);
		}
	}
}