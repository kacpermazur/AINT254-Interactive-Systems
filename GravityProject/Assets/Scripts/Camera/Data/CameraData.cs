using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Camera.Data
{
	[CreateAssetMenuAttribute(fileName = "CameraData_")]
	public class CameraData : ScriptableObject
	{
		public float FollowSpeed;
		public float Smoothing;
	}
}
