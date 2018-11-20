using System.Collections;
using System.Collections.Generic;
using Camera;
using Camera.Data;
using UnityEngine;

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
		}
	}

	private void FollowTarget()
	{
		Vector3 moveToTargetPos = Vector3.Lerp(transform.position, CameraManger.CameraTarget.position, _cameraData.FollowSpeed * Time.deltaTime);
		transform.position = moveToTargetPos;
	}

	private static void LogMessage(string message)
	{
		Debug.Log("<color=blue>" + CameraControllerName + "</color> : " + message);
	}
}
