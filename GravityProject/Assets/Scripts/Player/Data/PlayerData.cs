using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Data
{
	[CreateAssetMenuAttribute(fileName = "PlayerData_")]
	public class PlayerData : ScriptableObject
	{
		public float MoveSpeed;
		public float RotateSpeed;
		public float JumpPower;
	}


}
