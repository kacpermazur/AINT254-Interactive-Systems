using UnityEngine;

namespace Player.Data
{
	[CreateAssetMenuAttribute(fileName = "BulletData_")]
	public class BulletData : ScriptableObject
	{
		public float shootForce;
	}
}