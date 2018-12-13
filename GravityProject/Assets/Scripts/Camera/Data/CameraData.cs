using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Camera.Data
{
	[CreateAssetMenuAttribute(fileName = "CameraData_")]
	public class CameraData : ScriptableObject
	{
		[Header("Camera Speed Settings")]
		public float FollowSpeed;
		public float Smoothing;

		[Header("Camera Offset Settings")]
		public float OffSetX;
		public float OffSetY;
		public float OffSetZ;
	}
}
